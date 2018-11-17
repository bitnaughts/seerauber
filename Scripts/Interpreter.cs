using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpreter : MonoBehaviour {

	/*
	! Front End
	TODO isSailing(), isFighting()
	TODO state management system
	TODO Loop, Task, Check
	* Loop __number__ -> __value__
	! Back End
	* OOP
	TODO Codeblock
	* Loop -> codeBlock[]
	*			 -> string parameter = "___" 
	*      -> string command = "check"
	* Check()
	! Pirate
	TODO CodeBlock Base
	! Interpreter
	* For Pirates
	TODO TriggerEvents()
	* for all nested blocks
	* 	Events()
	*   Recursive call loader
	*   Queue Tasks()
	TODO Base {
	*	 event 
	*  event
	*  event
	* }
	*/
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		/*
			for Every pirate object
				if needs tasks
					for every code block
						if event == true
							run recursively all code blocks inside event block
			^ generates a queue of tasks
		 */
	}
}
