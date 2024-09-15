using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;

    private void Awake()
    {
        doorAnim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        doorAnim.Play("DoorOpen");
    }
}
