using UnityEngine;

public class PawnSpaceship : Pawn
{
    public float moveSpeed; // The speed the pawn moves
    public float rotateSpeed; // The speed the pawn rotates

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move (Vector3 moveVector)
    {
        transform.position = transform.position + ((moveVector * moveSpeed) * Time.deltaTime);
    }

    public override void Rotate(float angle)
    {
        transform.Rotate(new Vector3(0, 0, angle * rotateSpeed) * Time.deltaTime); 
    }

}
