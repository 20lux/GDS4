using UnityEngine.UI;
using UnityEngine;

public class HighlightObjectController : MonoBehaviour
{
    public Image crosshair;

    void Awake()
    {
        crosshair.gameObject.SetActive(true);
        crosshair.color = Color.grey;
    }

    public void CrosshairInactive()
    {
        crosshair.gameObject.SetActive(true);
        crosshair.color = Color.grey;
    }

    public void CrosshairActive()
    {
        crosshair.gameObject.SetActive(true);
        crosshair.color = Color.white;
    }
}
