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
        owner.movement.Stop();
        if(Random.Range(0, 101) < owner.ReviveChance)
        {
            ReAnimated = false;
            owner.timer.value = Random.Range(4, 8);
            owner.ReviveChance -= Random.Range(10, 26);
        }
        else
        {
            GameObject.Destroy(this.owner.gameObject, 3);
            GameManager.Instance.UpdateTotalZombies(-1);
        }
        GameManager.Instance.UpdateScore(owner.Score);
        string DeathNum = Random.Range(1, 3).ToString();
        owner.animator.SetTrigger("Dead" + DeathNum);
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
            owner.animator.SetTrigger("Revived");
        }
    }
}