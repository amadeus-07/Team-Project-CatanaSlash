using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerInput : MonoBehaviour
{
    private InputSystem_Actions _actions;

    private readonly Subject<Unit> _attack = new();
    public IObservable<Unit> Attack => _attack;

    public ReactiveProperty<Vector2> Move { get; } = new(Vector2.zero);

    void Awake()
    {
        _actions = new InputSystem_Actions();
        _actions.Enable();

        _actions.Player.Attack.performed += OnAttackPerformed;
    }

    void Update()
    {
        Move.Value = _actions.Player.Move.ReadValue<Vector2>();
    }

    private void OnAttackPerformed(InputAction.CallbackContext ctx)
    {
        if (!enabled)
            return;
        _attack.OnNext(Unit.Default);
    }

    void OnDestroy()
    {
        _actions.Player.Attack.performed -= OnAttackPerformed;
        _actions.Disable();
        _actions.Dispose();
    }
}
