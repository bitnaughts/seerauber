using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject piratePrefab;
	public GameObject[] piratePool = new GameObject[10];

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			piratePool[i] = Instantiate (piratePrefab, this.transform) as GameObject;
			piratePool[i].SetActive (true);
		}

		PirateObject[] pirates = new PirateObject[10];
		for (int i = 0; i < 10; i++) {
			pirates[i] = new PirateObject ();
			piratePool[i].GetComponent<PirateController>().reference = pirates[i];
		}
		Interpreter.pirates = pirates;
	}

	// Update is called once per frame
	void Update () {
		Interpreter.run ();
	}
}