using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Health health;
    public Shooter shooter;
    public Controller controller;
    public abstract void Move(Vector3 moveVector);
    public abstract void Rotate(float angle);
    protected virtual void Start ()
    {
        // Load the health component
        health = GetComponent<Health>();
        // Verify that the health component was "got"
        if (health == null)
        {
            Debug.LogWarning(gameObject.name + " does not have a health component");
        }

        // Load the shooter component
        shooter = GetComponent<Shooter>();

        //TODO: Verify that we got the shooter component
    }


}

