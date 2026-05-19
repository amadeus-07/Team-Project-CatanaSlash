using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LabelPresenter : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Animator animator;

    private static readonly int ReadyHash = Animator.StringToHash("Ready");
    private static readonly int WinHash   = Animator.StringToHash("Win");
    private static readonly int LoseHash  = Animator.StringToHash("Lose");

    public void PlayReady(System.Action onFinished = null)
    {
        image.enabled = true;
        animator.Play(ReadyHash, 0, 0f);
        
        StartCoroutine(WaitForAnimation(ReadyHash, onFinished));
    }

    public void PlayWin(System.Action onFinished = null)
    {
         Debug.Log("PlayWin");
        image.enabled = true;
        animator.Play(WinHash, 0, 0f);
        StartCoroutine(WaitForAnimation(WinHash, onFinished));
    }

    public void PlayLose(System.Action onFinished = null)
    {
        image.enabled = true;
        animator.Play(LoseHash, 0, 0f);
        StartCoroutine(WaitForAnimation(LoseHash, onFinished));
    }

    private IEnumerator WaitForAnimation(int stateHash, System.Action onFinished)
    {
        Debug.Log("A");
        // ждём пока аниматор реально перейдёт в нужное состояние
        while (!animator.GetCurrentAnimatorStateInfo(0).shortNameHash.Equals(stateHash))
            yield return null;

        // ждём конца анимации
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
            yield return null;

        onFinished?.Invoke();
    }
}
