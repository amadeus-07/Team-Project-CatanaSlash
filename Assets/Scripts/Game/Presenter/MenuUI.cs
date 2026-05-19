using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private UIDocument options;
    [SerializeField] private AudioSource clickAudio;

    private Button _playButton;
    private Button _optionsButton;
    private Button _exitButton;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var buttons = root.Q<VisualElement>("Menu").Q<VisualElement>("Buttons");
        _playButton = buttons.Q<Button>("Play");
        _optionsButton = buttons.Q<Button>("Options");
        _exitButton = buttons.Q<Button>("Exit");

        _playButton.clicked += OnPlayClicked;
        _optionsButton.clicked += OnOptionsClicked;
        _exitButton.clicked += OnExitClicked;
    }



    private void OnPlayClicked()
    {
        clickAudio.Play();
        SceneManager.LoadScene(gameScene);
    }
    private void OnOptionsClicked()
    {
        clickAudio.Play();
        options.gameObject.SetActive(true);
    }

    private void OnExitClicked()
    {
        clickAudio.Play();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }
}
