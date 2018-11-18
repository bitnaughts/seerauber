using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	GameObject[] blockPool = new GameObject[10];

	public GameObject blockPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) {
			blockPool[i] = Instantiate(blockPrefab, this.transform) as GameObject;
		}
	}

	// Update is called once per frame
	void Update () {
		CodeBlock baseBlock = new CodeBlock();//BookObject.currentPirate.getBaseBlock ();

		for (int i = 0; i < baseBlock.nestedBlocks.Length; i++) {
			blockPool[i].GetComponent<CodeBlockController>().reference = baseBlock.nestedBlocks[i];
		}

	}
}