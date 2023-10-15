using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    private float _kickDamage = 10f;
    public Animator _anim;
    public GameObject _bloodEffect;
    public AudioSource _audio;
    public AudioClip[] _kickHit;

    private void Update()
    {
        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
        {
            _anim.SetBool("IsKicking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetBool("IsKicking", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy != null && enemy._hp > 0)
        {
            _audio.PlayOneShot(_kickHit[Random.Range(0, _kickHit.Length)]);
            Instantiate(_bloodEffect, transform.position, Quaternion.identity);
            enemy.TakeDamage(_kickDamage);
        }
    }
}
