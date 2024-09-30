using UnityEngine;
using TMPro;

public class PlayerTutorialTextOverlay : MonoBehaviour
{
    [Header("Player Tutorial Properties")]
    [SerializeField] private TextMeshProUGUI tutorialText;
    [HideInInspector] public TextMeshProUGUI TutorialText => tutorialText;

    public void InteractWithObject()
    {
        tutorialText.text = "Press E or click left mouse button to interact";
    }

    public void Crouch()
    {
        tutorialText.text = "Press left shift to crouch";
    }

    public void GrabCartridge()
    {
        tutorialText.text = "You'll need to find a console to play this on.\nMaybe there's one nearby...";
    }

    public void Jump()
    {
        tutorialText.text = "Press space to jump, WASD to move, mouse to look around";
    }
}
