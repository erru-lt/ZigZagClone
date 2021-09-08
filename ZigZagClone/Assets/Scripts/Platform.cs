
using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Transform _coin;
    private PlatformPool _platformPool;
    private Rigidbody _rigidbody;

    private readonly float _delayTime = 2f;
    private readonly float _yBound = -10f;

    private float _value = 0.2f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;

        _coin = transform.Find("coin");
        _coin.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ActivateCoin();
        DisableGravity();
    }

    private void Start()
    {
        _platformPool = FindObjectOfType<PlatformPool>();
    }
    private void Update()
    {
        ReturnToPoll();
    }

    private void DisableGravity()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        _rigidbody.useGravity = false;
    }

    private void ReturnToPoll()
    {
        if (transform.position.y < _yBound)
        {
            if (_platformPool != null)
            {
                _platformPool.ReturnPlatformToPool(transform);
            }
        }
    }

    private void ActivateCoin()
    {
        float randomValue = Random.value;

        if (randomValue < _value)
        {
            _coin.gameObject.SetActive(true);
        }
    }

    private IEnumerator PlatformFallCo()
    {
        yield return new WaitForSeconds(_delayTime);
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.useGravity = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();

        if (character != null)
        {
            StartCoroutine(PlatformFallCo());
        }

    }
}
