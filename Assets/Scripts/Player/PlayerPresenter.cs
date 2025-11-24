using System;

public class PlayerPresenter
{
    public PlayerView PlayerView { get; private set; }
    public PlayerModel PlayerModel { get; private set; }

    public float GetMoveSpeed() => PlayerModel.MoveSpeed;
    public int GetDamage() => PlayerModel.Damage;
    public bool GetIsMove() => PlayerModel.IsMove;
    public bool GetIsAttack() => PlayerModel.IsAttack;
    public bool GetIsHit() => PlayerModel.IsHit;
    public int GetMaxHP() => PlayerModel.MaxHP;
    public int GetCurrentHP() => PlayerModel.CurrentHP;
    public int GetMaxMP() => PlayerModel.MaxMP;
    public int GetCurrentMP() => PlayerModel.CurrentMP;
    public int GetMaxStamina() => PlayerModel.MaxStamina;
    public int GetCurrentStamina() => PlayerModel.CurrentStamina;

    public PlayerPresenter(PlayerView playerView, PlayerModel playerModel)
    {
        PlayerView = playerView;
        PlayerModel = playerModel;
        PlayerSystems.RegisterPlayer(this);
    }
    

    public void ChangeIsMove(bool isMove)
    {
        PlayerModel.SetIsMove(isMove);
    }
    public void ChangeIsAttack(bool isMove)
    {
        PlayerModel.SetIsAttack(isMove);
    }
    public void ChangeIsHit(bool isHit)
    {
        PlayerModel.SetIsHit(isHit);
    }
    public void ChangeCurrentHP(int damage)
    {
        PlayerModel.SetHP(-damage);
    }
    public void ChangeCurrentMP(int mp)
    {
        PlayerModel.SetMP(mp);
    }
    public void ChangeCurrentStamina(int stamina)
    {
        PlayerModel.SetStamina(stamina);
    }
    public void InitPlayerStats()
    {
        PlayerModel.InitStats();
    }
}
