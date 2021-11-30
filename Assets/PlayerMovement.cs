using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        Vector3 joy = new Vector3(Input.GetAxis("RightJoyX"), 0, -Input.GetAxis("RightJoyY"));
        if (joy.magnitude < 0.3f) { return; }
        joy.Normalize();

        transform.Translate(joy * speed * Time.deltaTime, Space.World);

        if (joy != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(joy, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}