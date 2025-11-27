using UnityEngine;

public class Plants2Enemy : Enemy
{
    public Plants2Enemy()
    {
        currentHP = 80;
    }

    protected override void Die()
    {
        base.Die();
        PlayerSystems.Player.ChangeGold(20);
    }
}
