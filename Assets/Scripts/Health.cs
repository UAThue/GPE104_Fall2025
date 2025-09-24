using UnityEngine;

public class Health : MonoBehaviour
{
    // Data (variables)
    // Current Health
    private float currentHealth;
    [SerializeField] private float maxHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start with max health!
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float damage)
    {
        Debug.Log(gameObject.name + "took damage");
        currentHealth = currentHealth - damage; 
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage (float damage, Controller damageDealer)
    {
        // TODO: Give points to the damage dealer for dealing damage
        // For now, debug who did the damage
        Debug.Log(damageDealer.gameObject.name + " did " + damage + " damage to " + this.gameObject.name);

        // Actually take the damage
        TakeDamage (damage);
    }

    public void Heal(float healAmount)
    {
        currentHealth = currentHealth + healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Die()
    {
        //Get the death component
        Death deathComponent = GetComponent<Death>();

        //Tell the death component to Die        
        if (deathComponent != null)
        {
            deathComponent.Die();
        } else
        {
            Debug.LogWarning("Warning: " + gameObject.name + "has no death component.");
        }
    }



}
