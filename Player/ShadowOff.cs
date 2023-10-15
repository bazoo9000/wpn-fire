using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowOff : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void Update()
    {
        if (_anim.GetBool("IsJumping"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}