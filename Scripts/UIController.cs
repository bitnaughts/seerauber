using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	BookObject pirateBook = new BookObject();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
		void Update () {
			counter++;
			if (true) {

				//DRAG START
				if (Input.GetMouseButtonDown (0)) {
					for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {

						mouseLocation = Input.mousePosition;
						graphs[graph].over = false;

						float xMin = graphs[graph].positionX;
						float xMax = graphs[graph].positionX + graphs[graph].width;
						float yMin = graphs[graph].positionY;
						float yMax = graphs[graph].positionY + graphs[graph].height;

						if (clickOn (-graphs[graph].width / 2, graphs[graph].width / 2, -graphs[graph].height / 2, graphs[graph].height / 2, mouseLocation, new Vector2 (graphs[graph].positionX, graphs[graph].positionY))) {
							graphs[graph].over = true;
						}
					}
				}
				//DRAG MOVE
				if (Input.GetMouseButton (0)) {
					Vector2 newMouseLocation = Input.mousePosition;
					for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {

						if (graphs[graph].over) {
							graphs[graph].positionX += -(mouseLocation.x - newMouseLocation.x);
							graphs[graph].positionY += -(mouseLocation.y - newMouseLocation.y);
							print (graphs[graph].positionX);
							print (graphs[graph].positionY);
						}
					}
					mouseLocation = newMouseLocation;
				}
				//FORCE UPDATE
				for (int graph = 0; graph < MAX_NUMBER_GRAPHS; graph++) {
					// if (graph == 12) continue;
					graphPrefab[graph].GetComponent<RectTransform> ().GetChild (1).GetChild (0).GetComponent<Text> ().text = "0 to " + graphs[graph].yAxisMax;
					graphPrefab[graph].GetComponent<RectTransform> ().GetChild (2).GetChild (0).GetComponent<Text> ().text = data[counter++].Split (',') [0];
					graphPrefab[graph].GetComponent<RectTransform> ().GetChild (3).GetComponent<Text> ().text = graphs[graph].graphTitle;

					//Checks if it's the sun power									//if graph == 0; index == 4
					if (graph == 8) {

						//SunPower
						//print(float.Parse(data[counter++].Split(',')[getIndexOf(graph)]));
						float val = 0;
						if (float.TryParse (data[counter].Split (',') [getIndexOf (graph)], out val)) {
							if (val > 0) {
								graphs[graph].addPoint (val);
							} else { graphs[graph].addPoint (0f); }
						} else { graphs[graph].addPoint (0f); }

					} else {
						float val = 0;
						if (float.TryParse (data[counter].Split (',') [getIndexOf (graph)], out val)) {
							if (val > 0) {
								graphs[graph].addPoint (val);
							} else { graphs[graph].addPoint (0f); }
						} else { graphs[graph].addPoint (0f); }

					}

					graphPrefab[graph].GetComponent<RectTransform> ().position = new Vector2 (graphs[graph].positionX, graphs[graph].positionY);
					graphPrefab[graph].GetComponent<RectTransform> ().sizeDelta = new Vector2 (graphs[graph].width, graphs[graph].yAxisMax*.75f + 200);
					//UPDATE NODES
					for (int point = 0; point < MAX_NUMBER_POINTS; point++) {
						Vector2 new_pos = new Vector2 ((float) point / (float) MAX_NUMBER_POINTS * (float) graphs[graph].width - graphs[graph].width / 2, graphs[graph].points[point] - graphs[graph].height / 2);
						graphPrefab[graph].GetComponent<NodeManager> ().points[point].GetComponent<RectTransform> ().localPosition = new_pos;
					}
					//UPDATE LINES
					for (int point = 0; point < MAX_NUMBER_POINTS - 1; point++) {
						//distance and theta			 
						//define x of points[point](float)point/(float)MAX_NUMBER_POINTS * (float)graphs[graph].width
						float nodePointX = (float) point / (float) MAX_NUMBER_POINTS * (float) graphs[graph].width;
						float nodePointX1 = ((float) point + 1) / (float) MAX_NUMBER_POINTS * (float) graphs[graph].width;
						float distance = Mathf.Sqrt (Mathf.Pow (nodePointX - nodePointX1, 2) + Mathf.Pow (graphs[graph].points[point] - graphs[graph].points[point + 1], 2));
						float angle = Mathf.Rad2Deg * Mathf.Atan ((graphs[graph].points[point] - graphs[graph].points[point + 1]) / (nodePointX - nodePointX1));
						float xNew = (nodePointX + nodePointX1) / 2 - graphs[graph].width / 2;
						float yNew = (graphs[graph].points[point] + graphs[graph].points[point + 1]) / 2 - graphs[graph].height / 2; // * th

						graphPrefab[graph].GetComponent<NodeManager> ().lines[point].GetComponent<RectTransform> ().sizeDelta = new Vector2 (distance, 5);
						graphPrefab[graph].GetComponent<NodeManager> ().lines[point].GetComponent<RectTransform> ().localRotation = Quaternion.Euler (new Vector3 (0, 0, angle));
						graphPrefab[graph].GetComponent<NodeManager> ().lines[point].GetComponent<RectTransform> ().localPosition = new Vector2 (xNew, yNew);

					}
				}
			}

		}

		//CHECKS IF CLICK IS WITHIN GIVEN BOUNDS
		public bool clickOn (float xMin, float xMax, float yMin, float yMax, Vector2 mousePosition, Vector2 otherPosition) {
			if (mousePosition.x + xMin < otherPosition.x && mousePosition.x + xMax > otherPosition.x)
				if (mousePosition.y + yMin < otherPosition.y && mousePosition.y + yMax > otherPosition.y) return true;
			return false;
		}
}
