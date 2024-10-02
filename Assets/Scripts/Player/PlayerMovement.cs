using UnityEngine;
[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _playerController;

    [SerializeField] private float _gravity;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    private Vector3 direction;
    private bool isGrounded;

    private void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, 0.4f, _mask);

        if (isGrounded && direction.y < 0)
        {
            direction.y = -2f;
        }
        float MoveByX = Input.GetAxis("Horizontal");
        float MoveByZ = Input.GetAxis("Vertical");
        Vector3 moveVector = transform.right * MoveByX + transform.forward * MoveByZ;
        _playerController.Move(moveVector * _speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            direction.y = Mathf.Sqrt(_jumpHeight * -2f * -_gravity);
        }

        direction.y -= _gravity * Time.deltaTime;

        _playerController.Move(direction * Time.deltaTime);
    }
}
