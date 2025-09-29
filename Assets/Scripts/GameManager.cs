using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Players")]
    // List of players
    public List<ControllerPlayer> players;

    [Header("Prefabs")]
    // Prefabs
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;
    public GameObject meteorPrefab;

    [Header("Game Data")]
    // Any other variables that our game needs
    public float score;
    public float topScore;
    public int startLives;
    public List<Transform> meteorSpawnPoints;

    [Header("Game States")]
    public GameObject mainMenuObject;
    public GameObject gameplayObject;
    public GameObject gameOverObject;

    public void Awake()
    {
        // Is there anything in the shared instance variable????
        if (instance != null)
        {
            // Self destruct!
            Destroy(gameObject);
        } else
        {
            // Else, there is no game manager yet -- we are the first one -- save that we exist
            instance = this;
        }
    }

    public Vector3 GetRandomSpawnPoint()
    {
        int spawnPointIndex = Random.Range(0, meteorSpawnPoints.Count);
        return (meteorSpawnPoints[spawnPointIndex].position);
    }

    public void SpawnMeteor()
    {
        GameObject newMeteor = Instantiate(meteorPrefab, 
                                           GetRandomSpawnPoint(), 
                                           Quaternion.identity) as GameObject;
        
        // Point at the player
        if (players[0].pawn != null)
        {
            newMeteor.transform.up = players[0].pawn.transform.position - newMeteor.transform.position;
        }
        // newMeteor.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    public void Start()
    {
        ShowMainMenu();
    }
    public void Update()
    {
        // If we are in gameplay mode
        if (gameplayObject.activeInHierarchy)
        {
            // Do our gameplay stuff
            GameplayStuff();
        }
    }

    public void GameplayStuff()
    {
        // Do our gameplay stuff
        // TODO: Update the GameUI
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void SpawnPlayerController()
    {
        // Instantiate our player and get the controller component
        GameObject newControllerObject = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);
        ControllerPlayer newControllerPlayerComponent = newControllerObject.GetComponent<ControllerPlayer>();
        // store controller component in Player 0
        players.Add(newControllerPlayerComponent);
    }

    public void SpawnPlayer()
    {
        // If the player currently has a pawn (is still alive), destroy it
        if (players[0].pawn != null) 
        {
            Destroy(players[0].pawn.gameObject);
        }

        // Instantiate a player pawn
        GameObject newPawnObject = Instantiate(playerPawnPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (newPawnObject != null)
        {
            Pawn newPawn = newPawnObject.GetComponent<Pawn>();
            if (newPawn != null)
            {
                players[0].pawn = newPawn;
            }
        }

    }

    public void ShowMainMenu()
    {
        // Turn off the gameplay screen
        gameplayObject.SetActive(false);

        // Turn off the Game over Screen
        gameOverObject.SetActive(false);

        // Turn ON the main menu screen
        mainMenuObject.SetActive(true);
    }

    public void ShowGameOverScreen()
    {
        // Turn off the gameplay screen
        gameplayObject.SetActive(false);

        // Turn OFF the main menu screen
        mainMenuObject.SetActive(false);

        // Turn ON the Game over Screen
        gameOverObject.SetActive(true);
    }

    public void StartGameplay()
    {
        // Turn off the main menu
        mainMenuObject.SetActive(false);

        // Turn off the game over screen (if it is running)
        gameOverObject.SetActive(false);

        // Turn ON the gameplay screen
        gameplayObject.SetActive(true);

        //  Make the players list
        players = new List<ControllerPlayer>();

        // Spawn the Player Controller
        SpawnPlayerController();

        // Spawn the Player Pawn
        SpawnPlayer();

        // Set players lives to starting lives
        DeathGameOver playerDeathComponent = players[0].pawn.GetComponent<DeathGameOver>();
        if (playerDeathComponent != null)
        {
            playerDeathComponent.lives = startLives;
        }

        // Spawn a meteor
        SpawnMeteor();
    }

}
