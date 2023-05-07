using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfall : Spell
{
    [SerializeField] GameObject OnCollisionCreation;
    [SerializeField] float Speed = 10;
    [SerializeField] float Gravity = -5f;
    private Vector3 forward;

    private void Start()
    {
        Destroy(gameObject, SpellDuration);
        forward = Owner.transform.forward;
    }

    void Update()
    {
        var t = transform.position;
        t   += Speed * Time.deltaTime * forward;
        t.y += Gravity * Time.deltaTime;
        transform.position = t;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DestroyOnContact && !Owner.CompareTag(other.tag))
        {
            Destroy(gameObject, .05f);
            Vector3 spawn = gameObject.transform.position;
            spawn.y -= 1f;

            if (Physics.Raycast(new(transform.position, Vector3.down), out RaycastHit hit))
                spawn = hit.point;

            Instantiate(OnCollisionCreation, spawn, gameObject.transform.rotation);
        }
    }
}
