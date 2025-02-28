using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicscript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;           
    public Text highScoreText;       
    public GameObject gameOverScreen;
    public AudioSource dingWAX;

    private int highScore;

    void Start()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        dingWAX.Play();
        if (playerScore > highScore)
        {
            highScore = playerScore;
            if (highScoreText != null)
            {
                highScoreText.text = "High Score: " + highScore;
            }
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();  
        }
    }

    public void restarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}