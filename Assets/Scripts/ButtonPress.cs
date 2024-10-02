using UnityEngine.Events;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    private Animator animator;
    public Material disabledMaterial;
    public Material enabledMaterial;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;
    public AudioClip lockedAudio;
    public bool isActive = false;
    public UnityEvent onButtonPress;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = disabledMaterial;
    }

    void Start()
    {
        // Change button to green if button is active
        // without need to Activate()
        if (isActive)
        {
            meshRenderer.material = enabledMaterial;
        }
    }


    // Used for engine startup
    public void Activate()
    {
        meshRenderer.material = enabledMaterial;
        isActive = true;
    }

    public void Press()
    {
        if (isActive)
        {
            onButtonPress?.Invoke();
        }
        else
        {
            audioSource.clip = lockedAudio;
            audioSource.Play();
        }

        animator.SetTrigger("isPressed");
    }
}
