using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public DoorController doorController;
    private Animator animator;
    public Material disabledMaterial;
    public Material enabledMaterial;
    private MeshRenderer meshRenderer;
    public bool isActive = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = disabledMaterial;
    }

    public void Activate()
    {
        meshRenderer.material = enabledMaterial;
        isActive = true;
    }

    public void Press()
    {
        if (isActive)
        {
            //Debug.Log("Pressing button!");
            doorController.isDoorLocked = false;
            doorController.LiftButtonPress();
            animator.SetTrigger("isPressed");
        }

        //animator.ResetTrigger("isPressed");
    }
}
