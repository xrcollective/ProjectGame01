using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMovement : MonoBehaviour,IMovementInput
{
    

    [Tooltip("The maximum distance the head/joystick movement should be clamped to, setting this value lower will make the movement more sensitive")]
    public float axisClampDistance = 1f;
    [Tooltip("The object which acts as a joystick axis in VR typically the head for hoverboard like movement")]
    public Transform head;

    [SerializeField]
    private MovementController movementController = null;

    public Vector3 movementVector
    {
        get;
        private set;
    }

    private Vector3 currPos;
    public void Move()
    {
        Vector3 delta = head.localPosition - currPos;
        //delta.y = 0;
        delta = Quaternion.Inverse(head.localRotation) * delta;
        delta.y = 0;
        delta.x = Mathf.Clamp(delta.x / axisClampDistance, -1, 1);
        delta.z = Mathf.Clamp(delta.z / axisClampDistance, -1, 1);

        movementVector = delta;
    }
    public void SetPos()
    {
        currPos = head.localPosition;
        if (!movementController.movementInputs.Contains(this))
        {
            movementController.movementInputs.Add(this);
        }

    }
    public void ResetPos()
    {
        if (movementController.movementInputs.Contains(this))
        {
            movementController.movementInputs.Remove(this);
        }

    }
}
