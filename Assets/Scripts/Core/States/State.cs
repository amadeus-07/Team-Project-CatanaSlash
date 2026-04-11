using UniRx;
using UnityEngine;

namespace Core
{
    public enum StateStatus
    {
        Stopped,
        Running
    }

    public abstract class State
    {
        protected CompositeDisposable GlobalDisposables { get; private set; }
        protected CompositeDisposable LocalDisposables { get; private set; }
        protected StateStatus Status { get; private set; }


        protected virtual void OnInitialize() { }
        protected virtual void OnEnter() { }
        protected virtual void OnExit() { }
        protected virtual void OnUpdate() { }
        protected virtual void OnFixedUpdate() { }

        internal void Initialize(CompositeDisposable globalDisposables = null)
        {
            GlobalDisposables = globalDisposables;
            OnInitialize();
        }

        internal virtual void Enter()
        {
            Status = StateStatus.Running;
            LocalDisposables = new CompositeDisposable(); 
            
            OnEnter();
        }

        internal virtual void Exit()
        {
            Status = StateStatus.Stopped;
            LocalDisposables?.Dispose();
            OnExit();
        }

        internal void Update() => OnUpdate();
        internal void FixedUpdate() => OnFixedUpdate();

        
        internal void AddTo(CompositeDisposable globalDisposables)
        {
            GlobalDisposables = globalDisposables;
        }
    }
}
