using UnityEngine;

public class Obstaclesbehaviour : MonoBehaviour
{
    [SerializeField] private float _barrierMovementSpeed = 5f;
    [SerializeField] private float _screenExit = -10f;

    [SerializeField] private Rigidbody2D barrierRigidbody;

 

    private void Start()
    {
        barrierRigidbody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        MovementSpeed(); //Re-usable btw

        if (transform.position.x < _screenExit)
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private void MovementSpeed()
    {
        // MOVE!!! // Get a load of this guy

        transform.Translate(Vector2.left * _barrierMovementSpeed * Time.deltaTime);
    }
}
