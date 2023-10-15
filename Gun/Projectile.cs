using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float _speed = 0f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _effect;

    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
