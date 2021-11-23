using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CamFollowPlayer : MonoBehaviour
{

    public Transform CameraTarget;
    public float Speed = 10.0f;
    public Vector3 dist;
    public Transform lookTarget;

    public void Update()
    {
        Vector3 dPos = CameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, Speed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }

}

