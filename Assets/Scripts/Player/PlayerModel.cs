using System;

public class PlayerModel
{
    public int MaxHP { get; private set; } = 100;
    private int _currentHP;

    public int CurrentHP
    {
        get => _currentHP;
        private set
        {
            _currentHP = Math.Clamp(value, 0, MaxHP);
            OnHPChanged?.Invoke(_currentHP);
        }
    }

    public float MoveSpeed { get; private set; } = 5.0f;
    public bool IsMove { get; private set; } = false;
    public bool IsAttack { get; private set; } = false;
    public bool IsHit { get; private set; } = false;
    public int Damage { get; private set; } = 20;

    private event Action<int> OnHPChanged;

    public PlayerModel()
    {
        CurrentHP = MaxHP;
    }





    public void SetHP(int hp)
    {
        CurrentHP += hp;
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
