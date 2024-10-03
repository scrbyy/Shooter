using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        PlayerMovement.PlayerWalkingByX += StartWalkAnimationByX;
        PlayerMovement.PlayerWalkingByZ += StartWalkAnimationByZ;
        PlayerMovement.StopMoving += StopMoving;
        PlayerMovement.PlayerJumped += StartJumpAnimation;
    }
    private void OnDisable()
    {
        PlayerMovement.PlayerWalkingByX -= StartWalkAnimationByX;
        PlayerMovement.PlayerWalkingByZ -= StartWalkAnimationByZ;
        PlayerMovement.StopMoving -= StopMoving;
        PlayerMovement.PlayerJumped -= StartJumpAnimation;
    }

    public void StartJumpAnimation()
    {
        _animator.SetBool("isJumped", true);
        _animator.SetBool("isMoving", false);
    }
    public void StopMoving()
    {
        _animator.SetFloat("MovingByX", 0f);
        _animator.SetFloat("MovingByZ", 0f);
        _animator.SetBool("isMoving", false);
        _animator.SetBool("isFalling", false);
        _animator.SetBool("isJumped", false);
    }
    public void StartWalkAnimationByX(float move)
    {
        _animator.SetFloat("MovingByX", move);
        _animator.SetBool("isMoving", true);
    }
    public void StartWalkAnimationByZ(float move)
    {
        _animator.SetFloat("MovingByZ", move);
        _animator.SetBool("isMoving", true);
    }
}

