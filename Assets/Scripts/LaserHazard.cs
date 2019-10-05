using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserHazard : MonoBehaviour {

    BoxCollider collider;
    RayCastPoints raycastpoints;
    public float laserRotationSpeed;
    public float rayLength;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
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
