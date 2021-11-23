using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Projectile") ;
        {
            col.gameObject.GetComponent<OnCollision>().Score -= 5;
            Destroy(this.gameObject);
            //Score -= 5;
            //Debug.Log(Score);
        }
        /*if (Score == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Target Destroyed");
        }*/
    }
}