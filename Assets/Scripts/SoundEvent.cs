using UnityEngine;
using UnityEngine.Events;

public class SoundEvent : MonoBehaviour
{
    public UnityEvent onClickedEvent;

    public void PlaySoundEvent()
    {
        onClickedEvent?.Invoke();
    }
}
