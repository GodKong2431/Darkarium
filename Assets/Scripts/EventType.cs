public enum EventType
{
    None = 0,

    PlayerHPChanged,
    PlayerMPChanged,
    PlayerStaminaChanged,

    PlayerDied,
    EnemyDied,

    AttackStarted,
    AttackEnded,

    OnSceneLoaded,
    OnInteraction,
}
