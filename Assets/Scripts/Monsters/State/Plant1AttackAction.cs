using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Plant1Attack", story: "[Self] Attack With [AtkDamage]", category: "Action", id: "660ed26e3b9685e882029adc71ff51d1")]
public partial class Plant1AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<int> AtkDamage;

    private Enemy _enemy;

    protected override Status OnStart()
    {
        _enemy = Self.Value.GetComponent<PlantsEnemy>();

        StartAttack();

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
        
    }

    private void StartAttack()
    {
        _enemy.StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        _enemy.attackCollider.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _enemy.attackCollider.SetActive(false);
    }
}

