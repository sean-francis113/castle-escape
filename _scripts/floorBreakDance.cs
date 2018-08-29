using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorBreakDance : MonoBehaviour {

    public float danceSpeedMin;
    public float danceSpeedMax;

    private float danceTimer;

    private void Start()
    {

        setTimer();

    }

    // Update is called once per frame
    void Update()
    {

        danceTimer -= Time.deltaTime;

        if (danceTimer <= 0.0f)
        {

            this.transform.localScale =
                new Vector3(this.transform.localScale.x,
                -this.transform.localScale.y,
                this.transform.localScale.z);

            setTimer();

        }

    }

    void setTimer()
    {

        danceTimer = Random.Range(danceSpeedMin, danceSpeedMax);

    }

}
