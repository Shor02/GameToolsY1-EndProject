using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    public GameObject title1;
    public GameObject title2;

    public GameObject pauseMenu;
    public static bool isPaused;

    public float glitchInterval = 0.5f;

    public KeyCode pauseKey;

    private void Start()
    {
        pauseMenu.SetActive(false);
        InvokeRepeating("Glitch", 0f, glitchInterval);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            Debug.Log("ESC pressed");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void Glitch()
    {
        bool showTitle1 = Random.Range(0, 2) == 0;

        title1.gameObject.SetActive(showTitle1);
        title2.gameObject.SetActive(!showTitle1);
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Sample Scene");
    }
}
