using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _intervalTime = 1;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _intervalTime)
        {
            _elapsedTime = 0;

            Spawn();
        }
    }

    private void Spawn()
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        Instantiate(_prefab, _spawnPoints[spawnPointNumber].position, Quaternion.identity);
    }
}
