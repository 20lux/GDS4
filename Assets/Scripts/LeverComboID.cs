using UnityEngine;

public class LeverComboID : MonoBehaviour
{
    public int leverID = 0;
    public GameObject consolePart;
    public AudioSource leverAudioSource;
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
        leverAudioSource.Play();
        
        if (leverAnimator.GetBool("PullUp"))
        {
            leverAnimator.SetBool("PullUp", false);
        }
        else
        {
            leverAnimator.SetBool("PullUp", true);
        }

        leverComboCheck.leverCombination += leverID;
        consolePart.GetComponent<Renderer>().material = consolePartMaterial;
    }

    public void ResetConsolePart()
    {
        leverAnimator.SetBool("PullUp", false);
        consolePart.GetComponent<Renderer>().material = defaultMaterial;
    }
}
