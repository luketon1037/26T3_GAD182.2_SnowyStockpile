using UnityEngine;

public class BarrierSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _barrierObject;

    [Header("Spawning Details")]
    [SerializeField] private float _maxSpawnInterval;
    [SerializeField] private float SpawnInterval;
    [SerializeField] private float timer = 0f;

    private void Start()
    {
        _maxSpawnInterval = Random.Range(0.5f, 4f);
    }
    private void Update()
    {
        SpawnInterval = Time.deltaTime;
        timer += Time.deltaTime;

        if (timer >= _maxSpawnInterval)
        {
            _maxSpawnInterval = Random.Range(0.5f, 4f);
            SpawnBarrier();
            timer = 0f;
        }
    }

    private void SpawnBarrier()
    {
        Instantiate(_barrierObject, transform.position, Quaternion.identity);
    }
}
