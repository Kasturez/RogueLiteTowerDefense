using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    public Stat Damage;
    public Stat armor;
    private void Awake() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageTaken){
        currentHealth -= damageTaken;
        Debug.Log(transform.name + " Took " + damageTaken + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + " is dead.");
    }
}