using UnityEngine;

public class CartridgeID : MonoBehaviour
{
    [Header("Cartridge ID Properties")]
    [SerializeField] private int cartridgeID;
    [HideInInspector] public int ID => cartridgeID;
    public bool obtained = false;
}
