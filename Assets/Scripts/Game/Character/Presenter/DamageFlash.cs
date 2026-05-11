using System;
using Core;
using UniRx;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float flashTime = 0.1f;
    [SerializeField] private StatsContext stats;

    private Material _mat;
    private Color _baseColor;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _mat = _renderer.material; // ВАЖНО: инстанс
        _baseColor = _mat.color;
    }

    private void Start()
    {
        stats.Get<Health>().OnDamage += OnDamage;
    }
    private void OnDamage(int delta)
    {
        Flash();
    }

    private void Flash()
    {
        _mat.color = damageColor;

        Observable.Timer(TimeSpan.FromSeconds(flashTime))
            .Subscribe(_ => _mat.color = _baseColor)
            .AddTo(this);
    }

    private void ODestroy()
    {
        stats.Get<Health>().OnDamage -= OnDamage;
    }
}
