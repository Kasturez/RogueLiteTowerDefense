using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Stats stats;
    public Text heatlhText;
    public HealthBar healthBar;
    private void Start() {
        healthBar.SetMaxHealth(stats.maxHP);
    }
    private void Update() {
        healthBar.SetHealth(stats.HP);
        heatlhText.text = stats.HP + " / " + stats.maxHP;
        if(Input.GetKeyDown(KeyCode.Space)){
            stats.HP--;
        }
    }
}
