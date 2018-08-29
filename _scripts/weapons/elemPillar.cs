using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elemPillar : MonoBehaviour {

    public float riseSpeed;
    public float startDelay;
    public float destroyDelay;

    public int damage;

    private bool rising;

    private float startTimer;
    private float destroyTimer;

    private Vector3 stopPosition;

	// Use this for initialization
	void Start () {

        startTimer = startDelay;
        stopPosition = new Vector3(this.transform.position.x, 1.5f, this.transform.position.z);
        destroyTimer = 0.0f;
        rising = false;

	}
	
	// Update is called once per frame
	void Update () {

        if(startTimer > 0.0f)
        {

            startTimer -= Time.deltaTime;

            if(startTimer <= 0.0f)
            {

                if (!rising)
                {

                    rising = true;
                    destroyTimer = destroyDelay;

                }

            }

        }

        if(destroyTimer > 0.0f)
        {

            destroyTimer -= Time.deltaTime;

            if(destroyTimer < 0.0f)
            {

                Destroy(this.gameObject);

            }

        }

        if (rising)
        {
            if (this.gameObject.transform.position.y != stopPosition.y)
            {

                this.gameObject.transform.position += Vector3.up * riseSpeed * Time.deltaTime;

            }

        }
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {

            other.SendMessage("applyDamage", damage);

        }

    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            other.SendMessage("applyDamage", damage);

        }

    }

}
