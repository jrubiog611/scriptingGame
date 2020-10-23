using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardShow : MonoBehaviour
{
    public Button leaderboardButton, playButton, exitButton, hideButton;
    public GameObject leaderboard, mainMenu;

    private void Start()
    {
        leaderboardButton.onClick.AddListener(ShowLeaderboard);
        playButton.onClick.AddListener(PlayButton);
        exitButton.onClick.AddListener(ExitGame);
        hideButton.onClick.AddListener(HideLeaderboard);
    }

    public void ShowLeaderboard()
    {
        leaderboard.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void HideLeaderboard()
    {
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
