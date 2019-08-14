using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementSystem : MonoBehaviour
{
    [SerializeField,Tooltip("The object to Move, if used in VR alongside HoverMovement assign camera's parent")]
    private Transform objectToMove=null;
    [SerializeField,Tooltip("The front facing transform , typically this would be the camera")]
    private Transform forwardTransform = null;

    [SerializeField]
    private MovementController movementController=null;
    public float speed = 5f;

    private void LateUpdate()
    {
        Vector3 mv = movementController.movementVector;
        Vector3 movement = Vector3.ProjectOnPlane(forwardTransform.forward, Vector3.up) * mv.z;
        movement += Vector3.ProjectOnPlane(forwardTransform.right, Vector3.up) * mv.x;
        movement.y = 0f;
        objectToMove.position += movement * speed * Time.deltaTime;
    }
}
