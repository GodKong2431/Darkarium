using UnityEngine;

public static class PlayerSystems
{
    public static PlayerPresenter Player { get; private set; } = null;


    public static void RegisterPlayer(PlayerPresenter playerPresenter)
    {
        if (Player == null)
            Player = playerPresenter;
    }
}
