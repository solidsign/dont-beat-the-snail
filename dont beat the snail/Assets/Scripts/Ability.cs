using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [HideInInspector] public int abilityID;
    [HideInInspector] public int cooldownTimer = 0;
    [HideInInspector] public float animationDelay;
    [HideInInspector] public string animationName;
    [HideInInspector] public float Cooldown = 0;

    public virtual bool Activate()
    {
        Debug.Log("Ability Activated");
        return true;
    }
}
