using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject ball;
    private Rigidbody ballRigidbody;
    public float shootPower = 750f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("East"))
        {
            ball = Instantiate(projectilePrefab, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, shootPower, 0));

            //Debug.DrawRay(this.transform.position, transform.forward);
            //ballRigidbody.velocity = transform.forward * shootPower;
        }
    }
}