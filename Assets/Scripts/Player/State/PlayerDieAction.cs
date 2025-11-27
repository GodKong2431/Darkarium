using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayerDie", story: "Player Die", category: "Action", id: "f74c4d5fa054138ed315622945b6e99f")]
public partial class PlayerDieAction : Action
{
    protected override Status OnStart()
    {
        InputSystem.actions.FindActionMap("Player").Disable();
        GameManager.Instance.InvokeGameOver();
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

