using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _ExitButton;
    [SerializeField] private GameObject _tutorial;

    private void Start()
    {
        _playButton.onClick.AddListener(StartGame);
        _ExitButton.onClick.AddListener(ExitGame);
        if (Application.platform == RuntimePlatform.WebGLPlayer) 
            _ExitButton.gameObject.SetActive(false);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
