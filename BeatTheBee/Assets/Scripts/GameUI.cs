using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance { get; private set; }

    private GameObject pause;
    private GameObject gamePlay;
    private GameObject gameOver;
    private GameObject gameClear;
    public GameObject Scent { get; private set; }

    private void Awake()
    {
        Instance = this;
        pause = transform.Find("Pause").gameObject;
        gamePlay = transform.Find("GamePlay").gameObject;
        gameOver = transform.Find("GameOver").gameObject;
        gameClear = transform.Find("GameClear").gameObject;
        Scent = transform.Find("Scent").gameObject;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gamePlay.SetActive(false);
        pause.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
        gamePlay.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gamePlay.SetActive(false);
        gameOver.SetActive(true);
    }

    public void GameClear()
    {
        Time.timeScale = 0f;
        gamePlay.SetActive(false);
        gameClear.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void GoToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void CloseScent()
    {
        Scent.SetActive(false);
    }
}