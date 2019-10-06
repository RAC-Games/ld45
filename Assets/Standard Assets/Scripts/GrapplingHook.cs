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
    public GameObject Harpoon;


    Vector3 A;
    Vector3 B;
    public float FlyDuration;
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
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && !pullingBack)
        {
            ShootHook();
        }
        if (!CrossPlatformInputManager.GetButton("Fire1") && hasTarget)
        {
            ReleaseHook();
        }
    }

    void ReleaseHook()
    {
        if (drawing!=null)
        {

        StopCoroutine(drawing);
        }
        hasTarget = false;
        pullingBack = true;
        StartCoroutine(RemoveLine());

    }
    bool pullingBack = false;
    bool shouldMove = false;

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            GrapplingHookUpdate();
        }
    }

    
    RaycastHit hit;
    Coroutine drawing;
    void ShootHook()
    {

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            grapplingTarget = hit.point;
            hasTarget = true;
            GenerateLine();
            hook = Instantiate(hitMarker, Anchor.transform.position, Camera.main.transform.rotation);
            drawing = StartCoroutine(drawLine());
            Harpoon.SetActive(false);
        }
    }
    float calcDistanceRatio()
    {
        float ratio = 0;

        if (distance < 10)
        {
            ratio = 0;
        }
        else if (distance >= 10)
        {
            ratio = Mathf.Lerp(0.1f, 1f, distance / 100);
        }

        return ratio;
    }
    IEnumerator drawLine()
    {
        float t = 0;
        float flyRatio = calcDistanceRatio();
        float time = FlyDuration* flyRatio;

        float ratio;
        int posCount;
        for (; t < time; t += Time.deltaTime)
        {
            ratio = t / time;
            for (int i = 0; i < Resolution * ratio; i++)
            {
                lineRenderer.positionCount = i + 1;
                lineRenderer.SetPosition(i, SineLine[i]);
            }
            posCount = lineRenderer.positionCount;
            if (posCount != 0)
            {

                hook.transform.position = lineRenderer.GetPosition(posCount - 1);
            }
            yield return null;
        }
        hook.transform.position = grapplingTarget;
        shouldMove = true;
    }

    IEnumerator RemoveLine()
    {
        float t = 0;
        float time = FlyDuration;
        int posCount;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, A);
        lineRenderer.SetPosition(1, B);

        Vector3 newpos;
        for (; t < time; t += Time.deltaTime)
        {
            newpos = Vector3.Lerp(A, B, 1 - (t / time));
            lineRenderer.SetPosition(1, newpos);
            posCount = lineRenderer.positionCount;

            hook.transform.position = newpos;

            yield return null;
        }
        shouldMove = false;
        lineRenderer.positionCount = 0;
        if (hook != null)
        {
            Destroy(hook);
            Harpoon.SetActive(true);
        }
        pullingBack = false;
    }

    void GrapplingHookUpdate()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Anchor.transform.position);
        lineRenderer.SetPosition(1, B);

        if (TravelAfterShoot) characterController.Move((B - transform.position).normalized * grapplingSpeed);
    }
    public bool TravelAfterShoot;

    private void GenerateLine()
    {

        B = grapplingTarget - Camera.main.transform.forward * 0.3f;
        A = Anchor.transform.position;

        distance = (B - A).magnitude;
        float WaveScaleCalc = Mathf.Lerp(100,70,distance / WaveScale);
        SineLine = new List<Vector3>();
        SineLine.Add(A);
        for (int i = 1; i < Resolution; i++)
        {
            dir = i * (B - A) / Resolution;

            forward = dir.magnitude / distance;


            perpendicular = new Vector3(dir.z / dir.magnitude, 0, -dir.x / dir.magnitude);
            nextPos = A + dir + perpendicular * sineMagnitute * Mathf.Sin(forward * WaveScaleCalc);

            SineLine.Add(nextPos);
        }
    }


}
