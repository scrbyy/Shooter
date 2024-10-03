using System;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public static Action<float> PlayerWalkingByX;
    public static Action<float> PlayerWalkingByZ;
    public static Action StopMoving;
    public static Action PlayerJumped;
    public static Action PlayerFalling;
    
    [SerializeField] private float _gravity;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;

    private CharacterController _playerController;

    private Vector3 direction;
    private bool isGrounded;

    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, 0.4f, _mask);

        if (isGrounded && direction.y < 0)
        {
            direction.y = -2f;
            StopMoving?.Invoke();
        }
        Move();

        CheckJump();
        direction.y -= _gravity * Time.deltaTime;

        _playerController.Move(direction * Time.deltaTime);
    }
    private void CheckJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            direction.y = Mathf.Sqrt(_jumpHeight * -2f * -_gravity);
            PlayerJumped?.Invoke();
        }
    }
    private void Move()
    {
        float MoveByX = Input.GetAxis("Horizontal");
        float MoveByZ = Input.GetAxis("Vertical");
        if (MoveByZ != 0)
        {
            PlayerWalkingByX?.Invoke(MoveByZ);
        }
        else if (MoveByX != 0) PlayerWalkingByZ?.Invoke(MoveByX);
        
        Vector3 moveVector = transform.right * MoveByX + transform.forward * MoveByZ;
        if (moveVector.x == 0 && moveVector.z == 0)
        {
            StopMoving?.Invoke();
        }
        _playerController.Move(moveVector * _speed * Time.deltaTime);
    }
}
