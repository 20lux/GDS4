using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public DoorController doorController;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Press()
    {
        animator.SetTrigger("isPressed");
        doorController.LiftButtonPress();
        animator.ResetTrigger("IsPressed");
    }
}
