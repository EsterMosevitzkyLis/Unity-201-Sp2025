using UnityEngine;

public class ExposeVars : MonoBehaviour
{
    public Material uiMaterial;
    [Range(0f, 1f)] public float Fade = 1f;
    [Range(0f, 1f)] public float Step = 0f;
    [Range(0f, 6f)] public float Add = 0f;

    void Update()
    {
        if (uiMaterial != null)
        {
            uiMaterial.SetFloat("_Fade", Fade);
            uiMaterial.SetFloat("_Appearance_Step", Step);
            uiMaterial.SetFloat("_AppearAdd", Add);
        }
    }
}
