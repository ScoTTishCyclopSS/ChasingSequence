using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFirstPerson : ShipPlayerBase
{
    #region Steering
    [Header("1st-P Steering Settings")]
    
    public Transform steering;
    public float steeringTiltAngle = 50f;
    [Range(0, 0.3f)] public float steeringRotationSpeed = 0.05f;

    #endregion

    protected override void Move()
    {
        base.Move();
        SteeringRotation();
    }

    private void SteeringRotation()
    {
        Quaternion currRotation = steering.rotation;
        var newRotation = Quaternion.Euler(
            currRotation.eulerAngles.x, 
            currRotation.eulerAngles.y, 
            steeringTiltAngle * MoveDirection.x
        );
        steering.rotation = Quaternion.Slerp(currRotation, newRotation, steeringRotationSpeed);
    }
}
