using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{

    [Header("Light Beam Settings")]
    public LayerMask layerMask;
    public float defualtLength = 50;
    public int numOfReflection = 10;

    private LineRenderer lineRenderer;
    private RaycastHit hit;

    private Ray ray;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ReflectlLight();
    }

    void ReflectlLight()
    {
        ray = new Ray(transform.position, transform.forward); // Create new ray from start point object
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        float remainLenght = defualtLength;

        for (int i = 0; i < numOfReflection; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainLenght, layerMask))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount-1, hit.point);
                if (hit.transform.tag == "Mirror")
                {
                    remainLenght -= Vector3.Distance(ray.origin, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                }
                if (hit.transform.tag == "Target")
                {
                    hit.transform.GetComponent<Renderer>().material.color = Color.green;
                }

            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + (ray.direction * remainLenght));
            }
            
        }
    }
    void NormalLight()
    {
        lineRenderer.SetPosition(0, transform.position);

        if (Physics.Raycast(transform.position, transform.forward, out hit, defualtLength, layerMask))
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position + (transform.forward * defualtLength));
        }
    }
}
