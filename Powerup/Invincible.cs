using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Invincible")]
public class Invincible : PowerUpEffect
{
    public static float _buffDuration = 10f;
    public static float _timer = 0f;
    public static bool _isInvincible = false;

    public override void Apply(GameObject target)
    {
        Player player = target.transform.GetComponent<Player>();

        if (player != null)
        {
            _isInvincible = true;
        }
    }

    public static void Stop()
    {
        _timer += Time.deltaTime;
        if (_timer > _buffDuration)
        {
            _timer = 0; // in caz ca va aparea alt buff
            _isInvincible = false;
        }
    }
}