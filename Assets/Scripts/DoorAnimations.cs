using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimations : MonoBehaviour, IDoor
{
    [SerializeField] private Animator doorAnim;

    private void Awake()
    {
        doorAnim = GetComponent<Animator>();
        CloseDoor();
    }

    public void OpenDoor()
    {
        doorAnim.SetBool("isEntering", true);
    }

    public void CloseDoor()
    {
        doorAnim.SetBool("isEntering", false);
    }
}
