using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChangeDir", story: "Player Change Dir [Anim]", category: "Action", id: "1b6843ae74fafd79c477cc254c9f5345")]
public partial class ChangeDirAction : Action
{
    [SerializeReference] public BlackboardVariable<Animator> Anim;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        switch (PlayerSystems.Player.GetLookDir())
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

