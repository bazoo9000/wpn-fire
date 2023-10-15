using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField] Animator _blood;

    void Start()
    {
        _blood.SetInteger("id", Random.Range(0, 3));
        Destroy(gameObject, 1f);
    }

}
