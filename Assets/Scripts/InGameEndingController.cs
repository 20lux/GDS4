using UnityEngine;

public class InGameEndingController : MonoBehaviour
{
    public GameController gameController;
    public EndingType ending;
    public bool isThisObjectACollider = false;

    public enum EndingType
    {
        Bridge,
        Airlock,
        Hell
    }

    public void StartEnding()
    {
        switch (ending)
        {
            case EndingType.Bridge:
                gameController.BridgeEnding();
                break;
            case EndingType.Airlock:
                gameController.AirlockEnding();
                break;
            case EndingType.Hell:
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isThisObjectACollider)
        {
            if (other.CompareTag("Player"))
            {
                StartEnding();
            }
        }
    }
}
