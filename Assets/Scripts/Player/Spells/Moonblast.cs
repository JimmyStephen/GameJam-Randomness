using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonblast : Spell
{
    [SerializeField] float Speed = 10;
    private Vector3 forward;

    public void Start()
    {
        Destroy(gameObject, SpellDuration);
        forward = Owner.transform.forward;
    }

    void Update()
    {
        var t = transform.position;
        t += Speed * Time.deltaTime * forward;
        transform.position = t;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DestroyOnContact && !Owner.CompareTag(other.tag))
            Destroy(this.gameObject, .05f);
        if (other.TryGetComponent<StateAgent>(out var Zombie))
            SpellDamage.Trigger(Zombie);
    }
}
