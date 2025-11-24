using UnityEngine;

public class PlayerAttackColllider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent<Enemy>(out var enemy))
            {
                enemy.TakeDamage(PlayerSystems.Player.GetDamage());
            }
            Debug.Log("Enemy hit!");
        }
    }
}
