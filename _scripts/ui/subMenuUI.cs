using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class subMenuUI : MonoBehaviour {

	public Text currentSlotText;
	
	// Update is called once per frame
	void Update () {
		
        currentSlotText.text = "Current Save Slot: #" + savePrefs.prefSlot;
        
	}
}
