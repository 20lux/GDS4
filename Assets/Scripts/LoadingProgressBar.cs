using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = transform.GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = Loader.GetLoadingProgress();
    }
}
