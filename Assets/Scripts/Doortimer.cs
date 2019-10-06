using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doortimer : MonoBehaviour
{
    public float timer = 0;
    public float Maxzeit;
    public bool timer_is_running = false;
    private Animator animator;
    public Image image;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (timer_is_running == true)
        {
            image.fillAmount = 1-(timer / Maxzeit);
            timer += Time.deltaTime;
            if (timer > Maxzeit)
            {
                close_door();
                timer_is_running = false;
            }
        }
    }

    public void starttimer()
    {
        timer = 0;
        timer_is_running = true;
        image.fillAmount = 1;
    }
    public void close_door()
    {
        animator.SetTrigger("Door_close");
    }

    public void open_door()
    {
        animator.SetTrigger("Door_open");
    }

}