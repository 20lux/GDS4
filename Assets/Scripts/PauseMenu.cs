using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0.0f;
        Paused = true;
    }

    public void Play()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        Paused = false;
    }
}
