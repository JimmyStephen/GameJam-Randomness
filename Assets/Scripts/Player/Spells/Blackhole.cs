using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : Spell
{
    [SerializeField] float ExpansionRate = 2.5f;
    [SerializeField] GameObject createOnDestroy;


    private void Start()
    {
        Destroy(gameObject, SpellDuration);
    }

    void Update()
    {
        gameObject.transform.localScale += ExpansionRate * Time.deltaTime * Vector3.one;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<StateAgent>(out var Zombie))
            SpellDamage.Trigger(Zombie);
    }

    private void OnDestroy()
    {
        //Instantiate(createOnDestroy, gameObject.transform.position, gameObject.transform.rotation);
    }
}
