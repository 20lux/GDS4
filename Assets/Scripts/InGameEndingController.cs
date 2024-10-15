using UnityEngine;

public class InGameEndingController : MonoBehaviour
{
    public GameController gameController;

    public void StartEnding()
    {
        Initiate.Fade("Airlock_Ending", Color.black, 60f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartEnding();
        }
    }
}
