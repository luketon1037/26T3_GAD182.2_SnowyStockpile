using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimNShoot : MonoBehaviour
{
    [SerializeField] private GameObject cannon;

    private Vector2 worldPosition;
    private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        HandleCannonHandle();
    }

    private void HandleCannonHandle()
    {
        // Rotate the cannon where the mouse is pointing.
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)cannon.transform.position).normalized; // (Vector2) is added because cannon.transform.position is actually a Vector3. // Normalized helps unity to Handles (0, 0, 0) safely/don't get weird behavior
        cannon.transform.right = direction; // Rotate the cannon to point towards the mouse position.

    }
}
