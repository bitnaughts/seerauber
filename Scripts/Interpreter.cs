using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interpreter {

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

	/*
	Pirate object

	values:
	codeBlock


	*/
	PirateObject[] pirates;

	/*public void run () {

		for (int i = 0; i != pirates.Length; i++) {
			interpret (pirates[i].getBaseBlock (), i);
		}
	}

	 void interpret (CodeBlock[] blocks, int index) {
		foreach (CodeBlock block in blocks) {
			switch (block.command) {
				case "loop":
					string[] temp = block.parameter.Split ('-');
					int 
					for (int i = Int32.Parse (temp[0]); i != Int32.Parse (temp[1]); i++)
						interpret (block.nestedBlocks, index);
					break;

					//if parentBlock.command = task, then enqueue parameter

				case "task":
					pirates[index].tasks.Enqueue (parentBlock.parameter);
					break;
				case "check":
					//block.parameter
					break;
			}
		}
	}
bool check(string param)
{
	string[] arr = param.Split('-');
	if(arr[0].Contains("(")&&arr[0].Contains(")"))

}*/
	/*string getCommand(CodeBlock block)
	{
		switch (block.command)
		{
			case "loop":
			break;
			case "task":
				
			break;
			case "check":
			break;
		}
	}*/

	/*
		for Every pirate object
			if needs tasks
				for every code block
					if event == true
						run recursively all code blocks inside event block
		^ generates a queue of tasks
	 */

}