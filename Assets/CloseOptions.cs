using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOptions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Close()
    {
        GameObject.Find("PauseScreen").SetActive(false);
        GameObject.Find("StartScreen").SetActive(true);
    }
}
