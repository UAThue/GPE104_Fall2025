using UnityEngine;

public class PawnSpaceship : Pawn
{
    public float moveSpeed; // The speed the pawn moves
    public float rotateSpeed; // The speed the pawn rotates

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        // This runs instead of the parent, because it overrides the parent
        // But we want the parent to run, too --- so, tell the parent to run
        base.Start();

        // TODO: Do anything a PawnSpaceship does on start
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
