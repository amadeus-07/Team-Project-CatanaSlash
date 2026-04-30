using Core;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public abstract class Enemy : Character
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform explodeForcePoint;
    [Inject] protected ITarget Target {get;  private set;}

    protected AnimationStateFactory AnimationStateFactory {get; private set;}

    public void SetTarget(ITarget target)
    {
        Target = target;
    }

    protected void Awake()
    {
        AnimationStateFactory = new AnimationStateFactory(animator);
        base.Awake();
    }

    protected void Start()
    {
        base.Start();
    }

    protected override void OnDamage(int delta)
    {
        
    }

    protected override void OnDead()
    {
        gameObject.SetActive(false);
    }
  
}