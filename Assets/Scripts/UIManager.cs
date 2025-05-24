using UnityEngine;
using Color = System.Drawing.Color;

public class UIManager : MonoBehaviour
{
    public SpriteRenderer SpriteInst1;
    public SpriteRenderer SpriteInst2;

    private Material shaderMat;
    void Start()
    {
        shaderMat = SpriteInst1.material;
    }

    public void SetBodyColor(int num)
    {
        switch (num)
        {
            case 0:
                shaderMat.SetColor("_BodyColor", UnityEngine.Color.blue);
                break;
            case 1:
                shaderMat.SetColor("_BodyColor", UnityEngine.Color.red);
                break;
            case 2:
                shaderMat.SetColor("_BodyColor", UnityEngine.Color.green);
                break;
            case 3:
                shaderMat.SetColor("_BodyColor", UnityEngine.Color.yellow);
                break;
        }
    }
    public void SetWindowColor(int num)
    {
        switch (num)
        {
            case 0:
                shaderMat.SetColor("_Window_LightsColor", UnityEngine.Color.blue);
                break;
            case 1:
                shaderMat.SetColor("_Window_LightsColor", UnityEngine.Color.red);
                break;
            case 2:
                shaderMat.SetColor("_Window_LightsColor", UnityEngine.Color.green);
                break;
            case 3:
                shaderMat.SetColor("_Window_LightsColor", UnityEngine.Color.yellow);
                break;
        }
    }

    public void SwapMat(int num)
    {
        if (num == 0)
        {
            shaderMat = SpriteInst2.material;
        }
        else
        {
            shaderMat = SpriteInst1.material;
        }
    }
}
