using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game Controller Properties")]
    public InventoryMenu inventoryMenu;
    public CursorLockControl cursorLockControl;

    [Header("Asset Links")]
    public PlayerActions playerActions;
    public FirstPersonLook firstPersonLook;


    [Header("Bridge Ending Properties")]
    [SerializeField] private AudioClip bridgeEndingClip;
    AudioSource audioSource;

    void Awake()
    {
        cursorLockControl.LockCursor();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        inventoryMenu = GetComponent<InventoryMenu>();
        cursorLockControl = GetComponent<CursorLockControl>();
        playerActions = FindObjectOfType<PlayerActions>();
        firstPersonLook = FindObjectOfType<FirstPersonLook>();
    }

    void Update()
    {
        if (playerActions.isEnd)
        {
            BridgeEnding();
        }

        // For debugging
        if (Input.GetKey(KeyCode.R))
        {
            RestartLevel();
        }

        if (Input.GetKeyUp(KeyCode.I) && !inventoryMenu.paused)
        {
            cursorLockControl.UnlockCursor();
            firstPersonLook.inventoryOpen = true;
            inventoryMenu.OpenInventory(true);
        }
        else if (Input.GetKeyUp(KeyCode.I) && inventoryMenu.paused)
        {
            cursorLockControl.LockCursor();
            firstPersonLook.inventoryOpen = false;
            inventoryMenu.OpenInventory(false);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }

    void BridgeEnding()
    {
        audioSource.clip = bridgeEndingClip;
        audioSource.loop = false;
        audioSource.Play();
        waitForSound();
        Loader.Load(Loader.Scene.Bridge_Ending);
    }

    IEnumerator waitForSound()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
    }
}
