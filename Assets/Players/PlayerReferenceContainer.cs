using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceContainer : MonoBehaviour
{
    [SerializeField] private HealthSystem playersHealthSystem;
    [SerializeField] private PlayerInput playersInput;

    public HealthSystem PlayersHealthSystem
    {
        get { return playersHealthSystem; }
    }
    public PlayerInput PlayersInput { 
        get { return playersInput; }
    }

}
