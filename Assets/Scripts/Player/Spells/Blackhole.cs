using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : Spell
{
    [SerializeField] float ExpansionRate = 2.5f;

    private void Start()
    {
        Destroy(gameObject, SpellDuration);
    }

    void Update()
    {
        gameObject.transform.localScale += ExpansionRate * Time.deltaTime * Vector3.one;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DestroyOnContact && !Owner.CompareTag(other.tag))
            Destroy(this.gameObject, .05f);

        if (other.TryGetComponent<StateAgent>(out var Zombie))
            SpellDamage.Trigger(Zombie);
    }
}
