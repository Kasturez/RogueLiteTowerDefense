using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public CharacterStat playerStat;
    public Text heatlhText;
    public HealthBar healthBar;
    private void Start() {
        healthBar.SetMaxHealth(playerStat.currentHealth);
    }
    private void Update() {
        healthBar.SetHealth(playerStat.currentHealth);
        heatlhText.text = playerStat.currentHealth + " / " + playerStat.maxHealth;
    }
}
