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
    public int GetHealth() => PlayerModel.CurrentHP;

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

    public void ChangeAttack(bool isMove)
    {
        PlayerModel.SetIsAttack(isMove);
    }

    public void ChangeHit(bool isHit)
    {
        PlayerModel.SetIsHit(isHit);
    }

    public void ChangeCurrentHP(int damage)
    {
        PlayerModel.SetHP(-damage);
    }
}
