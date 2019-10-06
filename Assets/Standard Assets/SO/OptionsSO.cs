using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Options", menuName = "Options", order = 1)]
public class OptionsSO : ScriptableObject
{
    [SerializeField] private float _mouseSensitivity = 2;
    [SerializeField] private float _volume = 50;
    [SerializeField] private float _fieldOfView = 60;

    public float MouseSensitivity
    {
        get => _mouseSensitivity;
        set
        {
            _mouseSensitivity = value;
            OnMouseSensitivityChanged.Invoke();
        }
    }

    public float Volume
    {
        get => _volume;
        set
        {
            _volume = value;
            OnVolumeChanged.Invoke();
        }
    }

    public float FieldOfView
    {
        get => _fieldOfView;
        set
        {
            _fieldOfView = value;
            OnFieldOfViewChanged.Invoke();
        }
    }

    public void SetVolume(float vol)
    {
        Volume = vol;
    }

    public void SetMouseSensitivity(float ms)
    {
        MouseSensitivity = ms;
    }

    public void SetFieldOfView(float fov)
    {
        FieldOfView = fov;
    }

    private void Awake()
    {

    }

    public UnityEvent OnMouseSensitivityChanged = new UnityEvent();
    public UnityEvent OnFieldOfViewChanged = new UnityEvent();
    public UnityEvent OnVolumeChanged = new UnityEvent();
}