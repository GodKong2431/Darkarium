using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "EnemyIdle", story: "Change Idle [Anim]", category: "Action", id: "d25c401e9bea477a65c5e14ad4b697f1")]
public partial class EnemyIdleAction : Action
{
    [SerializeReference] public BlackboardVariable<Animator> Anim;

    protected override Status OnStart()
    {
        Anim.Value.SetFloat("IWR", 0);
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

