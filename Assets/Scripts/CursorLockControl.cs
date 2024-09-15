using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockControl : MonoBehaviour
{
    public void LockCursor()
    {
        if (Cursor.lockState == CursorLockMode.Confined)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void UnlockCursor()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
