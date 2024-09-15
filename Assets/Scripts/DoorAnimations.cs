using UnityEngine;

public class DoorAnimations : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;

    private void Awake()
    {
        doorAnim = GetComponent<Animator>();
    }

    public void OpenAnimation()
    {
        doorAnim.SetBool("OpenDoor", true);
    }

    public void CloseAnimation()
    {
        doorAnim.SetBool("OpenDoor", false);
    }
}
