using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class drawLine : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private float counter;
    private float distance;

    public Vector3 origin;
    public Vector3 destination;
    public float width = 0.5f;

    public float lineDrawSpeed = 0.18f;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    { 

        lineRenderer.SetPosition(0, origin);
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        
        lineRenderer.SetPosition(1, destination);
        
    }
}
