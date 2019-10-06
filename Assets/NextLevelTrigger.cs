using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NextLevelTrigger : MonoBehaviour
{
    public LevelChanger lvlChanger;
    // Start is called before the first frame update
    void Start()
    {
        lvlChanger = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LevelChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        lvlChanger.FadeToNextScene();
    }
}
