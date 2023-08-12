using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(WeaponManager))]
public class ShipBase : MonoBehaviour
{
    private Rigidbody Rb { get; set; }

    #region Movement

    protected Vector2 MoveDirection { get; set; }
    [Header("Movement Settings")] public float drag = 8f;
    public float tiltAngle = 30f;
    public float jerkForce = 2f;
    [Range(0, 0.1f)] public float rotationSpeed = 0.07f;

    #endregion

    #region Camera
    [Header("Camera Settings")]
    
    public Transform activeCamera;
    public float cameraTiltAngle = 10f;
    [Range(0, 0.1f)] public float cameraRotationSpeed = 0.02f;
    public bool invertSway = false;
    
    #endregion

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.drag = drag;
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (MoveDirection != Vector2.zero)
        {
            Rb.AddForce(MoveDirection * jerkForce, ForceMode.Impulse);
        }
        RotationAfterMove();
        CameraRotation();
    }

    protected void RotationAfterMove()
    {
        var newRotation = Quaternion.Euler(MoveDirection.y, 0f, -(tiltAngle * MoveDirection.x));
        Rb.rotation = Quaternion.Slerp(Rb.rotation, newRotation, rotationSpeed);
    }
    
    private void CameraRotation()
    {
        Quaternion currCamRotation = activeCamera.rotation;
        int invert = invertSway ? -1 : 1;

        var newCamRotation = Quaternion.Euler(
            currCamRotation.eulerAngles.x, 
            currCamRotation.eulerAngles.y, 
            cameraTiltAngle * MoveDirection.x * invert
            );
        
        activeCamera.rotation = Quaternion.Slerp(currCamRotation, newCamRotation, cameraRotationSpeed);
    }
}