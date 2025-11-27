using System;
using System.Collections;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Plant1Attack", story: "[Self] Attack", category: "Action", id: "660ed26e3b9685e882029adc71ff51d1")]
public partial class Plant1AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    private bool _isAttacking;
    private Enemy _enemy;

    bool _isAction;

    protected override Status OnStart()
    {
        _enemy = Self.Value.GetComponent<Plants1Enemy>();

        _isAction = StartAttack();

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (_isAction)
        {
            return Status.Success;
        }
        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }

    //private void StartAttack()
    //{
    //    _enemy.StartCoroutine(AttackCoroutine());
    //}

    //private IEnumerator AttackCoroutine()
    //{
        
    //    _enemy.attackCollider.SetActive(true);
    //    yield return new WaitForSeconds(0.1f);
    //    _enemy.attackCollider.SetActive(false);
    //}
    public bool StartAttack()
    {
        if (!_isAttacking)
        {
            _enemy.StartCoroutine(AttackCoroutine());
            return true;
        }
        return false;
    }

    private IEnumerator AttackCoroutine()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(0.35f);

        _enemy.DoAttackCheck();

        yield return new WaitForSeconds(3f);
        _isAttacking = false;
    }
}

