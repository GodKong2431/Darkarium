using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SaveDistanceToTarget", story: "Check Distance [Self] and [Target] save [DistanceToTarget]", category: "Action", id: "e598db12657e2fc3dccc5ab471a4d0a2")]
public partial class SaveDistanceToTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> DistanceToTarget;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        DistanceToTarget.Value = Vector3.Distance(Self.Value.transform.position, Target.Value.transform.position);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

