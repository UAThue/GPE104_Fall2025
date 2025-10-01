using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public int lives; // The number of lives the player has
    public Pawn pawn; // The pawn we control

    public void Possess(Pawn pawnToPossess)
    {
        // Set this pawn to posses the new pawn
        pawn = pawnToPossess;
        // Set the new pawn's controller to this controller
        pawnToPossess.controller = this;

        Debug.Log(this.gameObject.name + " has possessed " + pawn.gameObject.name);
    }

    public void Unpossess()
    {
        Debug.Log(this.gameObject.name + " is Unpossessing " + pawn.gameObject.name);

        // This pawn's controller, set it to "nothing"
        pawn.controller = null;

        // this controller's pawn, set it to "nothing"
        pawn = null;

    }
}
