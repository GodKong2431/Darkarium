using System;
using Unity.Behavior;
using Unity.VisualScripting;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "AttackCooldown", story: "[Cooldown] is Over", category: "Conditions", id: "fd3c6e71919442dab1e43c0e86cc95d8")]
public partial class AttackCooldownCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> Cooldown;

    private float lastAttackTime = 0;

    public override bool IsTrue()
    {
        if (Time.time - lastAttackTime < Cooldown)
            return false;


        lastAttackTime = Time.time;

        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
