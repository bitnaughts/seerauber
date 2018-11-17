using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBlockController : MonoBehaviour {

	CodeBlock reference;
	//Mouse States
	Vector2 mouseLocation = new Vector2 (0, 0);
	Vector2 newMouseLocation = new Vector2 (0, 0);

	// Use this for initialization
	void Start () {
		reference = new CodeBlock();
	}

	// Update is called once per frame
	void Update () {
		int height = (reference.nestedBlocks == null) ? 0 : recursivelyGetHeight(reference);//l.nestedBlocks.Length;
		this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (200, height * 100 + 100);
		//DRAG START
		if (Input.GetMouseButtonDown (0)) {
			mouseLocation = Input.mousePosition;
			reference.isHovering = false;

			float xMin = this.GetComponent<RectTransform> ().position.x;
			float xMax = this.GetComponent<RectTransform> ().position.x + this.GetComponent<RectTransform> ().sizeDelta.x; // graphs[graph].positionX + graphs[graph].width;
			float yMin = this.GetComponent<RectTransform> ().position.y; //graphs[graph].positionY;
			float yMax = this.GetComponent<RectTransform> ().position.y + this.GetComponent<RectTransform> ().sizeDelta.y;

			RectTransform blockTransform = this.GetComponent<RectTransform> ();

			if (clickOn (-blockTransform.sizeDelta.x / 2, blockTransform.sizeDelta.x / 2, -blockTransform.sizeDelta.y / 2, blockTransform.sizeDelta.y / 2, mouseLocation, this.GetComponent<RectTransform> ().position)) {
				reference.isHovering = true;
			}

		}
		//DRAG MOVE
		if (Input.GetMouseButton (0)) {
			newMouseLocation = Input.mousePosition;

			if (reference.isHovering) {
				Vector2 newPosition = this.GetComponent<RectTransform> ().position;
				newPosition.x += -(mouseLocation.x - newMouseLocation.x);
				newPosition.y += -(mouseLocation.y - newMouseLocation.y);
				this.GetComponent<RectTransform> ().position = newPosition;
			}
			mouseLocation = newMouseLocation;
		}
	}
	public bool clickOn (float xMin, float xMax, float yMin, float yMax, Vector2 mousePosition, Vector2 otherPosition) {
		if (mousePosition.x + xMin < otherPosition.x && mousePosition.x + xMax > otherPosition.x)
			if (mousePosition.y + yMin < otherPosition.y && mousePosition.y + yMax > otherPosition.y) return true;
		return false;
	}


	public int recursivelyGetHeight(CodeBlock ref) {
		for (int i = 0; i < ref.nestedBlocks.Length; i++) {
			return recursivelyGetHeight(ref.nestedBlocks[i]) + 1;
		}
		return 1;
	}
}