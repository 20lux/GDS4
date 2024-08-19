using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Grab (Transform playerLookTransform);
    string GetInteractText();

    void OpenDoor();
    void CloseDoor();
    void ToggleDoor();
}
