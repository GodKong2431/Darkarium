using System.Collections;
using Unity.Behavior;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int currentHP;
    public int AttackDamage;

    [Header("Attack Settings")]
    [SerializeField] private float attackRadius = 3.0f;

    //[SerializeField] private GameObject _attackColliderObj;
    //public GameObject attackCollider => _attackColliderObj;

    private Coroutine _hitCoroutine;
    private Animator _anim;

    private BehaviorGraphAgent _ai;

    public bool isDead => currentHP <= 0;

    private LayerMask _playerlayer = 1 << 6;

    private void Awake()
    {
        //_attackColliderObj.SetActive(false);
        TryGetComponent<Animator>(out _anim);
    }

    private void Start()
    {
        _ai = GetComponent<BehaviorGraphAgent>();
        _ai.BlackboardReference.SetVariableValue("Player", GameManager.Instance.Player);
    }

    public void StartHit(int damage)
    {
        if (_hitCoroutine != null) return;
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
            
        _hitCoroutine = StartCoroutine(HitCoroutine(damage));
    }

    private IEnumerator HitCoroutine(int damage)
    {
        _anim.SetTrigger("Hurt");
        yield return new WaitForSeconds(0.5f);
        _hitCoroutine = null;
    }

    protected virtual void Die()
    {
        _anim.SetTrigger("Die");
        GameManager.Instance.EnemyDie();
        Destroy(gameObject, 1.5f);
    }




    public void DoAttackCheck()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, attackRadius, _playerlayer);

        if (hit != null)
        {
            if (hit.TryGetComponent<PlayerView>(out var player))
            {
                player.StartHit(-AttackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
