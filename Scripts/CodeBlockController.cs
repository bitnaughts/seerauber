using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeBlockController : MonoBehaviour {

	bool isHovering;

	public CodeBlock reference;
	//Mouse States
	Vector2 mouseLocation = new Vector2 (0, 0);
	Vector2 newMouseLocation = new Vector2 (0, 0);
	int height;

	public GameObject Snapper;

	// Use this for initialization
	void Start () {
		//reference = new CodeBlock ();
		print (height);
	}

	// Update is called once per frame
	void Update () {
		print ("ref:" + reference);
		if (true) { //reference != null) {
			height = 0;
			if (reference.nestedBlocks != null) {
				height = recursivelyGetHeight (reference);
				/* 

								for (int i = 0; i < reference.nestedBlocks.Length; i++) {
									if (reference.nestedBlocks[i].nestedBlocks != null) {
										for (int j = 0; j < reference.nestedBlocks[i].nestedBlocks.Length; j++) {
											height++;
										}
									}
									height++;
								}
				*/
			}

			//height = (reference.nestedBlocks == null) ? 0 : // recursivelyGetHeight (reference); //l.nestedBlocks.Length;
			transform.parent.GetChild (1).GetChild (0).GetChild (13).gameObject.GetComponent<Text> ().text = reference.parameter;

			//random amount of subchildren
			this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (200, 20);
			transform.parent.GetChild (1).GetComponent<RectTransform> ().sizeDelta = new Vector2 (200, height * 25 + 20);
			//DRAG START
			if (Input.GetMouseButtonDown (0)) {
				mouseLocation = Input.mousePosition;
				isHovering = false;

				float xMin = this.GetComponent<RectTransform> ().position.x;
				float xMax = this.GetComponent<RectTransform> ().position.x + 200f; //this.GetComponent<RectTransform> ().sizeDelta.x; // graphs[graph].positionX + graphs[graph].width;
				float yMin = this.GetComponent<RectTransform> ().position.y; //graphs[graph].positionY;
				float yMax = this.GetComponent<RectTransform> ().position.y + 30f; //this.GetComponent<RectTransform> ().sizeDelta.y;

				RectTransform blockTransform = this.GetComponent<RectTransform> ();

				if (clickOn (-blockTransform.sizeDelta.x / 2, blockTransform.sizeDelta.x / 2, -blockTransform.sizeDelta.y / 2, blockTransform.sizeDelta.y / 2, mouseLocation, this.GetComponent<RectTransform> ().position)) {

					isHovering = true;

				}

			}
			//DRAG MOVE
			if (Input.GetMouseButton (0)) {

				newMouseLocation = Input.mousePosition;

				if (isHovering) {
					print ("yes, dragging...");
					Vector2 newPosition = this.GetComponent<RectTransform> ().position;
					newPosition.x += -(mouseLocation.x - newMouseLocation.x);
					newPosition.y += -(mouseLocation.y - newMouseLocation.y);
					this.GetComponent<RectTransform> ().position = newPosition;
				}
				mouseLocation = newMouseLocation;
			}

			Vector2 snapper = this.transform.localPosition;
			int step = 30;
			snapper = new Vector2 ((((int) snapper.x + step / 2) / step) * step, (((int) snapper.y + step / 2) / step) * step);
			transform.parent.GetChild (1).localPosition = snapper;
			//this.transform.localPosition 
		} else height = 0;
	}
	public bool clickOn (float xMin, float xMax, float yMin, float yMax, Vector2 mousePosition, Vector2 otherPosition) {
		if (mousePosition.x + xMin < otherPosition.x && mousePosition.x + xMax > otherPosition.x)
			if (mousePosition.y + yMin < otherPosition.y && mousePosition.y + yMax > otherPosition.y) return true;
		return false;
	}

	public int recursivelyGetHeight (CodeBlock refer) {
		if (refer.nestedBlocks != null) {
			for (int i = 0; i < refer.nestedBlocks.Length; i++) {
				return recursivelyGetHeight (refer.nestedBlocks[i]) + 1;
			}
		}
		return 0;
	}
}