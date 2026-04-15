using System;
using UniRx;
using UnityEngine;

namespace Core
{
    public enum CooldownState { Ready, Running, Paused }

    public sealed class Cooldown
    {
        private readonly Timer _timer;
        private readonly Action _action;
        private IDisposable _tickSubscription;

        public ReactiveProperty<float> Duration => _timer.Duration;
        public ReactiveProperty<CooldownState> State { get; }

        public Cooldown(ReactiveProperty<float> duration, Action action, bool startActive = false)
        {
            _action = action;
            _timer = new Timer(duration, startActive);
            State = new ReactiveProperty<CooldownState>(startActive ? CooldownState.Running : CooldownState.Ready);

            // Подписка на таймер и автоматический апдейт состояния
            _timer.State.Subscribe(timerState =>
            {
                State.Value = timerState switch
                {
                    TimerState.Ready => CooldownState.Ready,
                    TimerState.Running => CooldownState.Running,
                    TimerState.Paused => CooldownState.Paused,
                    _ => State.Value
                };
            }).AddTo(new CompositeDisposable());
        }

        public void Activate()
        {
            if (State.Value != CooldownState.Ready) return;

            _action?.Invoke();
            Start();
        }

        public bool Start()
        {
            if (State.Value != CooldownState.Ready) return false;

            _timer.Start(Duration.Value);
            return true;
        }

        public void Pause() => _timer.Pause();
        public void Resume() => _timer.Resume();

        public void Reset()
        {
            _timer.Reset();
            State.Value = CooldownState.Ready;
        }

        public void Rollback(float seconds)
        {
            if (State.Value == CooldownState.Ready) return;

            _timer.Remaining.Value = Mathf.Max(0f, _timer.Remaining.Value - seconds);
        }

        public Cooldown AddTo(CompositeDisposable disposable)
        {
            _tickSubscription?.Dispose();
            _tickSubscription = _timer.AddTo(disposable);
            return this;
        }

        public Cooldown AddTo(Component component)
        {
            _tickSubscription?.Dispose();
            _tickSubscription = _timer.AddTo(component);
            return this;
        }

        public void Remove()
        {
            _tickSubscription?.Dispose();
            _tickSubscription = null;
        }
    }
}
