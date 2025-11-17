using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    private void Start()
    {
        MusicManager.instance.PlayMusic("BGM2");
    }

    public void PlayGame()
    {
        LevelManager.instance.LoadScene("Game", "CrossFade");
    }
}
