using UnityEngine;

public class SuspectController : MonoBehaviour
// This script's job is to know where the hiding spots are, which spot the suspect is at currently, and move the suspect between them
{
    public HidingTarget[] cover;

    private int currentCoverIndex = 0;

    void Start()
    {
        // Sets the first hiding spot for the suspect to hide in
        if (cover.Length > 0)
        {
            // Random range to choose hiding spot for the suspect to hide in
            currentCoverIndex = Random.Range(0, cover.Length);
            transform.position = cover[currentCoverIndex].transform.position;
        }
    }
}