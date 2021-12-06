using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private MobileUnit _mobileUnit;
    //private MeshCollider _mesh;
    //private RigidbodyConstraints _rigidbodyCons;

    // Start is called before the first frame update
    private void Start()
    {
        _mobileUnit = transform.parent.GetComponent<MobileUnit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_mobileUnit._reachedTarget) { return; }
        GameObject go = other.gameObject;
        if (go.tag != "Agent") { return; }
        _mobileUnit.StartConfigure(go);
        //other.enabled = !other.enabled;

        //if (_mobileUnit._reachedTarget) { other.gameObject.GetComponent<NavMeshObstacle>().enabled = true; }

        /*if (_mobileUnit._reachedTarget) { other.gameObject.GetComponent<MeshCollider>().isTrigger = false; }
        if (other.isTrigger == false)
        {
            _rigidbodyCons = RigidbodyConstraints.FreezePositionX |
                  RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        }*/
    }
}