using UnityEngine;

public class FlakProjectile : MonoBehaviour
{
    public float _speed = 25f;
    [SerializeField] private Rigidbody2D _rb;
    public float _damage = 12f;

    private void Start()
    {
        _rb.AddTorque(Random.Range(250f, 500f));
        float randSpeed = Random.Range(_speed - 5f, _speed + 5f);
        _rb.velocity = transform.right * randSpeed;
        Destroy(gameObject, 1f + (randSpeed / 10f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            Target target = other.GetComponent<Target>();
            if (enemy != null && enemy._hp > 0f)
            {
                enemy.TakeDamage(_damage);
            }
            else if (target != null)
            {
                target.TakeDamage();
            }
        }
    }

}