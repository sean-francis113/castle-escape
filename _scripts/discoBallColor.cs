using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discoBallColor : MonoBehaviour {

    public float colorTimerMin;
    public float colorTimerMax;

    public GameObject overlay;

    private float colorTimer;
    private Vector4 color;
    private Vector4 overlayColor;
    private SpriteRenderer overlaySprite;

	// Use this for initialization
	void Start () {

        overlaySprite = overlay.GetComponent<SpriteRenderer>();
        setTimer();
		
	}
	
	// Update is called once per frame
	void Update () {

        colorTimer -= Time.deltaTime;

        if(colorTimer <= 0.0f)
        {

            this.GetComponent<SpriteRenderer>().color = color;
            overlaySprite.color = overlayColor;
            setTimer();

        }
		
	}

    void setTimer()
    {

        colorTimer = Random.Range(colorTimerMin, colorTimerMax);
        color = new Vector4(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1.0f);
        overlayColor = new Vector4(color.x, color.y, color.z, 0.25f);

    }
}
