using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 10f;

    private GameInput gameInput;

    void Awake()
    {
        gameInput = GameObject.Find("GameInput").GetComponent<GameInput>();
    }

    void Update()
    {
        Vector2 movementInput = gameInput.GetMovementVectorNormalized();
        Vector3 desiredMovement = new Vector3(movementInput.x, 0, movementInput.y);

        transform.position += desiredMovement * Time.deltaTime * movementSpeed;

        // Rotate to face direction
        if (desiredMovement != Vector3.zero) {
            transform.forward = Vector3.Slerp(transform.forward, desiredMovement, Time.deltaTime * rotationSpeed);
        }
    }
}
