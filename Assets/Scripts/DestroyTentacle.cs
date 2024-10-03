using UnityEngine;

public class DestroyTentacle : MonoBehaviour
{
    public GameObject[] tentaclesToDestroy;
    public ButtonPress airlockDoorButton;

    public void OpenAirlock()
    {
        airlockDoorButton.isActive = true;

        for (int i = 0; i < tentaclesToDestroy.Length; i++)
        {
            Destroy(tentaclesToDestroy[i]);
        }
    }
}
