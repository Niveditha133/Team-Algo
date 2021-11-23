using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*public class AgentScoreChange : MonoBehaviour
{
    public GameObject Height;

    public float Region;
    public Material Original;
    public Material Score20;
    public Material Score15;
    public Material Score10;
    public Material Score5;
    public Material Score0;
    public float Score = 1f;
    //private List<Guest> In = new List<Guest>();

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    //private void Update()
    /*{
        /*MeshRenderer mr = this.GetComponent<MeshRenderer>();
        List<Guest> guests = GuestManager.Instance.GuestList();
        foreach (Guest guest in guests)
        {
            if (guest.Status == Guest.Action.BATHING)
            {
                Vector3 Floor = Height.transform.position;
                if (!In.Contains(guest) && Mathf.Abs(guest.transform.position.y - Floor.y) < 1f && Vector3.Distance(Floor, guest.transform.position) < Region)
                {
                    In.Add(guest);
                }
            }

            Score = In.Count;

            if (Score == 25)
            {
                mr.material = Original;
            }
            else if (Score == 20)
            {
                mr.material = Score20;
            }
            else if (Score == 15)
            {
                mr.material = Score15;
            }
            else if (Score == 10)
            {
                mr.material = Score10;
            }
            else if (Score == 5)
            {
                mr.material = Score5;
            }
            else if (Score == 0)
            {
                mr.material = Score0;
            }
        }
    }
    }*/