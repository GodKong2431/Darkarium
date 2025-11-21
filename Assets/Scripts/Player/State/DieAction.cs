using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Die", story: "Player HP below Zero", category: "Action", id: "254b9541cb3936c885e36c4b5273da77")]
public partial class DieAction : Action
{
    protected override Status OnStart() 
    {

        return Status.Running; 
    }

    protected override Status OnUpdate()
    {
        if(PlayerSystems.Player.PlayerModel.CurrentHP <= 0)
        {
            PlayerSystems.Player.ChangeState(PlayerStateType.Die);
            return Status.Success;
        }
        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

