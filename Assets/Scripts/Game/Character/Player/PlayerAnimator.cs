using UniRx;
using UnityEngine;
using VContainer;

public sealed class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [Inject] private PlayerInput input;

    static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
    static readonly int AttackHash   = Animator.StringToHash("Attack");

    void Start()
    {
        input.Move
            .Subscribe(v =>
                animator.SetBool(IsMovingHash, v.sqrMagnitude > 0.01f)
            )
            .AddTo(this);

        input.Attack
            .Subscribe(_ => animator.SetTrigger(AttackHash))
            .AddTo(this);
    }
}
