using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int currentHP;

    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Enemy took " + damage + " damage, current HP: " + currentHP);
    }
}
