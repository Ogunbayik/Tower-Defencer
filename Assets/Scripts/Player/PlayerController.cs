using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    [Header("Movement Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform body;
    [Header("Border Settings")]
    [SerializeField] private float maximumX;
    [SerializeField] private float minimumX;
    [SerializeField] private float maximumZ;
    [SerializeField] private float minimumZ;

    private Vector3 movementDirection;

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var horizontalInput = Input.GetAxis(HORIZONTAL_INPUT);
        var verticalInput = Input.GetAxis(VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();

        SetMovementBorder();
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        HandleRotation();
    }

    private void SetMovementBorder()
    {
        var positionY = 0f;
        if (transform.position.x > maximumX)
        {
            if (transform.position.z > maximumZ)
                transform.position = new Vector3(maximumX, positionY, maximumZ);
            else if (transform.position.z < minimumZ)
                transform.position = new Vector3(maximumX, positionY, minimumZ);
            else
                transform.position = new Vector3(maximumX, positionY, transform.position.z);
        }
        else if (transform.position.x < minimumX)
        {
            if (transform.position.z > maximumZ)
                transform.position = new Vector3(minimumX, positionY, maximumZ);
            else if (transform.position.z < minimumZ)
                transform.position = new Vector3(minimumX, positionY, minimumZ);
            else
                transform.position = new Vector3(minimumX, positionY, transform.position.z);
        }
        else if (transform.position.z > maximumZ)
        {
            transform.position = new Vector3(transform.position.x, positionY, maximumZ);
        }
        else if (transform.position.z < minimumZ)
        {
            transform.position = new Vector3(transform.position.x, positionY, minimumZ);
        }
    }

    private void HandleRotation()
    {
        if (movementDirection != Vector3.zero)
        {
            var rotationY = Quaternion.LookRotation(movementDirection, Vector3.up);
            body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, rotationY, rotationSpeed * Time.deltaTime);
        }
    }


}
