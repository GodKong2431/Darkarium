using UnityEngine;

public class Plants3Enemy : Enemy
{
    public Plants3Enemy()
    {
        currentHP = 100;
    }

    protected override void Die()
    {
        base.Die();
        PlayerSystems.Player.ChangeGold(30);
    }
}
