using System;

public class PlayerPresenter
{
    private PlayerView _playerView;
    public PlayerModel PlayerModel { get; private set; }

    public float GetMoveSpeed() => PlayerModel.MoveSpeed;
    public PlayerStateType GetState() => PlayerModel.State;
    public DirType GetLookDir() => PlayerModel.Dir;
    public bool GetIsMove() => PlayerModel.IsMove;
    public bool GetIsAttack() => PlayerModel.IsAttack;
    public bool GetIsHit() => PlayerModel.IsHit;
    public int GetHealth() => PlayerModel.CurrentHP;

    public PlayerPresenter(PlayerView playerView, PlayerModel playerModel)
    {
        _playerView = playerView;
        PlayerModel = playerModel;
        PlayerSystems.RegisterPlayer(this);
    }
    


    public void ChangeLookDir(float x, float y)
    {
        DirType dir;

        if (Math.Abs(x) > Math.Abs(y))
        {
            dir = x > 0 ? DirType.Right : DirType.Left;
        }
        else
        {
            dir = y > 0 ? DirType.Back : DirType.Front;
        }

        PlayerModel.SetLookDir(dir);
    }

    public void ChangeState(PlayerStateType state)
    {
        PlayerModel.SetState(state);
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
}
