using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public float Score = 25;
    public Material Original;
    public Material Score20;
    public Material Score15;
    public Material Score10;
    public Material Score5;
    public Material Score0;
    //private Renderer _rend;

    /*private void OnCollidorEnter(Collision col)
    {
        if (col.gameObject.name == "Projectile") ;
        {
            Destroy(col.gameObject);
            Debug.Log("Projectile Destroyed");
            Score -= 5;
            Debug.Log(Score);
        }
        if (Score == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Target Destroyed");
        }
    }*/

    // Update is called once per frame
    private void Update()
    {
        MeshRenderer mr = this.GetComponent<MeshRenderer>();

        if (Score == 25)
        {
            mr.material = Original;
            Debug.Log("Score = 25");
        }
        else if (Score == 20)
        {
            mr.material = Score20;
            Debug.Log("Score = 20");
        }
        else if (Score == 15)
        {
            mr.material = Score15;
            Debug.Log("Score = 15");
        }
        else if (Score == 10)
        {
            mr.material = Score10;
            Debug.Log("Score = 10");
        }
        else if (Score == 5)
        {
            mr.material = Score5;
            Debug.Log("Score = 5");
        }
        else if (Score == 0)
        {
            mr.material = Score0;
            Debug.Log("Score = 0");

            this.gameObject.GetComponent<Tessellate>().enabled = true;
            this.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            //this.gameObject.transform.position = new Vector3(0, -2.25f, 0); - Ask Matt

            //Destroy(this.gameObject); - add later if you want to destroy
        }
        //_rend = this.gameObject.GetComponent<Renderer>();

        /*if (Score == 25)
        {
            _rend.material.SetColor("_Color", Color.red);
        }
        else if (Score == 20)
        {
            _rend.material.SetColor("_Color", Color.cyan);
        }
        else if (Score == 15)
        {
            _rend.material.SetColor("_Color", Color.magenta);
        }
        else if (Score == 10)
        {
            _rend.material.SetColor("_Color", Color.green);
        }
        else if (Score == 5)
        {
            _rend.material.SetColor("_Color", Color.yellow);
        }
        else if (Score == 0)
        {
            _rend.material.SetColor("_Color", Color.white);
        }*/
    }
}