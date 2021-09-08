 
using UnityEngine;
using UnityEngine.EventSystems;


public class Character : MonoBehaviour
{

    private Rigidbody _rigidbody;

    [SerializeField] private float _moveSpeed;

    private bool _isMovingRight = true;
    private float _yBound = -10;
    private readonly int _scoreToAdd = 1;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();   
    }

    private void Update()
    {
        Movement();
        InputHandle();
        CharacterFalls();
    }

    private void InputHandle()
    {
        if (Input.GetMouseButtonDown(0) && CharacterGravity.Instance.IsGrounded && !EventSystem.current.IsPointerOverGameObject())
        {
            ChangeDirection();
            GameDataManager.Instance.AddScore(_scoreToAdd);
            ScoreUI.Instance.UpdateScoreText();
        }
    }

    private void Movement()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            if (_isMovingRight)
            {
                _rigidbody.velocity = new Vector3(_moveSpeed, _rigidbody.velocity.y, 0);
            }
            else
            {
                _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, _moveSpeed);
            }
        }
    }

    private void ChangeDirection()
    {
        _isMovingRight = !_isMovingRight;
    }

    private void CharacterFalls()
    {
        if(transform.position.y < _yBound)
        {
            GameManager.Instance.GameOver();
        }
    }
}
