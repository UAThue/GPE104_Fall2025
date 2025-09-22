using UnityEngine;

public class TESTSDELETEME : MonoBehaviour
{
    public Pawn pawnToTest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            pawnToTest.health.TakeDamage(1);
        }
    }
}
