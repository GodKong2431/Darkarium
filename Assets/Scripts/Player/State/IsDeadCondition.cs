using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsDead", story: "IsDead", category: "Conditions", id: "d0bf37c9e00454f9e70beee52adb1c49")]
public partial class IsDeadCondition : Condition
{

    public override bool IsTrue()
    {
        if(PlayerSystems.Player.GetHealth() <= 0)
        {
            return true;
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
