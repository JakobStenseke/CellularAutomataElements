using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CellScript : MonoBehaviour {

	private float radius = 0.1f;
	public Collider2D[] colliders;
	public int SelectedNeighborNumber;
	public Collider2D SelectedNeighbor;
	private float EvolveTime;

	public Button CellButton;
	public Button StartButton;
	public string CellColor;
	public float Intensity;
	public int epoch;
	public Text epochText;
	public bool Evolving;
	public GameObject PauseImage;
	public GameObject PlayImage;
	public GameObject Manager;


	// Use this for initialization
	void Start () {

		Evolving = false;
		Intensity = 0.6f;
		CellColor = "White";
		colliders = Physics2D.OverlapCircleAll (transform.position, radius); // creates an array of all the overlapps
		EvolveTime = 0.09f;

		Button btn = CellButton.GetComponent<Button> ();
		btn.onClick.AddListener (ButtonFunction);

		Button btn2 = StartButton.GetComponent<Button> ();
		btn2.onClick.AddListener (StartFunction);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (CellColor == "White") {
			SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
			renderer.color = new Color (1f, 1f, 1f, 1f);
		}
			
		if (CellColor == "Red") {
			SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
			renderer.color = new Color (1f, Intensity, 0.3f, 1f);
		}

		if (CellColor == "Blue") {
			SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
			renderer.color = new Color (0.45f, Intensity, 0.95f, 1f);
		}

		if (CellColor == "Green") {
			SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
			renderer.color = new Color (0f, Intensity, 0f, 1f);
		}
	}

	void Evolve(){

		epoch += 1;
		epochText.text = "EPOCH: " + epoch.ToString ();

		SelectedNeighborNumber = Random.Range (0, colliders.Length);
		SelectedNeighbor = colliders [SelectedNeighborNumber];

		if (SelectedNeighbor.transform.position != transform.position) {


			CellScript otherCellColor = SelectedNeighbor.GetComponent<CellScript> (); //access color of other script
			ManagerScript managerScript = Manager.GetComponent<ManagerScript> ();

			if (CellColor == "Blue" && otherCellColor.CellColor == "Red") {

				otherCellColor.CellColor = "Blue";
				managerScript.Water += 1;
				managerScript.Fire -= 1;
				otherCellColor.Intensity = 0.7f;
			}
			if (CellColor == "Blue" && otherCellColor.CellColor == "White") {
				otherCellColor.CellColor = "Blue";
				managerScript.Water += 1;
				otherCellColor.Intensity = 0.7f;
			}
				
			if (CellColor == "Blue" && otherCellColor.CellColor == "Blue") {

				if (otherCellColor.Intensity > 0.3f) {
					otherCellColor.Intensity -= 0.05f;
				}
			}


				
			if (CellColor == "Green" && otherCellColor.CellColor == "Blue") {

				otherCellColor.CellColor = "Green";
				managerScript.Grass += 1;
				managerScript.Water -= 1;
				otherCellColor.Intensity = 0.7f;
			}

			if (CellColor == "Green" && otherCellColor.CellColor == "White") {
				otherCellColor.CellColor = "Green";
				managerScript.Grass += 1;
				otherCellColor.Intensity = 0.7f;

			}
			if (CellColor == "Green" && otherCellColor.CellColor == "Green") {

				if (otherCellColor.Intensity > 0.3f) {
					otherCellColor.Intensity -= 0.05f;
				}
			}



			if (CellColor == "Red" && otherCellColor.CellColor == "Green") {

				otherCellColor.CellColor = "Red";
				managerScript.Fire += 1;
				managerScript.Grass -= 1;
				otherCellColor.Intensity = 0.7f;
			}
			if (CellColor == "Red" && otherCellColor.CellColor == "White"){

				otherCellColor.CellColor = "Red";
				managerScript.Fire += 1;
				otherCellColor.Intensity = 0.7f;

			}


			if (CellColor == "Red" && otherCellColor.CellColor == "Red") {

				if (otherCellColor.Intensity > 0.3f) {
					otherCellColor.Intensity -= 0.05f;
				}
			}
		}
	}

	void ButtonFunction(){

		ManagerScript managerScript = Manager.GetComponent<ManagerScript> ();

		switch (CellColor)
		{
		case "White":
			CellColor = "Blue";
			managerScript.Water += 1;
			break;
		case "Blue":
			CellColor = "Green";
			managerScript.Water -= 1;
			managerScript.Grass += 1;
			break;
		case "Green":
			CellColor = "Red";
			managerScript.Grass -= 1;
			managerScript.Fire += 1;
			break;
		case "Red":
			CellColor = "Blue";
			managerScript.Fire -= 1;
			managerScript.Water += 1;
			break;
		}

	}

	void StartFunction(){

		if (Evolving == false) {
			InvokeRepeating ("Evolve", 0, EvolveTime);
			Evolving = true;
			PauseImage.SetActive (true);
			PlayImage.SetActive (false);
		} else {

			CancelInvoke ("Evolve");
			Evolving = false;
			PauseImage.SetActive (false);
			PlayImage.SetActive (true);
		}

	}
}
