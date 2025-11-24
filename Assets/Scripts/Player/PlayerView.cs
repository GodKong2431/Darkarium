using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    [Header("PlayerPresenter")]
    [SerializeField] private PlayerPresenter _playerPresenter;

    [Header("Attack Collider")]
    [SerializeField] private GameObject _attackColliderObj;

    private InputAction _move;
    private InputAction _attack;

    private Rigidbody2D _playerRigid;

    public Vector2 MoveInput {  get; private set; }

    Animator _anim;

    private Coroutine _hitCoroutine = null;

    private void Awake()
    {
        _playerPresenter = new PlayerPresenter(this, new PlayerModel());
        ActionInit();
        ComponentInit();
        _attackColliderObj.SetActive(false);
    }
    private void ActionInit()
    {
        _move = InputSystem.actions["Move"];
        _attack = InputSystem.actions["Attack"];
    }
    private void ComponentInit()
    {
        _playerRigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _move.started += (ctx) =>
        {
            _playerPresenter.ChangeIsMove(true);
        };
        _move.performed += (ctx) =>
        {
            MoveInput = ctx.ReadValue<Vector2>();
        };

        _move.canceled += (ctx) =>
        {
            MoveInput = Vector2.zero;
            _playerPresenter.ChangeIsMove(false);
        };

        _attack.started += (ctx) =>
        {
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                Debug.Log("Already attacking, cannot attack again now.");
                return;
            }
            StartAttack();
        };
    }

    private void Update()
    {
        _playerRigid.linearVelocity = MoveInput * _playerPresenter.GetMoveSpeed();
    }

    private void StartAttack()
    {
        if (_playerPresenter.GetIsAttack()) return;

        _playerPresenter.ChangeAttack(true);
        StartCoroutine(AttackCoroutine());
    }
    private IEnumerator AttackCoroutine()
    {
        _attackColliderObj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _attackColliderObj.SetActive(false);
        _playerPresenter.ChangeAttack(false);
    }


    public void StartHit(int damage)
    {
        if(_hitCoroutine != null) return;
        _playerPresenter.ChangeCurrentHP(damage);
        _hitCoroutine = StartCoroutine(HitCoroutine(damage));
    }

    private IEnumerator HitCoroutine(int damage)
    {
        Debug.Log("Player took " + damage + " damage, current HP: " + _playerPresenter.GetHealth());
        _playerPresenter.ChangeHit(true);
        yield return new WaitForSeconds(0.1f);
        _playerPresenter.ChangeHit(false);
        _hitCoroutine = null;
    }
}

    
