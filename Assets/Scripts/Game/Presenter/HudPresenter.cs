using UnityEngine;
using UnityEngine.UIElements;
using UniRx;
using System.Collections;
using Core;
using VContainer;

public class HudPresenter : MonoBehaviour
{
    [SerializeField] private StatsContext stats;
    [Inject] private Player player;
    private UIDocument _uIDocument;

    private Coroutine flashRoutine;

    private void Awake()
    {
        _uIDocument = GetComponent<UIDocument>();
       
    }

    private void Start()
    {
        player.Stats.Get<Health>().Current.Subscribe(OnHealtChanged);
    }

    private void OnHealtChanged(int health)
    {
        var root = _uIDocument.rootVisualElement.Q<VisualElement>("HUD");
        var heartsContainer = root.Q<VisualElement>("Hearts");
        var avatar = root.Q<Image>("Avatar");

        for (int i = 0; i < heartsContainer.childCount; i++)
            heartsContainer[i].visible = i < health;

        if (flashRoutine != null)
            StopCoroutine(flashRoutine);
        flashRoutine = StartCoroutine(FlashAvatar(avatar));
    }

    private IEnumerator FlashAvatar(Image avatar)
    {
        avatar.tintColor = Color.red;
        yield return new WaitForSeconds(0.2f);
        avatar.tintColor = Color.white;
    }
}
