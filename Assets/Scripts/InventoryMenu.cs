using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenuCanvas;
    public CursorLockControl cursorLockControl;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        cursorLockControl = GetComponent<CursorLockControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Paused)
            {
                OpenInventory(false);
            }
            else
            {
                // Get into menu and pause game
                OpenInventory(true);
            }
        }
    }

    public void OpenInventory(bool state)
    {
        if (state)
        {
            GameStop();
        }
        else
        {
            GamePlay();
        }
    }

    public void GameStop()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0.0f;
        Paused = true;
    }

    public void GamePlay()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        Paused = false;
    }
}
