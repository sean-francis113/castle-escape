using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPot : MonoBehaviour {

    public int healing;

    private GameObject playerGO;

    private void Start()
    {

        playerGO = GameObject.FindGameObjectWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {

            playerGO.SendMessage("heal", healing);
            Destroy(this.gameObject);

        }

    }

}
