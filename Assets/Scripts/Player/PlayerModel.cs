using System;

public class PlayerModel
{
    public int MaxHP { get; private set; } = 100;
    public int CurrentHP { get; private set; }
    public float MoveSpeed { get; private set; } = 5.0f;

    public DirType Dir { get; private set; } = DirType.Front;
    public PlayerStateType State { get; private set; } = PlayerStateType.Idle;
    public bool IsMove { get; private set; } = false;
    public bool IsAttack { get; private set; } = false;
    public bool IsHit { get; private set; } = false;

    private int _attackPower = 10;

    private event Action<int> OnHPChanged;

    public PlayerModel()
    {
        CurrentHP = MaxHP;
    }

    public void SetState(PlayerStateType state) 
    { 
        State = state; 
    }
    public void SetLookDir(DirType dir)
    {
        Dir = dir;
    }

    public void SetIsMove(bool isMove)
    {
        IsMove = isMove;
    }

    public void SetIsAttack(bool isAttack)
    {
        IsAttack = isAttack;
    }

    public void SetIsHit(bool isHit)
    {
        IsHit = isHit;
    }
}
