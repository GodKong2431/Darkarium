using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "EnemyPatrol", story: "[Self] Patrol [RandomPos] with [MoveSpeed]", category: "Action", id: "6550b0c03c56319a7bd308cf90586b56")]
public partial class EnemyPatrolAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> RandomPos;
    [SerializeReference] public BlackboardVariable<int> MoveSpeed;

    Vector3 target;
    protected override Status OnStart()
    {
        target = new Vector2(
            UnityEngine.Random.Range(-RandomPos, RandomPos),
            UnityEngine.Random.Range(-RandomPos, RandomPos)
            );
        return Status.Running;
    }
    protected override Status OnUpdate()
    {
        Self.Value.transform.position = Vector3.MoveTowards(Self.Value.transform.position, target, MoveSpeed.Value * Time.deltaTime);

        if(Self.Value.transform.position == target)
        {
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

