using UnityEngine.UI;
using UnityEngine;

public class HighlightObjectController : MonoBehaviour
{
    public Image inspectIcon;
    public Image handIcon;
    public Image lockIcon; 
    public Image crosshair;
    public float activeHighlightDistance = 8f;

    void Awake()
    {
        inspectIcon.gameObject.SetActive(false);
        handIcon.gameObject.SetActive(false);
        lockIcon.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(true);
        crosshair.color = Color.grey;
    }

    public void Inspect()
    {
        inspectIcon.gameObject.SetActive(true);
        handIcon.gameObject.SetActive(false);
        lockIcon.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(false);
    }

    public void Grab()
    {
        inspectIcon.gameObject.SetActive(false);
        handIcon.gameObject.SetActive(true);
        lockIcon.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(false);
    }

    public void Lock()
    {
        inspectIcon.gameObject.SetActive(false);
        handIcon.gameObject.SetActive(false);
        lockIcon.gameObject.SetActive(true);
        crosshair.gameObject.SetActive(false);
    }

    public void CrosshairInactive()
    {
        inspectIcon.gameObject.SetActive(false);
        handIcon.gameObject.SetActive(false);
        lockIcon.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(true);
        crosshair.color = Color.grey;
    }

    public void CrosshairActive()
    {
        inspectIcon.gameObject.SetActive(false);
        handIcon.gameObject.SetActive(false);
        lockIcon.gameObject.SetActive(false);
        crosshair.gameObject.SetActive(true);
        crosshair.color = Color.white;
    }
}
