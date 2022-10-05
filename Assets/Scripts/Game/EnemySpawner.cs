using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _intervalTime = 1;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _intervalTime)
        {
            TrySpawnAndResetElapsedTime();
        }
    }

    private void TrySpawnAndResetElapsedTime()
    {
        if (TryGetObjectFromPool(out GameObject enemy))
        {
            _elapsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
