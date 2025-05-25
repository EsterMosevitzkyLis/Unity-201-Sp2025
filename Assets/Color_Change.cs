using UnityEngine;

public class CarColorChanger : MonoBehaviour
{
    public Material carMaterial;

    public void SetColor1Red()
    {
        carMaterial.SetColor("_Color1", Color.red);
    }

    public void SetColor1Blue()
    {
        carMaterial.SetColor("_Color1", Color.blue);
    }

    public void SetColor1Yellow()
    {
        carMaterial.SetColor("_Color1", Color.yellow);
    }

    public void SetColor1Green()
    {
        carMaterial.SetColor("_Color1", Color.green);
    }

    public void SetColor2Red()
    {
        carMaterial.SetColor("_Color2", Color.red);
    }

    public void SetColor2Yellow()
    {
        carMaterial.SetColor("_Color2", Color.yellow);
    }

    public void SetColor2Blue()
    {
        carMaterial.SetColor("_Color2", Color.blue);
    }

    public void SetColor2Green()
    {
        carMaterial.SetColor("_Color2", Color.green);
    }
}
