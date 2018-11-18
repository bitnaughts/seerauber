using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public GameObject book;

	//Mouse States
	Vector2 mouseLocation = new Vector2 (0, 0);
	Vector2 newMouseLocation = new Vector2 (0, 0);

	// Use this for initialization
	void Start () {
		BookObject.opened = BookObject.CLOSED;
	}

	void Update () {
		switch (BookObject.opened) {
			case 0:
				book.SetActive (false);
				break;
			case 1:
				book.SetActive (true);
				book.transform.GetChild(0).gameObject.SetActive(true);
				book.transform.GetChild(1).gameObject.SetActive(false);
				break;
			case 2:
				book.SetActive (true);
				book.transform.GetChild(0).gameObject.SetActive(false);
				book.transform.GetChild(1).gameObject.SetActive(true);
				break;

		}
	}

	public static void clickOnPirate (PirateObject pirate) {
		//book.SetActive (true);
		BookObject.opened = BookObject.OPENED;
		BookObject.currentPirate = pirate;
	}
	public void clickOnTasks () {
		BookObject.opened = BookObject.FULLY_OPENED;
	}
	public void closeTasks () {
		BookObject.opened = BookObject.OPENED;
	}
	public void closeBook () {
		BookObject.opened = BookObject.CLOSED;
	}
}