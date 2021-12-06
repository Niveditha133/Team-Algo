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
        /*if (Input.GetButtonDown("East"))
        {
            shootBall();
        }
        */
        if (Input.GetButtonDown("East"))
        {
            Vector3 direction = Camera.main.transform.forward;
            direction.y += 50;

            ball = Instantiate(projectilePrefab, transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * shootPower);

            Debug.DrawRay(this.transform.position, Camera.main.transform.forward * 4, Color.red);
            //Debug.Break();
            //ballRigidbody.velocity = transform.forward * shootPower;
        }
    }

    /*private void shootBall()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        ballRigidbody.velocity = transform.forward * shootPower;
    }*/
}