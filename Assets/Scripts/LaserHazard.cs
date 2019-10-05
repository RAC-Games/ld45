using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserHazard : MonoBehaviour {

    BoxCollider collider;
    /*LineRenderer lineRenderer1;
    LineRenderer lineRenderer2;
    LineRenderer lineRenderer3;
    LineRenderer lineRenderer4;*/
    RayCastPoints raycastpoints;
    public float laserRotationSpeed;
    public float rayLength;
    /*public GameObject CornerLaser1;
    public GameObject CornerLaser2;
    public GameObject CornerLaser3;
    public GameObject CornerLaser4;
    private LineRenderer[] lines;
    LineRenderer lineRenderer;*/
    //public GameObject Laser1;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        //lineRenderer = Laser1.GetComponent<LineRenderer>();
        /*lineRenderer1 = CornerLaser1.GetComponent<LineRenderer>();
        lineRenderer1.positionCount = 2;
        lineRenderer2 = CornerLaser2.GetComponent<LineRenderer>();
        lineRenderer2.positionCount = 2;
        lineRenderer3 = CornerLaser3.GetComponent<LineRenderer>();
        lineRenderer3.positionCount = 2;
        lineRenderer4 = CornerLaser4.GetComponent<LineRenderer>();
        lineRenderer4.positionCount = 2;
        lines[0] = lineRenderer1;
        lines[1] = lineRenderer2;
        lines[2] = lineRenderer3;
        lines[3] = lineRenderer4;*/
    }
    
    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * laserRotationSpeed);
        //Quaternion cubeRotation = transform.rotation;
        GetRaycastPoints();
        //Vector3[] rayCastPoints2 = { raycastpoints.topLeft, raycastpoints.topRight, raycastpoints.bottomLeft, raycastpoints.bottomRight };
        Vector3[] rayCastPointsDirections = { (transform.up - transform.right).normalized, (transform.up + transform.right).normalized, (-transform.up - transform.right).normalized, (-transform.up + transform.right).normalized };
        for (int i = 0; i < 4; i++)
        {
            Debug.DrawRay(transform.position /*rayCastPoints2[i]*/, rayCastPointsDirections[i].normalized * rayLength, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(transform.position /*rayCastPoints2[i]*/, rayCastPointsDirections[i].normalized, out hit, rayLength))
            {
                //lineRenderer.SetPosition(0, transform.position);
                //lineRenderer.SetPosition(1, hit.point);
                /*lines[i].SetPosition(0, transform.position);
                lines[i].SetPosition(1, hit.point);*/
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    //Insert Death Consequences
                    print("hit");
                    //Destroy(hit.collider.gameObject);
                }
            }
        }
    }
        
    private void GetRaycastPoints()
    {
        Bounds bounds = collider.bounds;

        raycastpoints.topLeft = new Vector3(bounds.min.x,bounds.max.y,(bounds.min.z + bounds.max.z) / 2);
        raycastpoints.topRight = new Vector3(bounds.max.x, bounds.max.y, (bounds.min.z + bounds.max.z) / 2);
        raycastpoints.bottomLeft = new Vector3(bounds.min.x, bounds.min.y, (bounds.min.z + bounds.max.z) / 2);
        raycastpoints.bottomRight = new Vector3(bounds.max.x, bounds.min.y, (bounds.min.z + bounds.max.z) / 2);
    }

    struct RayCastPoints
    {
        public Vector3 topLeft, topRight;
        public Vector3 bottomLeft, bottomRight;
    }
}
