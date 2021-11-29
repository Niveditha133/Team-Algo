using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class MobileUnit : MonoBehaviour
{
    public GameObject Target;
    public GameObject[] SquarePositions;
    public GameObject[] TrianglePositions;
    private NavMeshAgent Agent;
    public GameObject Factory; //factory prefab to instantiate
    private Dictionary<GameObject, GameObject> SquareConfigure = new Dictionary<GameObject, GameObject>();
    private Dictionary<GameObject, GameObject> TriangleConfigure = new Dictionary<GameObject, GameObject>();

    [HideInInspector]
    public bool _reachedTarget = false;

    // Start is called before the first frame update
    private void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        Agent.SetDestination(Target.transform.position);
        foreach (GameObject pos in SquarePositions)
        {
            SquareConfigure.Add(pos, null);
        }
        foreach (GameObject pos in TrianglePositions)
        {
            TriangleConfigure.Add(pos, null);
        }
    }

    public void StartConfigure(GameObject go)
    {
        Debug.Log("StartConfigure");
        if (go.transform.parent.name.ToLower().Contains("square"))
        {
            Debug.Log("square");
            List<GameObject> keys = SquareConfigure.Keys.ToList();
            foreach (GameObject key in keys)
            {
                //guard statement
                if (SquareConfigure[key] != null) { continue; } //go to the next loop iteration
                SquareConfigure[key] = go;
                go.GetComponentInParent<NavMeshAgent>().enabled = false;
                go.GetComponentInParent<MobileUnit>().enabled = false;
                go.GetComponent<CollisionDetection>().enabled = false;
                break;
            }
        }
        if (go.transform.parent.name.ToLower().Contains("triangle"))
        {
            Debug.Log("triangle");
            List<GameObject> keys = TriangleConfigure.Keys.ToList();
            foreach (GameObject key in keys)
            {
                //guard statement
                if (TriangleConfigure[key] != null) { continue; } //go to the next loop iteration
                TriangleConfigure[key] = go;
                go.GetComponentInParent<NavMeshAgent>().enabled = false;
                go.GetComponentInParent<MobileUnit>().enabled = false;
                go.GetComponent<CollisionDetection>().enabled = false;
                break;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_reachedTarget)
        {
            bool triConfig = ConfigureShapes(TriangleConfigure);
            bool sqConfig = ConfigureShapes(SquareConfigure);
            if (triConfig && sqConfig) //if each agent is in position
            {
                List<GameObject> keys = SquareConfigure.Keys.ToList(); //get dictionary keys as list
                foreach (GameObject key in keys)
                {
                    GameObject go = SquareConfigure[key]; //get agent associated with this key
                    //Destroy(go); //delete all agents in configure positions
                }

                keys = TriangleConfigure.Keys.ToList(); //get dictionary keys as list
                foreach (GameObject key in keys)
                {
                    GameObject go = TriangleConfigure[key]; //get agent associated with this key
                    //Destroy(go); //delete all agents in configure positions
                }

                /*GameObject factory = Instantiate(Factory, transform.position, transform.rotation); //create factory
                float moveY = factory.transform.localScale.y / 2.0f; //get half factory height
                factory.transform.position += new Vector3(0, moveY, 0); //move factory up
                Destroy(gameObject); //destroy the agent this script is attached to*/
            }

            return; //exit so we don't do any more code in Update()
        }

        Debug.DrawLine(this.transform.position, Target.transform.position, Color.black);
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);
        HasReachedTarget();
    }

    public bool ConfigureShapes(Dictionary<GameObject, GameObject> Configure)
    {
        bool allConfig = true;
        foreach (KeyValuePair<GameObject, GameObject> kvp in Configure)
        {
            //guard statement
            if (kvp.Value == null) { allConfig = false; continue; }
            if (kvp.Key.transform.position == kvp.Value.transform.position) { continue; }

            //move object into position
            GameObject cAgent = kvp.Value;
            Vector3 pos = kvp.Key.transform.position;
            Quaternion rot = kvp.Key.transform.rotation;
            cAgent.transform.position = Vector3.Lerp(cAgent.transform.position, pos, Time.deltaTime);
            cAgent.transform.rotation = Quaternion.Lerp(cAgent.transform.rotation, rot, Time.deltaTime);
            if (Vector3.Distance(cAgent.transform.position, pos) < 0.05f)
            {
                cAgent.transform.position = pos;
                cAgent.transform.rotation = rot;
            }
            allConfig = false;
        }
        return allConfig;
    }

    private void HasReachedTarget()
    {
        //test if agent has reached target
        if (!Agent.pathPending) //if agent is looking for target it hasn't reached target
        {
            if (Agent.remainingDistance <= Agent.stoppingDistance) //agent is as close as it can get
            {
                if (!Agent.hasPath || Agent.velocity.sqrMagnitude == 0f) //if agent isn't moving
                {
                    Debug.Log("Target Reached!!!");
                    _reachedTarget = true;
                    Agent.enabled = false;
                }
            }
        }
    }
}