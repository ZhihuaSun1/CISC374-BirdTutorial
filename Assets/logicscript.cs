using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class logicscript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restarGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
