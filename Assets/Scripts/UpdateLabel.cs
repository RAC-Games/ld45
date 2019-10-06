using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLabel : MonoBehaviour
{
    InputField input;
    private void Start()
    {
        input = GetComponent<InputField>();
    }
    public void SetLabel(float value)
    {
        input.text = value.ToString("###.#");
    }
}
