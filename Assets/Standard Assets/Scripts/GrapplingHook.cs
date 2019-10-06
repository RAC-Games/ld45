using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class GrapplingHook : MonoBehaviour
{

    [SerializeField] float grapplingSpeed;
    [SerializeField] GameObject hitMarker;
    Vector3 grapplingTarget;
    bool hasTarget;
    CharacterController characterController;
    LineRenderer lineRenderer;
    GameObject hook;
    
    public GameObject Anchor;


    Vector3 A;
    Vector3 B;
    public int ShootSpeed;
    List<Vector3> SineLine;
    public float sineMagnitute = 0.2f;
    public int Resolution = 200;
    public float WaveScale = 100f;
    Vector3 dir;
    float forward;
    float distance;
    Vector3 perpendicular;

    Vector3 nextPos;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            ShootHook();
        }
        if (!CrossPlatformInputManager.GetButton("Fire1"))
        {
            ReleaseHook();
        }
    }

    void ReleaseHook()
    {
        hasTarget = false;
        shouldMove = false;
        lineRenderer.positionCount = 0;
        if (hook != null)
        {
            Destroy(hook);
            Anchor.SetActive(true);
        }
    }
    bool shouldMove = false;

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            GrapplingHookUpdate();
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(Camera.main.transform.position, hit.point);
    //}
    RaycastHit hit;
    void ShootHook()
    {
        
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            grapplingTarget = hit.point;
            hasTarget = true;
            GenerateLine();
            drawLine();
            hook = Instantiate(hitMarker, grapplingTarget, Camera.main.transform.rotation);
            Anchor.SetActive(false);
        }
    }
    async void drawLine()
    {
        Vector3 pos;
        for (int i = 0; i < Resolution; i++)
        {
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i, SineLine[i]);
        }
        await Task.Delay(ShootSpeed);
        shouldMove = true;
    }
    void GrapplingHookUpdate()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Anchor.transform.position);
        lineRenderer.SetPosition(1, grapplingTarget);

        if (TravelAfterShoot) characterController.Move((grapplingTarget - transform.position).normalized * grapplingSpeed);
    }
    public bool TravelAfterShoot;

    private void GenerateLine()
    {

        B = grapplingTarget;
        A = Anchor.transform.position;


        distance = (B - A).magnitude;
        SineLine = new List<Vector3>();
        SineLine.Add(A);
        for (int i = 1; i < Resolution; i++)
        {
            dir = i * (B - A) / Resolution;

            forward = dir.magnitude / distance;


            perpendicular = new Vector3(dir.z / dir.magnitude, 0, -dir.x / dir.magnitude);
            nextPos = A + dir + perpendicular * sineMagnitute * Mathf.Sin(forward * WaveScale);

            SineLine.Add(nextPos);
        }
    }
  

}
