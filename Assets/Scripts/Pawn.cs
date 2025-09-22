using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Health health;
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
    }
}

