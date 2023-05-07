using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(StateAgent owner, string name) : base(owner, name)
    {

    }
    public override void OnEnter()
    {
        owner.movement.Stop();
        owner.timer.value = 2.7f;
        owner.animator.SetTrigger("Attack");
        owner.Weapon.GetComponent<ZombieDamage>().SetEnabled(true);
    }

    public override void OnExit()
    {
        owner.Weapon.GetComponent<ZombieDamage>().SetEnabled(false);
    }

    public override void OnUpdate()
    {
    }
}
