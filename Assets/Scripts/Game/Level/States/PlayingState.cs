using Core;
using UnityEngine.SceneManagement;
using VContainer;

public class PlayingState : State
{
    private PlayerInput _playerInput;
    private LabelPresenter _labelPresenter;
    private AudioPlayer _audioPlayer;
    public PlayingState(LabelPresenter labelPresenter, PlayerInput playerInput, AudioPlayer audioPlayer)
    {
        _labelPresenter = labelPresenter;
        _playerInput = playerInput;
        _audioPlayer = audioPlayer;
    }

    protected override void OnEnter()
    {
        _labelPresenter.PlayReady(Start);

    }

    private void Start()
    {
        _playerInput.enabled = true;
        _audioPlayer.Music.Play();
    }
}