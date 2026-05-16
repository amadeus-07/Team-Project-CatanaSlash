using Core;
using UnityEngine.SceneManagement;
using VContainer;

public class PlayingState : State
{
    private PlayerInput _playerInput;
    private LabelPresenter _labelPresenter;

    public PlayingState(LabelPresenter labelPresenter, PlayerInput playerInput)
    {
        _labelPresenter = labelPresenter;
        _playerInput = playerInput;
    }

    protected override void OnEnter()
    {
        _labelPresenter.PlayReady(Start);

    }

    private void Start()
    {
        _playerInput.enabled = true;
    }
}