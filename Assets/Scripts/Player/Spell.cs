using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField, Tooltip("The Manacost of the spell")]                  protected float SpellCost;
    [SerializeField, Tooltip("The Duration of the spell")]                  protected float SpellDuration;
    [SerializeField, Tooltip("The Delay before the spell takes effect")]    public float SpellDelay;
    [SerializeField, Tooltip("The damage of the spell")]                    protected PlayerDamage SpellDamage;
    [SerializeField, Tooltip("The cooldown of the spell")]                  protected float SpellCooldown;
    [SerializeField, Tooltip("If the spell is destroyed on contact")]       protected bool DestroyOnContact;
    [SerializeField, Tooltip("How long the animation lasts")]               protected float AnimationDuration;

    [Tooltip("The key pressed to cast this spell")] public KeyCode CastSpellKey;
    [HideInInspector] public GameObject Owner;

    /// <summary>
    /// Check to see if you are able to cast the spell
    /// </summary>
    /// <param name="CurrentMana">How much mana you have</param>
    /// <returns>If the spell can be cast</returns>
    public bool CheckCanCast(float CurrentMana, float CurrentCooldown, float AnimationTimer)
    {
        return CurrentMana > SpellCost && CurrentCooldown <= 0 && AnimationTimer <= 0;
    }

    public (float Cooldown, float AnimationDuration) TriggerSpell(Resource mana, float CurrentCooldown, float CurrentAnimationDuration)
    {
        if (CheckCanCast(mana.GetCurrent(), CurrentCooldown, CurrentAnimationDuration))
        {
            mana.Damage(SpellCost);
            return (SpellCooldown, AnimationDuration);
        }
        else
        {
            return (CurrentCooldown, CurrentAnimationDuration);
        }
    }
}
