using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TeleportShaderController : MonoBehaviour
{
    [Header("Time Stats")]
    [SerializeField] private float _teleportStartDisplayTime = 1.5f;
    [SerializeField] private float _teleportFadeOutTime = 0.5f;

    [Header("References")]
    [SerializeField] private ScriptableRendererFeature _fullScreenTeleportShader;
    [SerializeField] private Material _material;

    private int _voronoiIntensity = Shader.PropertyToID("_VoronoiIntensity");
    private int _vignetteIntensity = Shader.PropertyToID("_VignetteIntensity");

    private const float VORONOI_INTENSITY_START_AMOUNT = 1.25f;
    private const float VIGNETTE_INTENSITY_START_AMOUNT = 1.25f;

    private void Start()
    {
        _fullScreenTeleportShader.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            TeleportFade();
        }
    }

    private IEnumerator TeleportFade()
    {
        _fullScreenTeleportShader.SetActive(true);
        _material.SetFloat(_voronoiIntensity, VORONOI_INTENSITY_START_AMOUNT);
        _material.SetFloat(_vignetteIntensity, VIGNETTE_INTENSITY_START_AMOUNT);

        yield return new WaitForSeconds(_teleportStartDisplayTime);

        float elapsedTime = 0f;
        while (elapsedTime != _teleportFadeOutTime)
        {
            elapsedTime +=  Time.deltaTime;

            float lerpedVoronoi = Mathf.Lerp(VORONOI_INTENSITY_START_AMOUNT, 0f, (elapsedTime/_teleportFadeOutTime));
            float lerpedVignette = Mathf.Lerp(VIGNETTE_INTENSITY_START_AMOUNT, 0f, (elapsedTime/_teleportFadeOutTime));

            _material.SetFloat(_voronoiIntensity, lerpedVoronoi);
            _material.SetFloat(_vignetteIntensity, lerpedVignette);

            yield return null;
        }

        _fullScreenTeleportShader.SetActive(false);
    }
}
