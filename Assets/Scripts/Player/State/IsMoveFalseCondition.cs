using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsMoveFalse", story: "IsMove False", category: "Conditions", id: "5dbc81919fbc0b4278028b03bee55488")]
public partial class IsMoveFalseCondition : Condition
{

    public override bool IsTrue()
    {
        if(PlayerSystems.Player.GetIsMove() == false)
        {
            return true;
        }
        return false;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
