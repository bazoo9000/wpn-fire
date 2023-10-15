using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float _damage = 0f;
    public float _radius = 1.25f;
    private AudioSource _audio;
    [SerializeField] private AudioClip[] _clip;

    void Start()
    {
        transform.Rotate(0f, 0f, -90f);
        int i = Random.Range(0, _clip.Length);
        _audio = GetComponent<AudioSource>();
        _audio.PlayOneShot(_clip[i]);
        Explode();
        Destroy(gameObject, _clip[i].length);
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
        foreach (Collider2D c in colliders)
        {
            if (c.gameObject.tag == "Enemy")
            {
                Enemy enemy = c.GetComponent<Enemy>();
                Target target = c.GetComponent<Target>();
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
}
