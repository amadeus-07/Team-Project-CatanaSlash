using Core;
using UnityEngine;
using VContainer;

public class LevelOutcome : MonoBehaviour
{
    [Inject] private Player player;
    [Inject] private IEnemyCounter enemyCounter;
    [Inject] private PlayerInput playerInput;
    private StateMachine _fsm;

    private void Awake()
    {
        _fsm = new StateMachine(this);
        
    }

    private void Start()
    {
        var playingState = new PlayingState(playerInput);
        var winState = new WinState();
        var loseState = new LoseState();
        _fsm.AddTransition(playingState, winState, () => enemyCounter.Count == 0);
        _fsm.AddTransition(playingState, loseState,  () => player.Stats.Get<Health>().IsDead.Value);
        _fsm.Start(playingState);
    }
}