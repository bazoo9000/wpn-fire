using UnityEngine;

public class ShadowOffEnemy : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void Update()
    {
        if (!_anim.GetBool("isAlive"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}