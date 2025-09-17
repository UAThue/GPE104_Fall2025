using UnityEngine;

public class ControllerPlayer : Controller
{
    public Pawn pawn; // The pawn we control
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    }
}
