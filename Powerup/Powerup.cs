// MAIN SCRIPT FOR POWERUPS!!!!
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerUpEffect _pw;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.transform.GetComponent<Player>();

        if (player != null)
        {
            Destroy(gameObject);
            _pw.Apply(other.gameObject);
        }
    }
}