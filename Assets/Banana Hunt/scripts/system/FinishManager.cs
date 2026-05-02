using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    public GameObject finishPanel;
    public TMP_Text scoreResultText;
    public TMP_Text highScoreText;

    public void ShowFinish(int score)
    {
        finishPanel.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        scoreResultText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;

        Time.timeScale = 0f;
    }

    // 🔁 tombol retry
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    // 🏠 tombol balik menu
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Mainmenu");
    }
}