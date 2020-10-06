using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{

    Transform tr;
    Rigidbody rb;
    public GameObject player;
    public GameObject temp;
    public GameObject smoke1;
    public GameObject smoke2;
    public AudioSource blockDrop;
    float dist = 0;
    PlayerMove pm;
    RaycastHit hit;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        pm = player.GetComponent<PlayerMove>();
    }

    void Update()
    {
        //Debug.DrawRay(this.tr.position, -Vector3.forward * 30, Color.red);
        if(smoke1.activeSelf != true)
        {
            if (this.tr.tag == "isHolding")
            {
                smoke1.SetActive(true);
                smoke2.SetActive(true);
            }
        }
        else
        {
            if(this.tr.tag != "isHolding")
            {
                smoke1.SetActive(false);
                smoke2.SetActive(false);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name != "LowpolyTerrain" && collision.transform.name != "Player" && collision.transform.name != "SideWall")
        {
            if (this.tr.name == "Third" || collision.transform.name == "Third")
            {
                dist = 16;
            }
            else
                dist = 20;

            if (this.tr.tag == "isHolding")
            {
                if (!Physics.Raycast(collision.transform.position, -Vector3.forward, out hit, 30))
                {
                    pm.stopCr = true;
                    this.transform.position = new Vector3(collision.transform.position.x,
                        this.transform.position.y, collision.transform.position.z - dist);
                    this.transform.tag = "Untagged";
                    pm.holding = temp;
                    pm.stopCr = true;
                    blockDrop.Play();
                }
                else if (Physics.Raycast(collision.transform.position, -Vector3.forward, out hit, 30) && hit.transform.tag == "isHolding")
                {
                    pm.stopCr = true;
                    this.transform.position = new Vector3(collision.transform.position.x,
                        this.transform.position.y, collision.transform.position.z - dist);
                    this.transform.tag = "Untagged";
                    pm.holding = temp;
                    pm.stopCr = true;
                    blockDrop.Play();
                }
                else if (!Physics.Raycast(collision.transform.position, Vector3.forward, out hit, 30))
                {
                    pm.stopCr = true;
                    this.transform.position = new Vector3(collision.transform.position.x,
                    this.transform.position.y, collision.transform.position.z + dist);
                    this.transform.tag = "Untagged";
                    pm.holding = temp;
                    pm.stopCr = true;
                    blockDrop.Play();
                }
                else if (Physics.Raycast(collision.transform.position, Vector3.forward, out hit, 30) && hit.transform.tag == "isHolding")
                {
                    pm.stopCr = true;
                    this.transform.position = new Vector3(collision.transform.position.x,
                    this.transform.position.y, collision.transform.position.z + dist);
                    this.transform.tag = "Untagged";
                    pm.holding = temp;
                    pm.stopCr = true;
                    blockDrop.Play();
                }
            }
        }   
    }
}