using UnityEngine;

public class BackGroundBehaviour : MonoBehaviour
{

    [SerializeField] private float MovementSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * MovementSpeed * Time.deltaTime);
    }
}
