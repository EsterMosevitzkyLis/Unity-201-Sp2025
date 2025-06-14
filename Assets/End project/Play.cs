using UnityEngine;

public class HoverAndClickAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isMouseOver = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
        animator.SetTrigger("HoverIn");
    }

    void OnMouseExit()
    {
        isMouseOver = false;
        animator.SetTrigger("HoverOut");
    }

    void OnMouseDown()
    {
        animator.SetTrigger("Play");
    }
}
