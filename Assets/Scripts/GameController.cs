using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    UnityEvent bridgeEnding = new UnityEvent();
    UnityEvent restartLevel = new UnityEvent();
    [SerializeField] private AudioClip bridgeEndingClip;
    public PlayerActions playerActions;
    public FirstPersonLook firstPersonLook;
    public InventoryMenu inventoryMenu;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bridgeEnding.AddListener(BridgeEnding);
        restartLevel.AddListener(RestartLevel);
    }

    void Update()
    {
        if (playerActions.isEnd)
        {
            BridgeEnding();
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
