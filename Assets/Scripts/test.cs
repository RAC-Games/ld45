using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [Curve(0, 0, 3f, 5f, true)]
    public AnimationCurve curveX;

    [Curve(0, 0f, 3f, 5f, true)]
    public AnimationCurve curveY;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        print(Time.time);
        transform.position = new Vector3(curveX.Evaluate(Time.time), curveY.Evaluate(Time.time), 0);
    }
}
