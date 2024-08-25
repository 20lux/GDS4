using UnityEngine;

public class TechLabObject : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private GameObject targetPosition;
    [SerializeField] private Light[] lightsToEnable;
    [SerializeField] private GameObject[] particlesToEnable;

    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Target")
        {
            gameObject.transform.position = startPosition;
        }
        else
        {
            gameObject.transform.position = targetPosition.transform.position;
            gameObject.transform.rotation = targetPosition.transform.rotation;
            
            for (int i = 0; i < lightsToEnable.Length; i++)
            {
                lightsToEnable[i].enabled = true;
            }

            for (int i = 0; i < particlesToEnable.Length; i++)
            {
                var ps = particlesToEnable[i].GetComponent<ParticleSystem>().emission;
                ps.rateOverTime = 100;
            }
        }
    }
}
