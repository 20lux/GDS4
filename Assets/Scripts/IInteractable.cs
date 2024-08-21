using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Grab (GameObject grabCam);
    string GetObjectName();
}
