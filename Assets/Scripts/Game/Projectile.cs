using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public sealed class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;

    private int _damage;
    private float _speed;
    private Rigidbody _rb;

    public void Initialize(int damage, float speed)
    {
        _damage = damage;
        _speed = speed;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void OnEnable()
    {
        Invoke(nameof(Despawn), lifeTime);
    }

    private void Start()
    {
        _rb.linearVelocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            player.Stats.Get<Health>().ChangeCurrent(-_damage);
        }

        Despawn();
    }

    private void Despawn()
    {
        CancelInvoke();
        Destroy(gameObject);
    }
}
