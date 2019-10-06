using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Unlocks", menuName = "Unlocks", order = 1)]
public class UnlocksSO : ScriptableObject
{
    [SerializeField] private bool _grapplingHook = false;
    [SerializeField] private bool _doubleJump = false;

    public bool GrapplingHook
    {
        get => _grapplingHook;
        set
        {
            _grapplingHook = value;
            OnGrapplingHookChanged.Invoke();
        }
    }
    public bool DoubleJump
    {
        get => _doubleJump;
        set
        {
            _doubleJump = value;
            OnDoubleJumpChanged.Invoke();
        }
    }
    public void SetGrapplingHook(bool gh)
    {
        GrapplingHook = gh;
    }

    public void SetDoubleJump(bool dj)
    {
        DoubleJump = dj;
    }
    public UnityEvent OnGrapplingHookChanged = new UnityEvent();
    public UnityEvent OnDoubleJumpChanged = new UnityEvent();
}