using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class LaserHazard : MonoBehaviour {

    private BoxCollider collider;

    private FirstPersonController controller;
    private RayCastPoints raycastpoints;
    public float laserRotationSpeed;
    public float rayLength;
    public List<drawLine> lineRenderers = new List<drawLine>();


    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }
    
    private void Update()
    {
        shootRays();
        
    }
        
    private void shootRays() 
    {
        transform.Rotate(0, 0, Time.deltaTime * laserRotationSpeed);
        
        GetRaycastPoints();
        Vector3[] rayCastPointsDirections = { (transform.up - transform.right).normalized, (transform.up + transform.right).normalized, (-transform.up - transform.right).normalized, (-transform.up + transform.right).normalized };
        for (int i = 0; i < 4; i++)
        {
            lineRenderers[i].origin = transform.position;
            Debug.DrawRay(transform.position , rayCastPointsDirections[i].normalized * rayLength, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(transform.position , rayCastPointsDirections[i].normalized, out hit, rayLength))
            {
                
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    controller = hit.collider.GetComponent<FirstPersonController>();
                    controller.Death();
                }
            }
            if (hit.point != Vector3.zero)
            {
                lineRenderers[i].destination = hit.point;
            }
            else
            { 
                lineRenderers[i].destination = transform.position + rayCastPointsDirections[i].normalized * rayLength;
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
