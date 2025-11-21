using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CheckMove", story: "IsMove True", category: "Conditions", id: "ab64dde4da0bb027a44a416426116a3f")]
public partial class CheckMoveCondition : Condition
{
    public override bool IsTrue()
    {
        if(PlayerSystems.Player.GetIsMove() == true)
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
