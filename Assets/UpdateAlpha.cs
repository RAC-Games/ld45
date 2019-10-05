using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAlpha : MonoBehaviour
{

    CanvasGroup cg;
    // Start is called before the first frame update
    void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }
    float timer = -1;
    public void Hide()
    {
        cg.alpha = 0.1f;
        timer = 1;

    }
    private void Update()
    {
        if (timer < 0)
        {
            cg.alpha = 1;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
