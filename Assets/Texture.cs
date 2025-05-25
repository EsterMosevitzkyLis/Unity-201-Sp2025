using UnityEngine;

public class TextureSwitcher : MonoBehaviour
{
    public Material targetMaterial;
    public string texturePropertyName = "_BaseMap"; // or the name from your Shader Graph

    public void SetTexture(Texture texture)
    {
        if (targetMaterial != null && texture != null)
        {
            targetMaterial.SetTexture(texturePropertyName, texture);
        }
    }
}
