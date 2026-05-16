using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ResumeUI : MonoBehaviour
{
    [SerializeField] private string menuScene;
    [SerializeField] private UIDocument options;
    [SerializeField] private AudioSource clickAudio;

    private Button _playButton;
    private Button _optionsButton;
    private Button _quitButton;


    private void OnEnable()
    {
        options.gameObject.SetActive(true);

        var root = GetComponent<UIDocument>().rootVisualElement;
        var buttons = root.Q<VisualElement>("Resume");
        _playButton = buttons.Q<VisualElement>("Play").Q<Button>("Play");
        _optionsButton = buttons.Q<VisualElement>("Options").Q<Button>("Options");
        _quitButton = buttons.Q<VisualElement>("Quit").Q<Button>("Quit");

        _playButton.clicked += OnPlayClicked;
        _optionsButton.clicked += OnOptionsClicked;
        _quitButton.clicked += OnQuitClicked;


        options.gameObject.SetActive(false);
    }

    public void Play()
    {
        gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnPlayClicked()
    {
        clickAudio.Play();
        Play();
    }

    private void OnOptionsClicked()
    {
        clickAudio.Play();
        options.gameObject.SetActive(true);
    }

    private void OnQuitClicked()
    {
        clickAudio.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene);
    }

}
