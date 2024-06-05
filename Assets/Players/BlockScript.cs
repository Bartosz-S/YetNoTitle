using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlockScript : ActionScript
{
    [SerializeField] private Collider2D BlockField;
    [SerializeField] private PlayerReferenceContainer container;
    private int projectilesLayer;

    private void Awake()
    {
        projectilesLayer = LayerMask.NameToLayer("Projectiles");
        BlockField.enabled = false;
    }

    override public void Use()
    {
        Block();
    }
    public void Block()
    {
        if (BlockField.enabled == true)
        {
            BlockField.enabled = false;
            if (container.PlayersInput.MoveInput.enabled == false)
            {
                container.PlayersInput.MoveInput.Enable();
            }
        }
        else
        {
            BlockField.enabled = true;
            if (container.PlayersInput.MoveInput.enabled == true)
            {
                container.PlayersInput.MoveInput.Disable();
            }
        }


    }

    Vector2 lastMovement = Vector2.right;
    public void FixedUpdate()
    {
        if (BlockField.enabled == true)
        {
            container.PlayersInput.MoveInput.Disable();
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == projectilesLayer)
        {
            Destroy(collision.gameObject);
        }
    }
}