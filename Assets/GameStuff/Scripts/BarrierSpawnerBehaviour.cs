using UnityEngine;

public class BarrierSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _barrierObject;

    [Header("Spawning Details")]
    [SerializeField] private float _maxSpawnInterval = 2f;

    [SerializeField] private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= _maxSpawnInterval)
        {
            SpawnBarrier();
            timer = 0f;
        }
    }

    private void SpawnBarrier()
    {
        Instantiate(_barrierObject, transform.position, Quaternion.identity);
    }
}
