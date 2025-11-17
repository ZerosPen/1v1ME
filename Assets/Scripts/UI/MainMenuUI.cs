using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public BestScoreMainMenuUI _bestScoreMainMenuUI;

    private void Start()
    {
        MusicManager.instance.PlayMusic("BGM2");
    }

    public void PlayGame()
    {
        LevelManager.instance.LoadScene("Game", "CrossFade");
    }

    public void BestScoreShow()
    {
        _bestScoreMainMenuUI.UpdateBestScore();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
