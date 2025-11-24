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

    private void Start()
    {
        _playerPresenter.InitPlayerStats();
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
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
            if(_playerPresenter.GetCurrentStamina() >= 10)
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

        _playerPresenter.ChangeIsAttack(true);
        _playerPresenter.ChangeCurrentStamina(-10);
        StartCoroutine(AttackCoroutine());
    }
    private IEnumerator AttackCoroutine()
    {
        _attackColliderObj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _attackColliderObj.SetActive(false);
        _playerPresenter.ChangeIsAttack(false);
    }


    public void StartHit(int damage)
    {
        if(_hitCoroutine != null) return;
        _playerPresenter.ChangeCurrentHP(damage);
        _hitCoroutine = StartCoroutine(HitCoroutine(damage));
    }

    private IEnumerator HitCoroutine(int damage)
    {
        Debug.Log("Player took " + damage + " damage, current HP: " + _playerPresenter.GetCurrentHP());
        _playerPresenter.ChangeIsHit(true);
        yield return new WaitForSeconds(0.1f);
        _playerPresenter.ChangeIsHit(false);
        _hitCoroutine = null;
    }
}

    
