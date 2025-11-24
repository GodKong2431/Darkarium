using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "[Self] Chase to [Player] and Change [Dir] [Anim]", category: "Action", id: "c2753d09221ba78f664ad83e3108ae8b")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<DirType> Dir;
    [SerializeReference] public BlackboardVariable<Animator> Anim;
    protected override Status OnStart()
    {
        Vector2 dir = Player.Value.transform.position - Self.Value.transform.position;

        if (MathF.Abs(dir.x) > MathF.Abs(dir.y))
        {
            Dir.Value = dir.x > 0 ? DirType.Right : DirType.Left;
        }
        else
        {
            Dir.Value = dir.y > 0 ? DirType.Back : DirType.Front;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Self.Value.gameObject.transform.position = Vector3.MoveTowards(
            Self.Value.transform.position,
            Player.Value.transform.position,
            2f * Time.deltaTime);

        Anim.Value.SetFloat("IWR", 1f);

        switch (Dir.Value)
        {
            case DirType.Back:
                Anim.Value.SetInteger("Dir", (int)DirType.Back);
                break;
            case DirType.Front:
                Anim.Value.SetInteger("Dir", (int)DirType.Front);
                break;
            case DirType.Left:
                Anim.Value.SetInteger("Dir", (int)DirType.Left);
                break;
            case DirType.Right:
                Anim.Value.SetInteger("Dir", (int)DirType.Right);
                break;
        }

        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

