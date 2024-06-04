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
    public bool canAttack = true;

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
            container.PlayersVisuals.PlayerAnimator.SetTrigger("Attack");
            time = attackCooldown;
        }
        Debug.Log("Attack!");

        if (enemies.Count() == 0) return;
        for (int i = enemies.Count-1; i >= 0; i--)
        {
            Collider2D enemies = this.enemies[i];
            enemies.gameObject.GetComponent<HealthSystem>().TakeDamage(damageValue);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemies.Contains(collision) && collision.gameObject.layer == enemyLayer) { enemies.Add(collision); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemies.Contains(collision)) { enemies.Remove(collision); }
    }

    Vector2 lastDirection = Vector2.right;
    public void RotateInDirectionOfInput()
    {
        /*
        if (container.PlayersInput.MovementInput != Vector2.zero && lastMovement != Vector2.zero)
        {
            AttackField.transform.RotateAround(transform.position, Vector3.forward,
                 Vector2.SignedAngle(Vector2.right, container.PlayersInput.MovementInput) - Vector2.SignedAngle(Vector2.right, lastMovement));
        }*/
        if (Vector2.Angle(container.PlayersInput.MovementInput, lastDirection) > 90)
        {
            lastDirection *= new Vector2(-1, 1);
            AttackField.transform.RotateAround(transform.position, Vector3.forward, 180);
        }
    }
}