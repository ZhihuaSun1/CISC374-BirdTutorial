using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class logicscript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioClip scoreClip;
    private AudioSource audioSource;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioSource = GetComponent<AudioSource>();
    }
    public void OnScore()
    {
        audioSource.PlayOneShot(scoreClip);
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
