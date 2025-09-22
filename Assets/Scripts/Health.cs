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
        currentHealth = currentHealth - damage; 
        if (currentHealth <= 0)
        {
            Die();
        }
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
        //TODO: Get the death component
        //TODO: Tell the death component to Die
        Debug.Log("Ugh. You got me!");
    }



}
