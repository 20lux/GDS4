using UnityEngine;

public class TechLabTarget : MonoBehaviour
{
    [SerializeField] private GameObject movingObject;
    [SerializeField] private Light[] lightsToEnable;
    [SerializeField] private GameObject[] particlesToEnable;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Target")
        {
            movingObject.transform.SetParent(gameObject.transform);
            
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
