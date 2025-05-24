using UnityEngine;

public class CarCustomizer : MonoBehaviour
{
    public SpriteRenderer carRenderer;

    private MaterialPropertyBlock block;

    void Start()
    {
        block = new MaterialPropertyBlock();
        carRenderer.GetPropertyBlock(block);

        // Optional: set default colors
        block.SetColor("_Color1", Color.red);   // body
        block.SetColor("_Color2", Color.green); // wheels
        carRenderer.SetPropertyBlock(block);
    }

    public void SetBodyColor(Color color)
    {
        carRenderer.GetPropertyBlock(block);
        block.SetColor("_Color1", color);
        carRenderer.SetPropertyBlock(block);
    }

    public void SetWheelColor(Color color)
    {
        carRenderer.GetPropertyBlock(block);
        block.SetColor("_Color2", color);
        carRenderer.SetPropertyBlock(block);
    }
}
