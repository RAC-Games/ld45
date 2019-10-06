using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    GameObject player;
    [Curve(1, 1, 3, 0, true)]

    [SerializeField]
    AnimationCurve transparencyCurve;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        float alpha = transparencyCurve.Evaluate(distance);
        print(distance);
        Color c = textMesh.color;
        c.a = alpha ;
        textMesh.color = c;
    }
}
