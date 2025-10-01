using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Players")]
    // List of players
    public List<ControllerPlayer> players;
    public List<Meteor> meteors;

    [Header("Prefabs")]
    // Prefabs
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;
    public GameObject meteorPrefab;

    [Header("Game Data")]
    // Any other variables that our game needs
    public float topScore;
    public int startLives;
    public int targetNumberOfMeteors = 3;
    public List<Transform> meteorSpawnPoints;

    [Header("Game States")]
    public GameObject mainMenuObject;
    public GameObject gameplayObject;
    public GameObject gameOverObject;

    [Header("Sounds")]
    public AudioClip laserSound;
    public AudioClip explosionSound;
    public AudioClip collisionSound;

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
        
        // Get the meteor component
        Meteor meteorComponent = newMeteor.GetComponent<Meteor>();

        // Add it to our list!
        meteors.Add(meteorComponent);

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
            players[0].Unpossess();
        }

        // Instantiate a player pawn
        GameObject newPawnObject = Instantiate(playerPawnPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (newPawnObject != null)
        {
            // Get the pawn component
            Pawn newPawn = newPawnObject.GetComponent<Pawn>();

            // Possess the new pawn
            players[0].Possess(newPawn); 
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

        // Make our meteors list
        meteors = new List<Meteor>();

        // Spawn the Player Controller
        SpawnPlayerController();

        // Spawn the Player Pawn
        SpawnPlayer();

        // Set player zero's lives to starting lives
        players[0].lives = startLives;

        // Spawn a meteor
        for (int currentNumMeteors = 0; currentNumMeteors < targetNumberOfMeteors; currentNumMeteors++)
        {
            SpawnMeteor();
        }
    }

    public void GameOver()
    {
        // Destroy all our meteors
        for (int i=0; i<meteors.Count; i++)
        {
            if (meteors[i] != null)
            {
                Destroy(meteors[i].gameObject);
            }
        }

        // Show Game Over Screen
        ShowGameOverScreen();
    }

}
