using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public float score = 25;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Projectile") ;
        {
            Destroy(col.gameObject);
            Debug.Log("Projectile Destroyed");
            score -= 5;
            Debug.Log(score);
        }
        if (score == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Target Destroyed");
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}