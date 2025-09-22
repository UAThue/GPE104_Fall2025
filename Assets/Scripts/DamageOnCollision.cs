using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
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
        // Get the pawn on the other object
        Pawn otherPawn = collisionData.gameObject.GetComponent<Pawn>();

        // if that pawn exists!
        if (otherPawn != null)
        {
            // Tell it to take damage
            otherPawn.health.TakeDamage(1);
        }
    }

}
