using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    bool checkFs = false;
    bool checkSc = false;
    RaycastHit hit;
    public GameObject player;
    PlayerMove pm;

    void Start()
    {
        pm = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(this.transform.position, Vector3.forward * 30, Color.red);
        if (Physics.Raycast(this.transform.position, Vector3.forward, out hit, 20))
        {
            if(hit.transform.name == "First")
            {
                checkFs = true;
            }
            else
            {
                checkFs = false;
            }
        }
        else
        {
            checkFs = false;
        }
        if(Physics.Raycast(this.transform.position, -Vector3.forward, out hit, 20))
        {
            if (hit.transform.name == "Third" && hit.transform.tag != "isHolding")  
            {
                checkSc = true;
            }
            else
            {
                checkSc = false;
            }
        }
        else
        {
            checkSc = false;
        }
        if (checkFs && checkSc)
        {
            Debug.Log("Success");
            pm.canCtl = false;
        }
    }
}
