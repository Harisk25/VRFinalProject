using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    [Header("Light Beam Settings")]
    public LayerMask layerMask;
    public LayerMask layerMaskRefract;
    public float defualtLength = 50; // lenght of the light
    public int numOfReflectionRefraction = 10; // number of reflection or refractions that can be made

    private LineRenderer lineRenderer;
    private RaycastHit hit;

    private Ray ray;

    Dictionary<string, float> refractiveMaterials = new Dictionary<string, float>() // Refrative index of materials
    {
        {"Air", 1.0f },
        {"Glass", 1.5f }
    };


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ReflectRefractlLight(); // Does both Reflecting and Refracting
    }

    void ReflectRefractlLight()
    {
        ray = new Ray(transform.position, transform.forward); // Create new ray from start point object
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position); // set default position for line renderer
        float remainLenght = defualtLength;

        for (int i = 0; i < numOfReflectionRefraction; i++) // only accont for the desribed amount of interactions
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainLenght, layerMask)) // origin = line start point, direction = line draw direction, hit = any object line collides with based on layermasks
            {
                lineRenderer.positionCount += 1; 
                lineRenderer.SetPosition(lineRenderer.positionCount-1, hit.point); // add hit point to new ray start position
                if (hit.transform.tag == "Mirror") // reflect the ray
                {
                    remainLenght -= Vector3.Distance(ray.origin, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                }
                else if(hit.transform.tag == "Refract") // refract the ray
                {   
                    // get position slightly in cube
                    Vector3 newPos1 = new Vector3(Mathf.Abs(ray.direction.x) / (ray.direction.x + 0.0001f) * 0.001f + hit.point.x, Mathf.Abs(ray.direction.y) / (ray.direction.y + 0.0001f) * 0.001f + hit.point.y, Mathf.Abs(ray.direction.z) / (ray.direction.z + 0.0001f) * 0.001f + hit.point.z); 

                    // get Refractive index
                    float n1 = refractiveMaterials["Air"];
                    float n2 = refractiveMaterials["Glass"];

                    Vector3 norm = hit.normal; // normal of object
                    Vector3 incident = ray.direction; // ray direction

                    Vector3 refractedVector = Refract(n1, n2, norm, incident);
                    
                    // cast first ray that is inside the cube
                    ray = new Ray(newPos1, refractedVector);
                    
                    // now cast second ray to find the exit point for the inside ray
                    Vector3 newRayStartPos = ray.GetPoint(0.3f);
                    Ray ray2 = new Ray(newRayStartPos, -refractedVector);

                    RaycastHit hit2;

                    if (Physics.Raycast(ray2, out hit2, 0.3f, layerMaskRefract)) // this will draw an invisable line that will strike the cube to find the outter point the interior ray will exit from
                    {
                        lineRenderer.positionCount += 1;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit2.point);
                        
                    }

                    // get refraction of ray when ray exits cube
                    Vector3 refractedVector2 = Refract(n2, n1, -hit2.normal, refractedVector);
                    if (refractedVector2.x == 0 && refractedVector2.y == 0 && refractedVector2.z == 0) // must check if vector is 0, if it is we need to internally reflect
                    {
                        ray = new Ray(hit2.point, Vector3.Reflect(ray.direction, hit2.normal)); // cast second inside ray that reflected
                        newRayStartPos = ray.GetPoint(0.3f); // find new extior point to cast invisable ray towards the cube to find outside point of the cube
                        Ray ray3 = new Ray(newRayStartPos, -ray.direction); // cast invisable ray towards the cube

                        RaycastHit hit3;

                        if (Physics.Raycast(ray3, out hit3, 0.3f, layerMaskRefract)) // get hit point and start refraction leaving the cube
                        {
                            lineRenderer.positionCount += 1;
                            lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit3.point);

                        }
                        Vector3 refractedVector3 = Refract(n2, n1, -hit3.normal, ray.direction);
                        ray = new Ray(hit3.point, refractedVector3); // cast new ray that leaves the cube
                    }
                    else // vector was non-zero thus no internal reflection needed
                    {
                        ray = new Ray(hit2.point, refractedVector2); // cast new ray that leaves the cube
                    }
                }
                if (hit.transform.tag == "Target") // if target change the colour
                {
                    hit.transform.GetComponent<Renderer>().material.color = Color.green;
                }

            }
            else // nothing in rays path
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + (ray.direction * remainLenght));
            }
            
        }
    }

    public static Vector3 Refract(float RI1, float RI2, Vector3 surfNorm, Vector3 incident)
    {
        //RI1 is refractive index of the current medium that the line is in and RI2 is the entering medium's refractive index.
        //Need to preform Vector/Matrix calucation to get proper refraction as unity cannot get angles.

        surfNorm.Normalize(); //should already be normalized, but normalize just to be sure
        incident.Normalize();

        return (RI1 / RI2 * Vector3.Cross(surfNorm, Vector3.Cross(-surfNorm, incident)) - surfNorm * Mathf.Sqrt(1 - Vector3.Dot(Vector3.Cross(surfNorm, incident) * (RI1 / RI2 * RI1 / RI2), Vector3.Cross(surfNorm, incident)))).normalized;
    }
}
