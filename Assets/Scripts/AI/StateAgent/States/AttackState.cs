using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
        //Face target
        try
        {
            var lookPos = owner.enemy.transform.position - owner.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, rotation, Time.deltaTime * 2);
        }
        catch
        {
            Debug.Log("Exception - Target not found");
        }
    }
}
