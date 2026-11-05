using UnityEngine;

public class WatchThisManager : MonoBehaviour
{
    // Time that the player is given to click and catch the suspect
    public HidingTarget[] cover;
    public float gameTimer = 15f;

    private bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChooseSuspect();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the game is over
        if (gameOver) return;

        gameTimer -= Time.deltaTime;

        if (gameTimer <= 0)
        {
            LoseGame();
        }
    }

    // This method chooses a spot at random to hide the suspect behind
    private void ChooseSuspect()
    {
        int randomIndex = Random.Range(0, cover.Length);
        //cover[randomIndex].SetSuspectActive(true);
    }

    // When the player clicks on the suspect, this method checks if the suspect is active and if so, the player wins the game
    public void CheckSuspectClicked(HidingTarget target)
    {
        if (gameOver) return;

        if (target.isSuspect)
        {
            WinGame();
        }
        else
        {
            // Display an incorrect message if the player does not click on the suspect
            Debug.Log("Nothing to see here... Keep searching!");
        }
    }

    private void WinGame()
    {
        gameOver = true;
        Debug.Log("Suspect caught!");
    }

    private void LoseGame()
    {
        gameOver = true;
        Debug.Log("Time's up! Suspect got away.");
    }
}


// Pseudocode for Watch This microgame:
// START
// Timer starts and is set to 10 seconds
// Randomly hide suspect in one hiding spot
// Display scene of the neighbourhood through a window
// Timer countdown begins
// While the timer is above 0, check if the player clicks on the suspect at the right time
// If suspect is clicked while out in the open, the player wins - End Game
// Otherwise, display incorrect message to player
// If timer reaches 0, the player loses and is given the failure screen
// END