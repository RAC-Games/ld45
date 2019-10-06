using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public OptionsSO Options;
    public UnlocksSO Unlocks;
    // Start is called before the first frame update
    void Start()
    {
        Options.MouseSensitivity = 2;
        Options.FieldOfView = 60;
        Options.Volume = 50;

        Unlocks.DoubleJump = false;
        Unlocks.GrapplingHook = false;
    }


}
