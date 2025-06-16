using UnityEngine;

public class PlayOnClick : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        animator.SetTrigger("Play");
    }
}