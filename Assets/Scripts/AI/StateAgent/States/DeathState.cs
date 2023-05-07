using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    bool ReAnimating = false;
    bool ShouldRevive = true;
    public DeathState(StateAgent owner, string name) : base(owner, name)
    {

    }

    public override void OnEnter()
    {
        owner.movement.Stop();
        ReAnimating = false;
        if(Random.Range(0, 101) < owner.ReviveChance)
        {
            owner.timer.value = Random.Range(6, 10);
            owner.ReviveChance -= Random.Range(10, 26);
            ShouldRevive = true;
        }
        else
        {
            GameObject.Destroy(this.owner.gameObject, 3);
            GameManager.Instance.UpdateTotalZombies(-1);
            ShouldRevive = false;
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

    public override void OnUpdate()
    {
        if (owner.timer.value <= 0 + 3.5 && !ReAnimating && ShouldRevive)
        {
            ReAnimating = true;
            owner.animator.SetTrigger("Revived");
        }
    }
}