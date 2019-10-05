using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class drawLine : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private float counter;
    private float distance;

    public Transform origin;
    public Transform destination;
    public float width = 0.5f;

    public float lineDrawSpeed = 0.18f;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
        distance = Vector3.Distance(origin.position, destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(counter < distance)
        {
            counter += .1f * lineDrawSpeed;
            float lerp = Mathf.Lerp(0, distance, counter);
            Vector3 pointOnLine = lerp * Vector3.Normalize(destination.position - origin.position) + origin.position;
            lineRenderer.SetPosition(1, pointOnLine);
        }
    }
}
