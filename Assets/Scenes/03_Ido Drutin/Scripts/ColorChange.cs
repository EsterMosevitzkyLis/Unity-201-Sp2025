using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    [Header("UI Car Images (center display)")]
    public Image centerCar1;
    public Image centerCar2;

    private Image activeCar;

    [Header("Top Preview Car Images (optional)")]
    public Image car1Indicator;
    public Image car2Indicator;

    private void Start()
    {
        // Start with car 1 active
        centerCar1.gameObject.SetActive(true);
        centerCar2.gameObject.SetActive(false);
        activeCar = centerCar1;

        UpdateIndicators();
    }

    // Call this from your "Switch Car" button
    public void ToggleCar()
    {
        bool isCurrentlyCar1 = activeCar == centerCar1;

        centerCar1.gameObject.SetActive(!isCurrentlyCar1);
        centerCar2.gameObject.SetActive(isCurrentlyCar1);

        activeCar = isCurrentlyCar1 ? centerCar2 : centerCar1;

        UpdateIndicators();
    }

    private void UpdateIndicators()
    {
        if (car1Indicator != null)
            car1Indicator.color = (activeCar == centerCar1) ? Color.white : Color.gray;

        if (car2Indicator != null)
            car2Indicator.color = (activeCar == centerCar2) ? Color.white : Color.gray;
    }

    // === WINDOW COLOR METHODS ===
    public void SetWindowRed() => SetWindowColor(Color.red);
    public void SetWindowGreen() => SetWindowColor(Color.green);
    public void SetWindowBlue() => SetWindowColor(Color.blue);
    public void SetWindowYellow() => SetWindowColor(Color.yellow);
    public void SetWindowPink() => SetWindowColor(new Color(1f, 0.4f, 0.7f));

    // === WHEEL COLOR METHODS ===
    public void SetWheelRed() => SetWheelColor(Color.red);
    public void SetWheelGreen() => SetWheelColor(Color.green);
    public void SetWheelBlue() => SetWheelColor(Color.blue);
    public void SetWheelYellow() => SetWheelColor(Color.yellow);
    public void SetWheelGray() => SetWheelColor(Color.gray);

    // === CORE COLOR FUNCTIONS ===
    private void SetWindowColor(Color color)
    {
        if (activeCar != null && activeCar.material != null)
        {
            activeCar.material.SetColor("_Window", color);
        }
    }

    private void SetWheelColor(Color color)
    {
        if (activeCar != null && activeCar.material != null)
        {
            activeCar.material.SetColor("_Wheel", color);
        }
    }
}
