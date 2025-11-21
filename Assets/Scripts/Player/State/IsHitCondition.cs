using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsHit", story: "IsHit True", category: "Conditions", id: "f2813348db2ce48c7e6072371948abbc")]
public partial class IsHitCondition : Condition
{

    public override bool IsTrue()
    {
        if(PlayerSystems.Player.GetIsHit() == false)
        {
            return false;
        }
        PlayerSystems.Player.ChangeHit(false);
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
