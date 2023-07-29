using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThirdPerson : ShipPlayerBase
{
    [Header("3rd-P Camera Settings")]
    public float cameraOffsetOnMove = 0.1f;
    
    protected override void Move()
    {
        base.Move();
        CameraOffset();
    }

    private void CameraOffset()
    {
        Vector3 cameraPos = activeCamera.position;
        float offsetX = transform.position.x * cameraOffsetOnMove;
        activeCamera.position = new Vector3(offsetX, cameraPos.y, cameraPos.z);
    }
}
