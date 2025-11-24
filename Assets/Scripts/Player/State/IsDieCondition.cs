using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsDie", story: "Is Die Check", category: "Conditions", id: "01a2dc8c5fcd6526573897c4392f9e18")]
public partial class IsDieCondition : Condition
{

    public override bool IsTrue()
    {
        if(PlayerSystems.Player.GetHealth() <= 0)
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
