using UnityEngine;

public class RemoteDroidController : MonoBehaviour
{
    public GameObject targetPad;

    public void OnCollideWithPad()
    {
        transform.SetParent(targetPad.transform);
        transform.position = targetPad.transform.position;
    }
}
