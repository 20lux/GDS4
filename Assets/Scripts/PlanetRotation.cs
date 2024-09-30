using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float spinSpeed = 0.1f;
    private Vector3 scale;

    void Awake()
    {
        scale = transform.localScale;
    }

    void Update()
    {
        transform.Rotate(new Vector3 (0, 100, 0) * Time.deltaTime * (spinSpeed / scale.magnitude));
    }
}
