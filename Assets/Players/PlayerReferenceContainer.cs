using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceContainer : MonoBehaviour
{
    [SerializeField] private HealthSystem playersHealthSystem;
    [SerializeField] private PlayerInput playersInput;
    [SerializeField] private PlayerVisuals playersVisuals;
    [SerializeField] private AttackScript playersAttack;
    [SerializeField] private BlockScript playersBlock;

    public HealthSystem PlayersHealthSystem
    {
        get { return playersHealthSystem; }
    }
    public PlayerInput PlayersInput { 
        get { return playersInput; }
    }
    public PlayerVisuals PlayersVisuals {
        get { return playersVisuals; }
    }
    public AttackScript PlayersAttack
    {
        get { return playersAttack; }
    }
    public BlockScript PlayersBlock
    {
        get { return playersBlock; }
    }
}
