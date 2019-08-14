using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMovement : MonoBehaviour
{
    //The maximum distance the head/joystick movement should be clamped to, setting this value lower will make the movement more sensitive
    public float axisClampDistance = 1f;
    //The object which acts as a joystick axis in VR typically the head for hoverboard like movement
    public Transform head;

    private Vector3 currPos;

    public Vector3 movementVector;
    private void Move()
    {
        movementVector = head.localPosition - currPos;
        movementVector.x = Mathf.Clamp(movementVector.x / axisClampDistance, -1, 1);
        movementVector.z = Mathf.Clamp(movementVector.z / axisClampDistance, -1, 1);
        movementVector.y = 0;
    }
    public void SetPos()
    {
        currPos = head.localPosition;
    }
    public void ResetPos()
    {
        movementVector = Vector3.zero;
    }

    private void OnDisable()
    {
        ResetPos();
    }
}
