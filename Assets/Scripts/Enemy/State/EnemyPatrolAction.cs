using System;
using Unity.AppUI.Core;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "EnemyPatrol", story: "[Self] Wander [RandomPos] with [MoveSpeed] and Change [Dir] [Anim]", category: "Action", id: "6550b0c03c56319a7bd308cf90586b56")]
public partial class EnemyPatrolAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> RandomPos;
    [SerializeReference] public BlackboardVariable<int> MoveSpeed;
    [SerializeReference] public BlackboardVariable<DirType> Dir;
    [SerializeReference] public BlackboardVariable<Animator> Anim;
    Vector3 _target;
    float _starttime;
    protected override Status OnStart()
    {
        _starttime = Time.time;
        _target = Self.Value.transform.position;
        _target += new Vector3(
            UnityEngine.Random.Range(-RandomPos, RandomPos),
            UnityEngine.Random.Range(-RandomPos, RandomPos)
            );

        Vector2 dir = _target - Self.Value.transform.position;

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
        if(Time.time - _starttime > 3)
            return Status.Success;

        Self.Value.transform.position = Vector3.MoveTowards(Self.Value.transform.position, _target, MoveSpeed.Value * Time.deltaTime);

        Anim.Value.SetFloat("IWR", 0.5f);
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

        if (Self.Value.transform.position == _target)
        {
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

