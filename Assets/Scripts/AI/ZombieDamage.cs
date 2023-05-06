using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ZombieDamage : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float HealthDamage;
    Rigidbody rb;
    bool isEnabled = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Toggles if the object is enabled
    /// </summary>
    /// <returns>If the object is enabled</returns>
    public bool ToggleEnabled()
    {
        isEnabled = !isEnabled;
        gameObject.SetActive(isEnabled);
        return isEnabled;
    }

    /// <summary>
    /// Sets if the object is enabled
    /// </summary>
    public void SetEnabled(bool toSet)
    {
        isEnabled = toSet;
        gameObject.SetActive(isEnabled);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.Health.Damage(HealthDamage);
        }
    }
}
