using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFieldLogic : MonoBehaviour
{
    [SerializeField] private int damageValue;
    [SerializeField] private double damageRate;
    double time = 0;

    HealthSystem DetectedObjHPSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetectedObjHPSystem = collision.GetComponent<HealthSystem>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        DealDamageOnField();
    }

    public void DealDamageOnField()
    {
        if (time <= damageRate)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            DetectedObjHPSystem.TakeDamage(damageValue);
        }
    }
}
