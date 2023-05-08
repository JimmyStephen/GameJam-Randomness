using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : Singleton<Pause>
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameplayUI;
    [HideInInspector] public bool isPaused = false;

    public bool paused
    {
        get { return isPaused; }
        set
        {
            isPaused = value;
            pauseUI.SetActive(isPaused);
            gameplayUI.SetActive(!isPaused);
            Time.timeScale = (isPaused) ? 0 : 1;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1 || GameManager.Instance.Player.Health.GetCurrent() <= 0)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
    }

    public void TogglePaused()
    {
        paused = !paused;
    }
    public void Disable()
    {
        pauseUI.SetActive(false);
        gameplayUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        Disable();
        SceneLoader.Instance.LoadScene(0);
    }
}