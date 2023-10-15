using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Berserk")]
public class Berserk : PowerUpEffect
{
    public static float _buffDuration = 10f;
    public static float _timer = 0f;
    public static bool _isBerserk = false;

    public override void Apply(GameObject target)
    {
        Player player = target.transform.GetComponent<Player>();

        if (player != null)
        {
            _isBerserk = true;
        }
    }

    public static void Stop()
    {
        _timer += Time.deltaTime;
        if (_timer > _buffDuration)
        {
            _timer = 0; // in caz ca va aparea alt buff
            _isBerserk = false;
        }
    }
}