using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class OnCollisionCandy : MonoBehaviour
{
    private void OnCollidorEnter(Collision can)
    {
        if (can.gameObject.name == "Projectile")
        {
            Destroy(can.gameObject);
            Debug.Log("Candy Destroyed");
        }
    }
}