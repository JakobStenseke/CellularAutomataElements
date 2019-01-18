using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour {

	public int Grass;
	public int Water;
	public int Fire;

	public Image WaterFill;
	public Image LifeFill;
	public Image FireFill;
	public Text ElementsText;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		WaterFill.fillAmount = Water / 192f;
		LifeFill.fillAmount = Grass / 192f;
		FireFill.fillAmount = Fire / 192f;
		ElementsText.text = "WATER: " + Water + "\n" + "LIFE: " + Grass + "\n" + "FIRE: " + Fire.ToString ();
		
	}
}
