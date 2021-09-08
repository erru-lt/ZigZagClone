
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private Transform _platformPrefab;

    private PlatformPool _platformPool;

    private Vector3 _lastPlatformPosition;

    private readonly int startPlatformCount = 10;

    private float _spawnTimer;
    private readonly float _spawnTimerMax = 0.2f;


    private void Start()
    {   
        _spawnTimer = _spawnTimerMax;
        _platformPool = FindObjectOfType<PlatformPool>();
        _lastPlatformPosition = Vector3.zero;
        CreatePlatformsOnStart();
    }

    private void Update()
    {
        if(GameManager.Instance.IsGameStarted)
        _spawnTimer -= Time.deltaTime;
        if(_spawnTimer <= 0)
        {
            SpawnSide();
            _spawnTimer = _spawnTimerMax;
        }
    }

    private void SpawnSide()
    {
        int randomIndex = Random.Range(0, 2);

        switch(randomIndex)
        {
            case 0:
                CreatePlatformOnXAxis();
                break;

            case 1:
                CreatePlatformOnZAxis();
                break;
        }

    }

    private void CreatePlatformsOnStart()
    {
        for (int i = 0; i < startPlatformCount; i++)
        {
            CreatePlatformOnZAxis();
        }
    }

    private void CreatePlatformOnXAxis()
    {
        Transform platform = _platformPool.GetPlatformFromPool();
        platform.position = new Vector3(_lastPlatformPosition.x + 1, _lastPlatformPosition.y, _lastPlatformPosition.z);

        _lastPlatformPosition = platform.position;
    }

    private void CreatePlatformOnZAxis()
    {
        Transform platform = _platformPool.GetPlatformFromPool();
        platform.position = new Vector3(_lastPlatformPosition.x, _lastPlatformPosition.y, _lastPlatformPosition.z + 1);

        _lastPlatformPosition = platform.position;
    }

    
}
