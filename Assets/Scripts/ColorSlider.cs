using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI valueText;
    
    private void Start()
    {
        slider.onValueChanged.AddListener(UpdateValueAndColor);
        UpdateValueAndColor(slider.value);
    }

    private void UpdateValueAndColor(float value)
    {
        int intValue = Mathf.RoundToInt(value);

        // Update Text
        valueText.text = intValue.ToString();

        // Update Color
        if (intValue >= 0 && intValue <= 6)
            valueText.color = Color.blue;
        else if (intValue >= 7 && intValue <= 18)
            valueText.color = Color.yellow;
        else if (intValue >= 19 && intValue <= 42)
            valueText.color = new Color(1, 0.5f, 0); // This is the RGB value for Orange
        else if (intValue == 43)
            valueText.color = Color.red;
    }
}
