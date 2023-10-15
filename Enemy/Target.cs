using UnityEngine;

public class Target : MonoBehaviour
{
    public AudioClip[] _hit;

    public void TakeDamage()
    {
        GetComponentInParent<AudioSource>().PlayOneShot(_hit[Random.Range(0, _hit.Length)]);
    }
}