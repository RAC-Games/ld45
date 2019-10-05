using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOptions : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject StartScreen;
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
        PauseScreen.SetActive(false);
        StartScreen.SetActive(true);
    }
}
