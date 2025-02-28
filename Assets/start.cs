using UnityEngine;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject titleScreenPanel;

    void Start()
    {
        Time.timeScale = 0f;
        titleScreenPanel.SetActive(true);
    }

    public void OnStartButtonClicked()
    {
        titleScreenPanel.SetActive(false);

        Time.timeScale = 1f;
    }
}
