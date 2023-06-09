using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public ChaseState(StateAgent owner, string name) : base(owner, name)
    {

    }

    public override void OnEnter()
    {
        owner.movement.Resume();
    }

    public override void OnExit()
    {
        owner.movement.Stop();
    }

    public override void OnUpdate()
    {
        try
        {
            owner.movement.MoveTowards(owner.enemy.transform.position);
        }
        catch { }
            
    }
}
