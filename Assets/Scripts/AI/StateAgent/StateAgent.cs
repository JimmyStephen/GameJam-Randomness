using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAgent : Agent
{
    [SerializeField] public Perception perception;
    [SerializeField] public GameObject Weapon;
    [SerializeField] public Resource Health;
    [SerializeField] public int Score = 100;
    public StateMachine stateMachine = new StateMachine();

    public BoolRef atDestination;
    public BoolRef enemySeen;
    public FloatRef health;
    public FloatRef enemyDistance;
    public FloatRef timer;

    public GameObject enemy { get; set; }
    [HideInInspector] public int ReviveChance = 100;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine.AddState(new ChaseState(this, typeof(ChaseState).Name));
        stateMachine.AddState(new DeathState(this, typeof(DeathState).Name));
        stateMachine.AddState(new AttackState(this, typeof(AttackState).Name));
        stateMachine.AddState(new RoamState(this, typeof(RoamState).Name));

        //to roam : If no enemy seen || timer <= 0
        stateMachine.AddTransition(typeof(ChaseState).Name, new Transition(new Condition[] { new BoolCondition(enemySeen, false) }), typeof(RoamState).Name);
        stateMachine.AddTransition(typeof(DeathState).Name, new Transition(new Condition[] { new FloatCondition(timer, Condition.Predicate.LESS_EQUAL, 0) }), typeof(RoamState).Name);

        //to chase : If enemy seen || timer <= 0
        stateMachine.AddTransition(typeof(RoamState).Name, new Transition(new Condition[] { new BoolCondition(enemySeen, true) }), typeof(ChaseState).Name);
        stateMachine.AddTransition(typeof(AttackState).Name, new Transition(new Condition[] { new FloatCondition(timer, Condition.Predicate.LESS_EQUAL, 0) }), typeof(ChaseState).Name);

        //to death : If dead
        stateMachine.AddTransition(typeof(ChaseState).Name, new Transition(new Condition[] { new FloatCondition(health, Condition.Predicate.LESS_EQUAL, 0) }), typeof(DeathState).Name);
        stateMachine.AddTransition(typeof(RoamState).Name, new Transition(new Condition[] { new FloatCondition(health, Condition.Predicate.LESS_EQUAL, 0) }), typeof(DeathState).Name);

        //to Attack State : If enemy seen and in range
        stateMachine.AddTransition(typeof(ChaseState).Name, new Transition(new Condition[] { new FloatCondition(enemyDistance, Condition.Predicate.LESS_EQUAL, 1.5f) }), typeof(AttackState).Name);

        stateMachine.setState(stateMachine.StateFromName(typeof(RoamState).Name));
    }

    // Update is called once per frame
    void Update()
    {
        health.value = Health.GetCurrent();
        timer.value -= Time.deltaTime;
        var enemies = perception.GetGameObjects();
        enemySeen.value = (enemies.Length != 0);
        enemy = (enemies.Length != 0) ? enemies[0] : null;
        enemyDistance.value = (enemy != null) ? (Vector3.Distance(transform.position, enemy.transform.position)) : float.MaxValue;

        stateMachine.Update();
        animator.SetFloat("Speed", movement.velocity.magnitude);
    }
}
