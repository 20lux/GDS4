using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private bool Paused = false;
    [HideInInspector] public bool paused => Paused;
    public GameObject pauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
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
