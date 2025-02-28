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
    private int comboCount = 0;
    public int baseScore = 0;

    void Start()
    {
        playerScore = 0;
        comboCount = 0;
        scoreText.text = playerScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void addScoreWithCombo()
    {
        comboCount++;  

        int scoreToAdd = baseScore + comboCount;
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (dingWAX != null)
        {
            dingWAX.Play();
        }

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

    public void ResetCombo()
    {
        comboCount = 0;
    }

    public void restarGame()
    {
        ResetCombo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        ResetCombo();
    }
}