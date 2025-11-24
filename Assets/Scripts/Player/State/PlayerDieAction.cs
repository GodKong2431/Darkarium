using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.InputSystem;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayerDie", story: "Player Die", category: "Action", id: "f74c4d5fa054138ed315622945b6e99f")]
public partial class PlayerDieAction : Action
{
    protected override Status OnStart()
    {
        InputSystem.actions.FindActionMap("Player").Disable();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

