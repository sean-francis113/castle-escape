using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordDamage : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "enemy" || other.tag == "boss")
        {

            other.SendMessage("applyDamage", 1);

        }

    }

    void debugMessage()
    {

        Debug.Log("Attack Animation Started");
        
    }

}
