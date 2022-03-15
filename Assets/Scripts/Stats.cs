using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int HP, MP, maxHP, maxMP;
    float damageCooldown = 0;
    public HealthBar healthBar;
    void Start()
    {
        HP = maxHP;
        MP = maxMP;
    }
    void Update()
    {
        damageCooldown = Mathf.Clamp(damageCooldown - Time.deltaTime, 0, 1);
        if (HP == 0)
            Death();
    }
    public void TakeDamage()
    {
        if (damageCooldown == 0)
        {
            HP -= 1;
            damageCooldown = 1;
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
