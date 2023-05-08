using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField, Tooltip("If DOT this is DPS, otherwise this is total")] float Damage;
    [SerializeField] bool MultiTarget;
    [SerializeField] bool DOT = false;
    [SerializeField] float Duration = 5;

    private void Start()
    {
        Destroy(gameObject, Duration);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<StateAgent>(out var Zombie))
        {
            if (DOT)
            {
                Zombie.Health.Damage(Damage * Time.deltaTime);
            }
            else
            {
                Zombie.Health.Damage(Damage);
                if (!MultiTarget)
                    Destroy(this);
            }
        }
    }
}
