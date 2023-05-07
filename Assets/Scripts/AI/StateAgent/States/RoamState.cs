using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
    public RoamState(StateAgent owner, string name) : base(owner, name)
    {

    }

    public override void OnEnter()
    {
        Quaternion rotation = Quaternion.Euler(0, Random.Range(-90, 90), 0);
        Vector3 forward = rotation * ((owner.transform.position.x == 0 && owner.transform.position.z == 0) ? Vector3.one : owner.transform.position);
        Vector3 destination = (owner.transform.position + forward) * Random.Range(0.5f, 1.5f);

        owner.movement.MoveTowards(destination);
        owner.movement.Resume();
        owner.atDestination.value = false;
    }


    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (Vector3.Distance(owner.transform.position, owner.movement.destination) <= 1.5)
	    {
            OnEnter();
        }
    }
}
