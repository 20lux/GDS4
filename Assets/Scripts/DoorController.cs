using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonDrifter>() != null)
        {
            // Player entered collider
        }
    }
}
