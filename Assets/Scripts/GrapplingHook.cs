﻿using System.Collections;
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
        if (CrossPlatformInputManager.GetButtonUp("Fire1") && hasTarget)
        {
            ReleaseHook();
        }
    }

    void ReleaseHook()
    {
        hasTarget = false;
        lineRenderer.positionCount = 0;
    }

    private void FixedUpdate()
    {
        if (hasTarget)
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
        }
    }

    void GrapplingHookUpdate()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position + transform.right * 0.25f + transform.up * -0.1f);
        lineRenderer.SetPosition(1, grapplingTarget);
        characterController.Move((grapplingTarget - transform.position).normalized * grapplingSpeed);
    }
}