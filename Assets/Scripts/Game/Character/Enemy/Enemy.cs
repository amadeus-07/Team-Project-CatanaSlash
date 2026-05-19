using Core;
using Unity.VisualScripting;
using UnityEngine;
using VContainer;

[RequireComponent(typeof(FruitExplode))]
public abstract class Enemy : Character
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform explodeForcePoint;
    [Inject] protected ITarget Target {get;  private set;}
    [Inject] private AudioPlayer audioPlayer;

    protected AnimationStateFactory AnimationStateFactory {get; private set;}
    protected FruitExplode FruitExplode;

    public void SetTarget(ITarget target)
    {
        Target = target;
    }

    protected void Awake()
    {
        AnimationStateFactory = new AnimationStateFactory(animator);
        FruitExplode = GetComponent<FruitExplode>();
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
        audioPlayer.Cut.Play();
        FruitExplode.Explode();
        gameObject.SetActive(false);
    }
  
}