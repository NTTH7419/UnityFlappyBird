using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public Text pressSpaceText;
    public GameObject gameOverScreen;
    public bool isAlive;
    public bool isRunning;

    private int highScore;

    public void Start()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "High score: " + highScore.ToString();
        gameOverScreen.SetActive(false);
        pressSpaceText.gameObject.SetActive(true);
        isAlive = true;
        isRunning = false;
    }

    [ContextMenu("Increse Score")]
    public void addScore(int score=1)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();

        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = "High score: " + playerScore.ToString();
            PlayerPrefs.SetInt("highscore", playerScore);
            PlayerPrefs.Save();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
