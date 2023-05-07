using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    [SerializeField] float HealthDamage;
    bool isEnabled = false;

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
        if (!isEnabled)
            return;

        if (other.TryGetComponent(out KinematicCharacterController.Walkthrough.LandingLeavingGround.MyCharacterController player))
        {
            player.Health.Damage(HealthDamage);
        }
    }
}
