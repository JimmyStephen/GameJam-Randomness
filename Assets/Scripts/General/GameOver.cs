using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameoverUI;
    bool gameover = false;

    public bool Gameover
    {
        get { return gameover; }
        set
        {
            gameover = value;
            GameoverUI.SetActive(gameover);
            Time.timeScale = (gameover) ? 0 : 1;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1 || Pause.Instance.isPaused)
            return;

        Gameover = GameManager.Instance.Player.Health.GetCurrent() <= 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        SceneLoader.Instance.LoadScene(0);
    }
}
