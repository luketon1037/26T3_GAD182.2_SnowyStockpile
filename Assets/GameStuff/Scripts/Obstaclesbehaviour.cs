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
        // MOVE!!!

        transform.Translate(Vector2.left * _barrierMovementSpeed * Time.deltaTime);

        //

        if (transform.position.x < _screenExit)
        {
            Destroy(gameObject);
        }
    }
}
