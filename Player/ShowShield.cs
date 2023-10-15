using UnityEngine;

public class ShowShield : MonoBehaviour
{
    public SpriteRenderer _shield;

    private void Update()
    {
        if (Invincible._isInvincible || Player._immuneAtStart)
        {
            _shield.enabled = true;
        }
        else
        {
            _shield.enabled = false;
        }
    }
}