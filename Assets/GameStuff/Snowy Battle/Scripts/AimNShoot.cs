using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimNShoot : MonoBehaviour
{
    [SerializeField] private GameObject cannon;
    [SerializeField] private GameObject snowBall;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    // Update is called once per frame
    void Update()
    {
        HandleCannonHandle();
        HandleCannonShooting();
    }

    private void HandleCannonHandle()
    {
        // Rotate the cannon where the mouse is pointing.
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)cannon.transform.position).normalized; // (Vector2) is added because cannon.transform.position is actually a Vector3. // Normalized helps unity to Handles (0, 0, 0) safely/don't get weird behavior
        cannon.transform.right = direction; // Rotate the cannon to point towards the mouse position.

        Debug.Log("Move!");

        // Flip cannon to left.
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (cannon.transform.rotation.z > 90 || cannon.transform.rotation.z < -90)
        {
            localScale.y = -1f;
        }
        else
        {             
            localScale.y = 1f;
        }
        cannon.transform.localScale = localScale;

    }

    private void HandleCannonShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("fire!");
            // Implement shooting logic here.
        }
    }
}
