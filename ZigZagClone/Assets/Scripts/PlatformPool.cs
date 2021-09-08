
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] private Transform _platformPrefab;

    private Queue<Transform> _platformPool = new Queue<Transform>();

    private int _poolStartSize = 45;

    private void Awake()
    {
        InitializeStartPool();
    }

    private void InitializeStartPool()
    {
        for (int i = 0; i < _poolStartSize; i++)
        {
            Transform platformTransform = Instantiate(_platformPrefab);
            _platformPool.Enqueue(platformTransform);
            platformTransform.gameObject.SetActive(false);
        }
    }

    public Transform GetPlatformFromPool()
    {
        if(_platformPool.Count > 0)
        {
            Transform platformTransform = _platformPool.Dequeue();
            platformTransform.gameObject.SetActive(true);

            return platformTransform;
        }
        else
        {
            Transform platformTransform = Instantiate(_platformPrefab); 

            return platformTransform;
        }
    }

    public void ReturnPlatformToPool(Transform platform)
    {
        _platformPool.Enqueue(platform);
        platform.gameObject.SetActive(false);
    }
}
