using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{
    [Header("PlayerPresenter")]
    [SerializeField] private PlayerPresenter _playerPresenter;

    private InputAction _move;
    private InputAction _attack;

    private Rigidbody2D _playerRigid;

    public Vector2 MoveInput {  get; private set; }

    Animator _animator;

    private void Awake()
    {
        _playerPresenter = new PlayerPresenter(this, new PlayerModel());
        ActionInit();
        _playerRigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void ActionInit()
    {
        _move = InputSystem.actions["Move"];
        _attack = InputSystem.actions["Attack"];
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
            _playerPresenter.ChangeAttack(true);
        };
    }

    private void Update()
    {
        _playerRigid.linearVelocity = MoveInput * _playerPresenter.GetMoveSpeed();
    }
}
