using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthPack")]
public class HealthPack : PowerUpEffect
{
    public override void Apply(GameObject target)
    {
        Player player = target.transform.GetComponent<Player>();

        if (player != null)
        {
            player._hp = player._maxHp;
            player._hpBar.SetHP(player._maxHp);
        }
    }
}