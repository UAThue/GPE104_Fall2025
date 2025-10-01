using UnityEngine;

public class ControllerPlayer : Controller
{
    public float score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pawn != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                pawn.Move(pawn.transform.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                pawn.Move(-pawn.transform.up);
            }

            if (Input.GetKey(KeyCode.A))
            {
                pawn.Rotate(1.0f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                pawn.Rotate(-1.0f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                pawn.shooter.Shoot();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                GameManager.instance.SpawnPlayer();
            }
        }
    }
}
