using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int currentHP;

    public int AttackDamage;

    [SerializeField] private GameObject _attackColliderObj;

    public GameObject attackCollider => _attackColliderObj;

    private Coroutine _hitCoroutine;
    private Animator _anim;
    private void Awake()
    {
        _attackColliderObj.SetActive(false);
        TryGetComponent<Animator>(out _anim);
    }

    public void StartHit(int damage)
    {
        if (_hitCoroutine != null) return;
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            _anim.SetTrigger("Die");
            Destroy(gameObject, 1.5f);
        }
            

        _hitCoroutine = StartCoroutine(HitCoroutine(damage));
    }

    private IEnumerator HitCoroutine(int damage)
    {
        Debug.Log("Enemy took " + damage + " damage, current HP: " + currentHP);
        _anim.SetTrigger("Hurt");
        yield return new WaitForSeconds(0.5f);
        _hitCoroutine = null;
    }
}
