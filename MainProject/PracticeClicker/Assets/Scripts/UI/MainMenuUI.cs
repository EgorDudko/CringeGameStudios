using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private Button _ExitButton;
    [SerializeField] private GameObject _tutorial;

    private void Start()
    {
        _playButton.onClick.AddListener(StartGame);
        _tutorialButton.onClick.AddListener(LaunchTutorual);
        _playButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    private void LaunchTutorual()
    {
        //_tutorial.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
