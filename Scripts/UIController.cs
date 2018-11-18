using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	BookObject pirateBook = new BookObject();
    public GameObject book;

	//Mouse States
	Vector2 mouseLocation = new Vector2(0,0);
	Vector2 newMouseLocation = new Vector2(0,0);


	// Use this for initialization
	void Start () {
		
	}
	
    public void clickOnPirate(PirateObject pirate)
    {
        book.SetActive(true);

		
    }


		
}
