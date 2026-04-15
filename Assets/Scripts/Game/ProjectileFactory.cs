using UnityEngine;
using VContainer;
using Core;

public interface IProjectileFactory
{
    Projectile Create(Vector3 position, Quaternion rotation, int damage, float speed);
}

public sealed class ProjectileFactory : IProjectileFactory
{
    private readonly Projectile _prefab;
    private readonly IObjectResolver _resolver;

    public ProjectileFactory(IObjectResolver resolver, Projectile prefab)
    {
        _resolver = resolver;
        _prefab = prefab;
    }

    public Projectile Create(Vector3 position, Quaternion rotation, int damage, float speed)
    {
        var instance = Object.Instantiate(_prefab, position, rotation);
        _resolver.Inject(instance);      // если нужны зависимости
        instance.Initialize(damage, speed);
        return instance;
    }
}
