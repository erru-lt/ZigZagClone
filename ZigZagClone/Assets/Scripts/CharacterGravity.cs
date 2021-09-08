
using UnityEngine;

public class CharacterGravity : MonoBehaviour
{

    public static CharacterGravity Instance { get; private set; }


    private Rigidbody _rigidbody;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _rayDistance;

    private bool _isGrounded;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {

        }
    }
    private void Awake()
    {
        Instance = this;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }
    private void FixedUpdate()
    {
        GroundCheck();
    }

    private void GroundCheck()
    {
        if(Physics.Raycast(transform.position, Vector3.down, _rayDistance, _groundLayer))
        {
            _isGrounded = true;
            _rigidbody.useGravity = true;
        }
        else
        {           
            _isGrounded = false;
        }
    }
}
