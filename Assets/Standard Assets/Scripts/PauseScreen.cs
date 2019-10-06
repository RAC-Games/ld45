using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseScreen : MonoBehaviour
{
    bool pausedPressed;
    bool paused;

    public GameObject PauseScreenUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pausedPressed = CrossPlatformInputManager.GetButtonDown("Cancel");
        if (pausedPressed && !paused)
        {
            paused = true;
            var FPC = GetComponent<FirstPersonController>();
            FPC.m_MouseLook.SetCursorLock(false);
            FPC.paused = true;
            GetComponent<GrapplingHook>().enabled = false;
            GetComponent<PickUp>().enabled = false;
            PauseScreenUI.SetActive(true);
            return;
        }

        if (paused && pausedPressed)
        {
            DisablePause();
        }
    }

    public void DisablePause()
    {
        paused = false;
        var FPC = GetComponent<FirstPersonController>();
        FPC.paused = false;
        FPC.m_MouseLook.SetCursorLock(true);
        GetComponent<GrapplingHook>().enabled = true;
        GetComponent<PickUp>().enabled = true;
        PauseScreenUI.SetActive(false);
    }
}
