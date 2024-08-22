using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Collider thisTeleporter;
    [SerializeField] private Collider destinationPosition;

    private void Awake()
    {
        thisTeleporter = gameObject.GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = destinationPosition.transform.position;
        }
    }
}
