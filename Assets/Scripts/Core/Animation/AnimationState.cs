using UnityEngine;

public sealed class AnimationState
{
    private readonly Animator _animator;
    private readonly int _hash;
    private readonly int _layer;

    public bool IsPlaying => _animator
            .GetCurrentAnimatorStateInfo(_layer)
            .shortNameHash == _hash;

    public bool IsFinished =>
        _animator.GetCurrentAnimatorStateInfo(_layer).shortNameHash == _hash &&
        _animator.GetCurrentAnimatorStateInfo(_layer).normalizedTime >= 1f;

    public AnimationState(
        Animator animator,
        int stateHash,
        int layer = 0)
    {
        _animator = animator;
        _hash = stateHash;
        _layer = layer;
    }

    public void Play(float fade = 0.08f)
    {
        if (IsPlaying)
            return;
        _animator.CrossFade(_hash, fade, _layer);
    }





}
