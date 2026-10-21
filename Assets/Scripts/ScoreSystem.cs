using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    private int totalScore = 1000;
    private bool beingPlayed = false;

    private void Awake()
    {
        beingPlayed = true;
        if (Instance == null)
        {
            Instance = this;
            UpdateScoreDisplay();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        if (beingPlayed != true)
        {
            totalScore += amount;
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalScore}";
        }
    }

    private void Update()
    {
    
    }
}
