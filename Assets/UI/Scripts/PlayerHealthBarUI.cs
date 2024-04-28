using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerReferenceContainer player;
    [SerializeField] private Image healthBar;


    private void Awake() {
        player.PlayersHealthSystem.onHealthChange.AddListener(OnHealthChanged);
    }
    public void OnHealthChanged() {
        healthBar.fillAmount = (float)player.PlayersHealthSystem.HealthPoints / player.PlayersHealthSystem.MaxHealthPoints;
    }


}
