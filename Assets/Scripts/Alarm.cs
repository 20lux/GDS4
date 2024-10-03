using Unity.VisualScripting;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public Light thisLight;
    public AudioSource audioSource;
    public bool isOff = false; 

    void Awake()
    {
        if (isOff)
        {
            thisLight.intensity = 0;  
        }
    }

    public void StartAlarm()
    {
        thisLight.intensity = 10;
        audioSource.Play();
    }
}
