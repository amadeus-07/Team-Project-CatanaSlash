using Core;
using UnityEngine.SceneManagement;
using VContainer;

public class PlayingState : State
{
    private PlayerInput _playerInput;
    public PlayingState(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }

    protected override void OnEnter()
    {
         _playerInput.enabled = true;
    }

    private void Start()
    {
        _playerInput.enabled = true;
    }
}