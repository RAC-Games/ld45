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
    bool loadCircle = false;
    void Update()
    {
        if (loadCircle)
        {
            if (1 - image.fillAmount > Time.deltaTime)
            {
                image.fillAmount += Time.deltaTime;
            }
            if (image.fillAmount > 0.9)
            {
                loadCircle = false;
                timer_is_running = true;
                image.fillAmount = 1;
            }
        }
        if (timer_is_running == true)
        {
            image.fillAmount = 1 - (timer / Maxzeit);
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
        timer_is_running = false;
        loadCircle = true;
        timer = 0;

    }
    public void close_door()
    {
        animator.SetTrigger("Door_close");
    }

    public void open_door()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Door_open"))
        {
        animator.SetTrigger("Door_open");
        }
    }

}