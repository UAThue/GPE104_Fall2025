using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public bool selfDestructOnCollision = false;
    public float damageDone = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collisionData)
    { 
        // Debug.Log(gameObject.name + " collided with " + collisionData.gameObject.name);

        // Get the health component on the other object
        Health otherObjectHealth = collisionData.gameObject.GetComponent<Health>();

        // if that pawn exists!
        if (otherObjectHealth != null)
        {
            // Tell it to take damage
            otherObjectHealth.TakeDamage(damageDone);
        }

        // See if we should self destruct?
        if (selfDestructOnCollision)
        {
            Destroy(gameObject);
        }
    }

}
