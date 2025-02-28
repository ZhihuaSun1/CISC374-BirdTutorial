using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicscript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;           // 当前分数 UI 文本
    public Text highScoreText;       // 最高分 UI 文本
    public GameObject gameOverScreen;
    public AudioSource dingWAX;

    // Combo 系统变量
    private int comboCount = 0;      // 连续通过管道的计数
    public int baseScore = 1;        // 每次穿管道的基础分

    private int highScore;

    void Start()
    {
        playerScore = 0;
        comboCount = 0;
        scoreText.text = playerScore.ToString();

        // 从 PlayerPrefs 中读取最高分
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    /// <summary>
    /// 每当玩家成功穿过管道时调用此方法。
    /// 连续通过会累计 combo，每次加分为基础分加上当前 combo 数值。
    /// 例如，第一次穿过：1+1，第二次穿过：1+2，第三次穿过：1+3，依次递增。
    /// </summary>
    [ContextMenu("Increase Score With Combo")]
    public void addScoreWithCombo()
    {
        // 累加 combo 数值
        comboCount++;

        // 计算本次应加的分数：基础分 + 当前 combo
        int scoreToAdd = baseScore + comboCount;

        // 更新总分
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();

        // 播放得分音效
        if (dingWAX != null)
        {
            dingWAX.Play();
        }

        // 检查并更新最高分
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

    /// <summary>
    /// 游戏结束时调用，重置 combo 数值。
    /// </summary>
    public void resetCombo()
    {
        comboCount = 0;
    }

    public void restarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        // 重置 combo，方便重新开始时从零开始计数
        resetCombo();
    }
}