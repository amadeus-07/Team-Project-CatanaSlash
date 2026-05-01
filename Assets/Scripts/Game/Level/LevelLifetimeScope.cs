using UnityEngine;
using VContainer;
using VContainer.Unity;
using Core;
using Unity.VisualScripting;

public class LevelLifetimeScope : LifetimeScope
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private Player player;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private SpawnSequence spawnSequence;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(input);
        builder.RegisterInstance(player)
            .AsSelf()
            .As<ITarget>();
         builder.RegisterInstance(projectilePrefab);
        builder.Register<ProjectileFactory>(Lifetime.Singleton).As<IProjectileFactory>();
        builder.Register<EnemyCounter>(Lifetime.Singleton).As<IEnemyCounter>();
        builder.RegisterInstance(spawnSequence);
    }
}
