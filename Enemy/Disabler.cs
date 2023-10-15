using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (!_anim.GetBool("isAlive"))
        {
            foreach (Collider2D c in GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
        }
    }
}
