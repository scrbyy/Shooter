using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _verticalSensetivity;
    [SerializeField] private float _horizontalSensetivity;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;

    private float xRotation = 0f;

    private void Update()
    {
        float lookAngleByX = Input.GetAxis("Mouse X") * _verticalSensetivity;
        float lookAngleByY = Input.GetAxis("Mouse Y") * _horizontalSensetivity;

        xRotation += lookAngleByY;
        xRotation= Mathf.Clamp(xRotation, minAngle, maxAngle);

       this.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        _player.transform.Rotate(Vector3.up * lookAngleByX);
    }
}
