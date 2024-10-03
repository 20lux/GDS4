using UnityEngine;

public class LeverComboID : MonoBehaviour
{
    public int leverID = 0;
    public GameObject consolePart;
    public Material consolePartMaterial;
    public Material defaultMaterial;
    public LeverComboCheck leverComboCheck;
    public Animator leverAnimator;

    void Awake()
    {
        defaultMaterial = consolePart.GetComponent<Renderer>().material;
        leverAnimator = GetComponent<Animator>();
    }

    public void PullLever()
    {
        leverAnimator.SetBool("PullUp", true);
        leverComboCheck.leverCombination += leverID;
        consolePart.GetComponent<Renderer>().material = consolePartMaterial;
    }

    public void ResetConsolePart()
    {
        leverAnimator.SetBool("PullUp", false);
        consolePart.GetComponent<Renderer>().material = defaultMaterial;
    }
}
