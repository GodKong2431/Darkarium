using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChangeDir", story: "[Player] Change Dir [Anim]", category: "Action", id: "1b6843ae74fafd79c477cc254c9f5345")]
public partial class ChangeDirAction : Action
{
    [SerializeReference] public BlackboardVariable<DirType> Player;
    [SerializeReference] public BlackboardVariable<Animator> Anim;



    Vector2 _moveInput => PlayerSystems.Player.PlayerView.MoveInput;
    protected override Status OnStart()
    {
        if (_moveInput == Vector2.zero)
        {
            return Status.Failure;
        }

        if (MathF.Abs(_moveInput.x) > MathF.Abs(_moveInput.y))
        {
            Player.Value = _moveInput.x > 0 ? DirType.Right : DirType.Left;
        }
        else
        {
            Player.Value = _moveInput.y > 0 ? DirType.Back : DirType.Front;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        switch (Player.Value)
        {
            case DirType.Back:
                Anim.Value.SetInteger("Direction", (int)DirType.Back);
                break;
            case DirType.Front:
                Anim.Value.SetInteger("Direction", (int)DirType.Front);
                break;
            case DirType.Left:
                Anim.Value.SetInteger("Direction", (int)DirType.Left);
                break;
            case DirType.Right:
                Anim.Value.SetInteger("Direction", (int)DirType.Right);
                break;
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

