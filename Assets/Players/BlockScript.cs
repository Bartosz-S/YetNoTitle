using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : ActionScript
{
    [SerializeField] private Collider2D BlockField;

    override public void Use()
    {
        Block();
    }
    public void Block()
    {
        Debug.Log("Parry!");
    }
}
