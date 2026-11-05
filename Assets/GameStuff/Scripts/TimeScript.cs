using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    [SerializeField] KiwiBehaviour kiwiBehaviour;
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] TextMeshProUGUI RestartUI;

    private int kiwiRun = 0;
    private float scoreTimer = 0f;

    private void Awake()
    {
        
    }
    private void Update()
    {
        scoreTimer += Time.deltaTime;

        if (scoreTimer >= 1f)
        {
            kiwiRun += 1;
            scoreTimer = 0f;
            UpdateScoreText();
            
        }
        RestartGame();
    }

    private void UpdateScoreText()
    {
        scoreUI.text = "Score: " + kiwiRun.ToString();
    }

    public void RestartGame()
    {
        //if (!kiwiBehaviour.isAlive)
       //{
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // put GetActiveScene().name to get that scene without changing the scene name.
            }
       // }
    }
}
