using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource clickAudio;

    private Button _musicToggle;
    private Button _soundToggle;
    private Button _closeButton;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var options = root.Q<VisualElement>("Options");
        _musicToggle = options.Q<VisualElement>("Music").Q<Button>("Music");
        _soundToggle = options.Q<VisualElement>("Sound").Q<Button>("Sound");
        _closeButton = options.Q<Button>("Close");

        _musicToggle.clicked += OnMusicClicked;
        _soundToggle.clicked += OnSoundClicked;
        _closeButton.clicked += OnCloseClicked;
        Load(_musicToggle, "music");
        Load(_soundToggle, "sfx");
    }

    private void OnMusicClicked()
    {
        clickAudio.Play();
        mixer.GetFloat("music", out var v);
        bool isOn = v > -80f;
        mixer.SetFloat("music", isOn ? -80f : 0f);
        ToggleState(_musicToggle, !isOn);
    }
    private void OnSoundClicked()
    {
        clickAudio.Play();
        mixer.GetFloat("sfx", out var v);
        bool isOn = v > -80f;
        mixer.SetFloat("sfx", isOn ? -80f : 0f);
        ToggleState(_soundToggle, !isOn);
    }
    private void OnCloseClicked()
    {
        clickAudio.Play();
        gameObject.SetActive(false);
    }

    private void Load(Button button, string volume)
    {
        mixer.GetFloat(volume, out var v);
        bool isOn = v > -80f;
        ToggleState(button, isOn);
    }

    private void ToggleState(Button button, bool isOn)
    {
        var img = button.Q<Image>("off");
        img.EnableInClassList("option-on",  isOn);
        img.EnableInClassList("option-off", !isOn);
    }
}
