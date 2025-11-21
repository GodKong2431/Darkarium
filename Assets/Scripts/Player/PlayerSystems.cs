using UnityEngine;

//SO나 싱글톤에 비해서 수정이나 다른 곳에서 참조하기 쉽고 테스트에 좋음
public static class PlayerSystems
{
    public static PlayerPresenter Player { get; private set; }

    public static void RegisterPlayer(PlayerPresenter playerPresenter)
    {
        Player = playerPresenter;
    }
}
