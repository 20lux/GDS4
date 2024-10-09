using UnityEngine;

public class DestroyTentacle : MonoBehaviour
{
    public GameObject[] tentaclesToDestroy;

    public void OpenAirlock()
    {
        for (int i = 0; i < tentaclesToDestroy.Length; i++)
        {
            Destroy(tentaclesToDestroy[i]);
        }
    }
}
