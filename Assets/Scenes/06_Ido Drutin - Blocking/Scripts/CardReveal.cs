using UnityEngine;
using UnityEngine.UI;

public class CardReveal : MonoBehaviour
{
    private Animation anim;
    private bool hasRevealed = false;

    void Awake()
    {
        anim = GetComponent<Animation>();

        Button btn = GetComponent<Button>();
        if (btn != null)
            btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (hasRevealed) return;

        hasRevealed = true;

        // Play Reveal animation
        anim.Play("Reveal");

        // After Reveal ends, play IdleColor
        StartCoroutine(WaitAndPlayIdleColor(anim["Reveal"].length));
    }

    private System.Collections.IEnumerator WaitAndPlayIdleColor(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.Play("IdleColor");
    }
}
