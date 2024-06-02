using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceContainer : MonoBehaviour
{
    [SerializeField] private HealthSystem playersHealthSystem;
    [SerializeField] private PlayerInput playersInput;
    [SerializeField] private PlayerVisuals playersVisuals;
    [SerializeField] private ActionScript playersAction;

    public HealthSystem PlayersHealthSystem
    {
        get { return playersHealthSystem; }
    }
    public PlayerInput PlayersInput
    {
        get { return playersInput; }
    }
    public PlayerVisuals PlayersVisuals
    {
        get { return playersVisuals; }
    }
    public ActionScript PlayersAction
    {
        get { return playersAction; }
    }
}
