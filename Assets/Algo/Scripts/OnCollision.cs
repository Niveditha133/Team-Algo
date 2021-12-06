using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public float Score = 35;
    public Material Original;
    public Material Score25;
    public Material Score20;
    public Material Score15;
    public Material Score10;
    public Material Score5;
    public Material Score0;

    //private Renderer _rend;
    //private Vector3 _offset;

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

    /*private void Start()
    {
        _offset = new Vector3(0, -2f, 0);
    }*/

    // Update is called once per frame
    private void Update()
    {
        MeshRenderer mr = this.GetComponent<MeshRenderer>();

        if (Score == 30)
        {
            mr.material = Original;
            Debug.Log("Score = 30");
        }
        else if (Score == 25)
        {
            mr.material = Score25;
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

            this.gameObject.GetComponent<Tessellate>().enabled = true;
            this.gameObject.transform.localScale = new Vector3(0.30f, 0.30f, 0.30f);
            //this.gameObject.transform.position = _offset; //- Ask Matt
        }
        else if (Score == 0)
        {
            mr.material = Score0;
            Debug.Log("Score = 0");

            Destroy(this.gameObject); //- add later if you want to destroy

            ScoreManager.instance.AddScore();
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