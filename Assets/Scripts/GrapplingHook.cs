﻿using System.Collections;
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
    // Start is called before the first frame update
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
    }
    bool shouldMove = false;

    private void FixedUpdate()
    {
        if (shouldMove)
        {
            GrapplingHookUpdate();
        }
    }


    void ShootHook()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit))
        {
            grapplingTarget = hit.point;
            hasTarget = true;
            GameObject.Instantiate(hitMarker, grapplingTarget, Quaternion.identity);
            GenerateLine();
            drawLine();
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
        lineRenderer.SetPosition(0, transform.position + transform.right * 0.25f + transform.up * -0.1f);
        lineRenderer.SetPosition(1, grapplingTarget);

        characterController.Move((grapplingTarget - transform.position).normalized * grapplingSpeed);
    }
    void GrapplingHookRollback() { }

    private void GenerateLine()
    {

        B = grapplingTarget;
        A = transform.position + transform.right * 0.25f + transform.up * -0.1f;


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

}
