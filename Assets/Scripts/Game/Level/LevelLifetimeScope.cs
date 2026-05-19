using UnityEngine;
using VContainer;
using VContainer.Unity;
using Core;
using Unity.VisualScripting;

public class LevelLifetimeScope : LifetimeScope
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerInput input;
    [SerializeField] private SpawnSequence spawnSequence;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private LabelPresenter labelPresenter;
    [SerializeField] private AudioPlayer audioPlayer;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(player)
            .AsSelf()
            .As<ITarget>();
        builder.RegisterInstance(labelPresenter);
        builder.RegisterInstance(projectilePrefab);
        builder.Register<ProjectileFactory>(Lifetime.Singleton).As<IProjectileFactory>();
        builder.Register<EnemyCounter>(Lifetime.Singleton).As<IEnemyCounter>();
        builder.RegisterInstance(input);
        builder.RegisterInstance(spawnSequence);
        builder.RegisterInstance(audioPlayer);
    }
}
