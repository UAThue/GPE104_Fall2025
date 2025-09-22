using UnityEngine;

public class DeathRecenter : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        // Move the object back to the center of the universe
        transform.position = Vector3.zero;
    }
}
