using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMctl : MonoBehaviour
{
    public AudioSource bgm;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player.activeSelf)
        {
            bgm.volume = 0.5f;
        }
        else
        {
            bgm.volume = 1;
        }
    }
}
