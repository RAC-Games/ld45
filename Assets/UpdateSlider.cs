using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSlider : MonoBehaviour
{
    private Slider slider;
    private InputField input;
    private void Start()
    {
        slider = GetComponent<Slider>();
        input = GetComponentInChildren<InputField>();
    }
    // Start is called before the first frame update
    public void UpdateValue(string value)
    {
        try
        {
            var floatVal = float.Parse(value);
            if (floatVal >= slider.minValue && floatVal <= slider.maxValue)
            {
                slider.value = floatVal;
            }
            else { throw new System.Exception(); }
        }
        catch (System.Exception)
        {
            input.text = slider.value.ToString("###.#");
        }

    }
}
