using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elemProjectile : MonoBehaviour {

    public float destroyDelay;
    public float arrowSpeed;
    public float maxSpeed;
    public float startDelay;

    public int damage;

    public Vector3 stopPosition;

    private elementalAI aiScript;

    private float destroyTimer;
    private float startTimer;

    private Vector3 direction;

    private void Start()
    {

        aiScript = GameObject.FindGameObjectWithTag("boss").GetComponent<elementalAI>();
        startTimer = startDelay;
        destroyTimer = destroyDelay;
        setDirection();

    }

    void Update()
    {

        if (startTimer > 0.0f)
        {

            startTimer -= Time.deltaTime;

        }
        else
        {

            if (destroyTimer >= 0.0f)
            {

                destroyTimer -= Time.deltaTime;

            }else
            {

                Destroy(this.gameObject);

            }

            this.gameObject.transform.position += direction * arrowSpeed * Time.deltaTime;


        }

    }

    public void setDirection()
    {

        if (aiScript.facingRight)
        {

            this.transform.localScale = new Vector3(this.transform.localScale.x,this.transform.localScale.y, this.transform.localScale.z);
            direction = Vector2.right;

        }
        else
        {
            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            direction = Vector2.left;

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            other.gameObject.SendMessage("applyDamage", damage);
            Destroy(this.gameObject);

        }
        else if (other.tag == "wall")
        {

            //destroyTimer = destroyDelay;
            Destroy(this.gameObject);

        }

    }
}
