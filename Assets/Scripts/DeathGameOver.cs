using UnityEngine;

public class DeathGameOver : Death
{
    public int lives;
    public override void Die()
    {
        if (lives > 0)
        {
            // Subtract a life
            lives = lives - 1;

            // Destroy the player and respawn them
            GameManager.instance.SpawnPlayer();
            Destroy(gameObject);
        }
        else
        {
            // Game over, man!
            GameManager.instance.ShowGameOverScreen();
            Destroy(gameObject);
        }

    }
}
