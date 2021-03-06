using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainCamera : MonoBehaviour
{
    public float Speed = 2.0f;

    public NavMeshAgent Agent;
    //public Transform CameraTarget;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //get input
        Vector3 joy = new Vector3(Input.GetAxis("LeftJoyX"), 0, Input.GetAxis("LeftJoyY"));

        //camera vectors
        Vector3 forward = Camera.main.transform.forward;
        //Debug.DrawRay(transform.position, forward * 10, Color.grey);
        Vector3 project = Vector3.ProjectOnPlane(forward, Vector3.up);
        //Debug.DrawRay(transform.position, project * 10, Color.blue);
        Vector3 right = Camera.main.transform.right;
        //Debug.DrawRay(transform.position, right * 10, Color.black);

        //Vector3 up = Camera.main.transform.up;

        //only continue if joystick pressed more than 0.3f
        if (joy.magnitude < 0.3f) { return; }
        Debug.Log("Camera Move");

        //move camera
        Vector3 move = right * joy.x + project * -joy.z;
        transform.Translate(move.normalized * Time.deltaTime * Speed);
        //Debug.DrawRay(transform.position, move, Color.red);

        //transform.LookAt(CameraTarget.position);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Agent")
        {
            Debug.Log("Stop");
            Agent.isStopped = true;
        }
        else
        {
            Agent.isStopped = false;
        }
    }
}