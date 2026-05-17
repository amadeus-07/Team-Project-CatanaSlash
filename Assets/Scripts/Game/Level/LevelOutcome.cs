using Core;
using UnityEngine;
using VContainer;

public class LevelOutcome : MonoBehaviour
{
    [Inject] private Player player;
    [Inject] private IEnemyCounter enemyCounter;
    [Inject] private LabelPresenter labelPresenter;
    [Inject] private PlayerInput playerInput;
    [Inject] private AudioPlayer audioPlayer;
    private StateMachine _fsm;

    private void Awake()
    {
        _fsm = new StateMachine(this);
        
    }

    private void Start()
    {
        var playingState = new PlayingState(labelPresenter, playerInput, audioPlayer);
        var winState = new WinState(labelPresenter, audioPlayer);
        var loseState = new LoseState(labelPresenter, audioPlayer);
        _fsm.AddTransition(playingState, winState, () => enemyCounter.Count == 0);
        _fsm.AddTransition(playingState, loseState,  () => player.Stats.Get<Health>().IsDead.Value);
        _fsm.Start(playingState);
    }
}