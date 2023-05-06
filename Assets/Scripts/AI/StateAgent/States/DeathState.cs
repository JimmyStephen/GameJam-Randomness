using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    public DeathState(StateAgent owner, string name) : base(owner, name)
    {

    }

    public override void OnEnter()
    {
        Debug.Log("Death State");
        owner.movement.Stop();
        //If less, revive
        if(Random.Range(0, 101) < owner.ReviveChance)
        {
            ReAnimated = false;
            owner.timer.value = Random.Range(3, 7);
            owner.ReviveChance -= Random.Range(2, 10);
        }
        //if more dont
        else
        {
            GameObject.Destroy(this.owner.gameObject, .05f);
            GameManager.Instance.UpdateTotalZombies(-1);
        }
        GameManager.Instance.UpdateScore(owner.Score);
        owner.animator.SetTrigger("Death");
        //GameObject.Destroy(owner.gameObject, 3);
    }

    public override void OnExit()
    {
        //Heal to full after the revive
        owner.Health.Heal(100);
    }

    bool ReAnimated = false;
    public override void OnUpdate()
    {
        if (owner.timer.value <= 2 && !ReAnimated)
        {
            ReAnimated = true;
            owner.animator.SetTrigger("ReAnimate");
        }
    }
}