using UnityEngine;

public class cartridgeInteract : MonoBehaviour 
{
    public int cartridgeIndex;
    public PlayVideo consoleForCartridge;

    public void pickUpCartridge()
    {
        if (consoleForCartridge.beingHeld == false)
        {
            consoleForCartridge.beingHeld = true;
        }
    }

    public void dropCartridge()
    {
        if (consoleForCartridge.beingHeld == true)
        {
            consoleForCartridge.beingHeld = false;
        }
    }
}
