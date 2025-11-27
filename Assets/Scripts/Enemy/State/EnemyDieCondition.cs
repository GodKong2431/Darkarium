using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "EnemyDie", story: "[Self] Is Die", category: "Conditions", id: "3297273bce2415ffde1896bbd49cef8f")]
public partial class EnemyDieCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    public override bool IsTrue()
    {
        if(Self.Value.TryGetComponent<Enemy>(out var enemy))
        {
            if(enemy.isDead)
            {
                return false;
            }
        }
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
