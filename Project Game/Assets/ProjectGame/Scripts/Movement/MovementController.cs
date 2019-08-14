using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Vector3 movementVector
    {
        get
        {
            if (movementInputs.Count > 0)
            {
                Vector3 movement=Vector3.zero;
                foreach (IMovementInput movementInput in movementInputs)
                {
                    movement += movementInput.movementVector;
                }
                return movement / movementInputs.Count;
            }
            return Vector3.zero;
        }
    }

    public List<IMovementInput> movementInputs = new List<IMovementInput>();
}
