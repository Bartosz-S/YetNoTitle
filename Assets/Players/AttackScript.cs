using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AttackScript : ActionScript
{
    private List<Collider2D> enemies = new List<Collider2D>();

    [SerializeField] private int damageValue;
    [SerializeField] private double attackCooldown;
    [SerializeField] private Collider2D AttackField;
    [SerializeField] private PlayerReferenceContainer container;
    private int enemyLayer;
    double time = 0;

    public override void Use()
    {
        Attack();
    }

    private void Awake()
    {
        enemyLayer = LayerMask.NameToLayer("Enemies");
        
    }

    Vector2 lastMovement = Vector2.right;

    private void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        if (Vector2.Angle(lastMovement, container.PlayersInput.MovementInput) != 0)
        {
            RotateInDirectionOfInput();
            lastMovement = container.PlayersInput.MovementInput;
        }
    }

    public void Attack()
    {
        if (time > 0)
        {
            return;
        }
        else
        {
            time = attackCooldown;
        }
        Debug.Log("Attack!");
        
        if (enemies.Count() == 0) return;
        foreach (Collider2D enemies in enemies)
        {
            if (enemies.gameObject.layer != enemyLayer)
            {
                continue;
            }
            else enemies.gameObject.GetComponent<HealthSystem>().TakeDamage(damageValue);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!enemies.Contains(collision)) { enemies.Add(collision); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemies.Contains(collision)) { enemies.Remove(collision); }
    }

    public void RotateInDirectionOfInput()
    {
        if (container.PlayersInput.MovementInput != Vector2.zero && lastMovement != Vector2.zero)
        {
            AttackField.transform.RotateAround(transform.position, Vector3.forward,
                 Vector2.SignedAngle(Vector2.right, container.PlayersInput.MovementInput) - Vector2.SignedAngle(Vector2.right, lastMovement));
        }
    }
}
