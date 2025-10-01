using UnityEngine;

public class DeathGameOver : Death
{
    private Pawn pawnComponent;

    void Start()
    {
        // Get our pawn component -- this way, we use the pawns controller as our controller
        pawnComponent = GetComponent<Pawn>();
    }
    public override void Die()
    {       
        if (pawnComponent.controller.lives > 0)
        {
            // Subtract a life
            pawnComponent.controller.lives = pawnComponent.controller.lives - 1;

            // Destroy the player and respawn them
            Destroy(gameObject);

            GameManager.instance.SpawnPlayer();
        }
        else
        {
            // Game over, man!
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }

    }
}
