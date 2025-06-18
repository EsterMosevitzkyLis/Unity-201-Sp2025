using UnityEngine;
using UnityEngine.UI;
public class CardAlpha : MonoBehaviour
{
    public float alphaThreshold = 0.5f;

    void Awake()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (var img in images)
        {
            img.alphaHitTestMinimumThreshold = alphaThreshold;
        }
    }
}

