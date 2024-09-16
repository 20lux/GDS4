using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CartridgeInventory : MonoBehaviour
{
    [Header("Cartridge Data")]
    [SerializeField] private GameObject[] cartridges;
    public PlayerActions playerActions;

    void Awake()
    {
        // All cartridges are invisible at the start
        // and will enable once they are picked up
        for (int i = 0; i < cartridges.Length; i++)
        {
            cartridges[i].SetActive(false);
        }
    }

    public void CartridgeCheck()
    {
        // If player picks up cartridge
        // check to see what ID it matches
        // and enable the relevant game object
    }
}
