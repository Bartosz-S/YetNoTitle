using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] private int maxStamina;
    private int stamina = 0;

    private void Awake()
    {
        stamina = maxStamina;
    }

    public void TakeStaminaDamage(int damageValue)
    {
        stamina -= damageValue;
    }

    public void TakeStaminaRegen(int regenValue)
    {
        stamina += regenValue;
    }

    public bool StaminaCheck(int value)
    {
        if(value >= stamina)
        {
            return false;
        }
        return true;
    }
}
