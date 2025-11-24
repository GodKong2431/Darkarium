using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsAttack", story: "IsAttack True", category: "Conditions", id: "15fc1e75fbf347de95777f53c22a85d3")]
public partial class IsAttackCondition : Condition
{

    public override bool IsTrue()
    {
        if(PlayerSystems.Player.GetIsAttack() == false)
        {
            return false;
        }
        PlayerSystems.Player.ChangeIsAttack(false);
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
