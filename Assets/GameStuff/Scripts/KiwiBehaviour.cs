using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Cu
/// </summary>
public class KiwiBehaviour : MonoBehaviour
{
    public bool isAlive = true;

    private bool isGrounded; // Checks dino's hability to jump.

    [SerializeField] private Rigidbody2D kiwiRigidbody;

    [SerializeField] private float _jumpHeight = 10f;
    [SerializeField] private float _rayLenght = 1f;
    [SerializeField] private LayerMask _groundLayer;

    private void Start()
    {
        Time.timeScale = 1f;
        isAlive = true;

        kiwiRigidbody = GetComponent<Rigidbody2D>(); // Gets Kiwi component.

        // Check for RigidBody
        if (kiwiRigidbody == null)
        {
            Debug.LogError("Kiwi does not have a body...");
        }
    }
    /// <summary>
    /// 
    /// FixedUpdate() = Physics & stuff.
    /// 
    /// Update() = Everything else.
    /// 
    /// </summary>

    /// <param name="callbackContext"></param> // DK why this was create but its cool

    private void FixedUpdate()
    {
        RaycastHit2D playerRaycast = Physics2D.Raycast(transform.position, Vector2.down, _rayLenght, _groundLayer);
        isGrounded = playerRaycast.collider != null;

        // Deeeeee-bug
        Debug.DrawRay(transform.position, Vector2.down * _rayLenght, Color.black);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("YEOWCH");
            Time.timeScale = 0f;
            isAlive = false; // OH
        }
    }
    public void Jump(InputAction.CallbackContext callbackContext) // Uses unity Input system.
    {
        if (callbackContext.started && isGrounded && isAlive) // Checks if callback began.
        {

            kiwiRigidbody.linearVelocity = new Vector2(kiwiRigidbody.linearVelocityX, _jumpHeight); // Takes Kiwi X coordinates.
        }
    }
}

