using Core;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

public abstract class Enemy : Character
{
    [Inject] protected ITarget Target {get;  private set;}
  


    public void SetTarget(ITarget target)
    {
        Target = target;
    }

    protected void Awake()
    {

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