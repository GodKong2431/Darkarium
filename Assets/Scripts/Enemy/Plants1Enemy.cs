using UnityEngine;

public class Plants1Enemy : Enemy
{
    public Plants1Enemy()
    {
        currentHP = 60;
    }

    protected override void Die()
    {
        base.Die();
        PlayerSystems.Player.ChangeGold(10);
    }
}
