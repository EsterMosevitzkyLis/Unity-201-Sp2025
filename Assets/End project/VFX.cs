using UnityEngine;
using UnityEngine.VFX;

public class VFXOnClick : MonoBehaviour
{
    // Name must match the Event Name in your VFX Graph
    [Tooltip("Simple Burst")]
    public string vfxEventName = "PlayEffect";

    private VisualEffect vfx;

    void Awake()
    {
        vfx = GetComponent<VisualEffect>();
        if (vfx == null)
            Debug.LogError("No VisualEffect component found on " + gameObject.name);
    }

    void OnMouseDown()
    {
        // Sends the event to the VFX Graph
        vfx.SendEvent(vfxEventName);
    }
}
