using UnityEngine;
using UnityEngine.Events;

public class TechLabTarget : MonoBehaviour
{
    public UnityEvent onShipEnable;

    // Turn on engine sequence
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            onShipEnable?.Invoke();
        }
    }
}
