using UnityEngine;
using VContainer;
using VContainer.Unity;
using Core;
using Unity.VisualScripting;

public class LevelLifetimeScope : LifetimeScope
{
    [SerializeField] private PlayerInput input;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(input);
    }
}
