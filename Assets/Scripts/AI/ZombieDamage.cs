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
        Debug.Log("Set Enabled");
        isEnabled = !isEnabled;
        gameObject.SetActive(isEnabled);
        return isEnabled;
    }

    /// <summary>
    /// Sets if the object is enabled
    /// </summary>
    public void SetEnabled(bool toSet)
    {
        Debug.Log("Set Enabled");
        isEnabled = toSet;
        gameObject.SetActive(isEnabled);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Enabled: " + isEnabled);
        if (!isEnabled)
            return;

        if (other.TryGetComponent(out KinematicCharacterController.Walkthrough.LandingLeavingGround.MyCharacterController player))
        {
            Debug.Log("Collision with player");
            player.Health.Damage(HealthDamage);
        }
    }
}
