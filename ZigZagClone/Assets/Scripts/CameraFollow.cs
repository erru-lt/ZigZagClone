
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;

    private Vector3 offset;
    private void Update()
    {
        CameraMovement();
    }

    private void Start()
    {
        offset = transform.position - _target.position;
    }

    private void CameraMovement()
    {
        if (CharacterGravity.Instance.IsGrounded)
        {
            transform.position = _target.position + offset;
        }
    }
}
