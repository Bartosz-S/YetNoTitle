using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Image healthBar;

    public void OnHealthChanged() {
        HealthSystem playerHealth = player.GetComponent<HealthSystem>();
        healthBar.fillAmount = (float)playerHealth.HealthPoints / playerHealth.MaxHealthPoints;
    }


}
