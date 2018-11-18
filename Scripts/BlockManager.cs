using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	GameObject[] blockPool = new GameObject[50];

	public GameObject blockPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 25; i++) {
			blockPool[i] = Instantiate (blockPrefab, this.transform) as GameObject;
			blockPool[i].SetActive (false);
		}
	}
	int count = 0;
	// Update is called once per frame
	void Update () {
		CodeBlock baseBlock = new CodeBlock (); //BookObject.currentPirate.getBaseBlock ();

		CodeBlock[] output = CodeBlock.toArray (baseBlock.nestedBlocks, 0);
		foreach (CodeBlock block in output) {
			print (block.parameter);
		}
	//	print (CodeBlock.printOut (baseBlock.nestedBlocks));
		count = -1;

		///printOut(baseBlock.nestedBlocks);
		for (int i = 0; i < output.Length; i++) {
			//	if (i == 0) {
			//print (baseBlock.nestedBlocks[i]);
			print(output[i].parameter);
			blockPool[i].SetActive (true);
			blockPool[i].transform.GetChild (0).gameObject.GetComponent<CodeBlockController> ().reference = output[i]; //output.nestedBlocks[i];
			//	blockPool[i].
			//parameter
			blockPool[i].GetComponent<RectTransform> ().localPosition = new Vector2 (output[i].indent, -30 * i);
			//}
		}

	}

	void printOut (CodeBlock[] blockArr) {
		//print (count);
		foreach (CodeBlock block in blockArr) {
			count++;
			blockPool[count].SetActive (true);
			blockPool[count].transform.GetChild (0).gameObject.GetComponent<CodeBlockController> ().reference = block; //.parameter;
			//	blockPool[i].
			//parameter
			blockPool[count].GetComponent<RectTransform> ().localPosition = new Vector2 (0, -100 * count);
			if (block.nestedBlocks != null)
				printOut (block.nestedBlocks);
			//return a string to print to console
			//str += (block.parameter) + "\n"; //isn't a function lol
			//if (block.nestedBlocks != null)
			//	str += printOut (block.nestedBlocks);

		}

	}
}