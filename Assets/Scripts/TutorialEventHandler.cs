using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TutorialEventHandler : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private UnityEvent onTutorialTrigger;
    [SerializeField] private Animator textAnimation;
    public bool hasEntered = false;

    public UnityEvent OnTutorialTrigger => onTutorialTrigger;

    private void Awake()
    {
        textAnimation = FindObjectOfType<PlayerTutorialTextOverlay>().GetComponent<PlayerTutorialTextOverlay>().TutorialText.GetComponent<Animator>();
    }

    // Tutorial text only fires once
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasEntered)
        {
            onTutorialTrigger?.Invoke();
            TextFadeIn();
            hasEntered = true;
        }
    }

    public void TextFadeIn()
    {
        textAnimation.ResetTrigger("hasEnteredTrigger");
        textAnimation.SetTrigger("hasEnteredTrigger");
    }
}
