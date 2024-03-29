﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int sceneToLoad;


    public void FadeToScene(int sceneIndex)
    {
        sceneToLoad = sceneIndex;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextScene()
    {
        FadeToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartScene()
    {
        FadeToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif

    }
}
