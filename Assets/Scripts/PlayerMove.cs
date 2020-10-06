using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float h;
    float v;
    public bool isHolding = false;
    public bool stopCr = false;
    public bool canCtl = true;
    bool playOnce = true;
    public GameObject holding;
    public GameObject temp;
    public GameObject player;
    public AudioSource win;
    RaycastHit ray;

    private void Update()
    {
        if(canCtl)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        if(!canCtl && playOnce)
        {
            stopCr = true;
            this.transform.position = new Vector3(-55f, 8.5f, 30f);
            win.Play();
            playOnce = false;
        }
        GrapRay();
        Debug.DrawRay(this.transform.position, Vector3.right * 10, Color.red);
    }

    void FixedUpdate()
    {
        if(playOnce)
            transform.Translate(new Vector3(v, 0, -h) * 30 * Time.deltaTime);
        if (isHolding)
        {
            if(Input.GetKeyUp(KeyCode.H) && canCtl)
            {
                stopCr = true;
                holding.transform.tag = "Untagged";
                holding = temp;
                isHolding = false;
            }
            else
            {
                holding.transform.tag = "isHolding";
                holding.transform.position = new Vector3(this.transform.position.x + 12, holding.transform.position.y, this.transform.position.z);
            }
        }
    }
    void GrapRay()
    {
        if(Physics.Raycast(this.transform.position, Vector3.right, out ray, 15))
        {
            if(!isHolding && ray.transform.name != "Player")
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    isHolding = true;
                    holding = ray.transform.gameObject;
                    StartCoroutine(Hold());
                }
                else
                    isHolding = false;
            }
        }
    }
    
    IEnumerator Hold()
    {
        while (true)
        {
            if (stopCr)
            {
                holding.transform.tag = "Untagged";
                holding = temp;
                isHolding = false;
                stopCr = false;
                break;
            }
            yield return null;
        }
    }
}
