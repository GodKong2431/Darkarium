using Unity.Behavior;

[BlackboardEnum]
public enum DirType
{
    Back,
	Front,
	Left,
	Right
}

[BlackboardEnum]
public enum PlayerStateType
{
    Idle,
    Walk,
    Attack,
    Hit,
    Die
}
