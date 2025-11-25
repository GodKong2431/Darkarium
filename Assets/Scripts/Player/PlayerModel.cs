using System;
using Unity.VisualScripting;

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
            EventBus.Trigger<int>(EventType.PlayerHPChanged, _currentHP);
        }
    }

    public int MaxMP { get; private set; } = 50;
    private int _currentMP;
    public int CurrentMP 
    {
        get => _currentMP;
        private set
        {
            _currentMP = Math.Clamp(value, 0, MaxMP);
            EventBus.Trigger<int>(EventType.PlayerMPChanged, _currentMP);
        }
    }


    public int MaxStamina { get; private set; } = 75;
    private int _currentStamina;
    public int CurrentStamina
    {
        get => _currentStamina;
        private set
        {
            _currentStamina = Math.Clamp(value, 0, MaxStamina);
            EventBus.Trigger<int>(EventType.PlayerStaminaChanged, _currentStamina);
        }
    }



    public float MoveSpeed { get; private set; } = 5.0f;
    public bool IsMove { get; private set; } = false;
    public bool IsAttack { get; private set; } = false;
    public bool IsHit { get; private set; } = false;
    public int Damage { get; private set; } = 20;

    public void InitStats()
    {
        CurrentHP = MaxHP;
        CurrentMP = MaxMP;
        CurrentStamina = MaxStamina;
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

    public void SetHP(int hp)
    {
        CurrentHP += hp;
    }
    public void SetMP(int mp)
    {
        CurrentMP += mp;
    }
    public void SetStamina(int stamina)
    {
        CurrentStamina += stamina;
    }
}
