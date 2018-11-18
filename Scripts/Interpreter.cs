using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	//string[,] vars = new string[20,2];

	public void run () {

		for (int i = 0; i < pirates.Length; i++) {
			interpret (pirates[i].getBaseBlock ().nestedBlocks, i);
		}
	}

	void interpret (CodeBlock[] blocks, int index) {
		foreach (CodeBlock block in blocks) {
			switch (block.command) {
				case "loop":
					string[] temp = block.parameter.Split (new Char[] { '~' });
					int lower = Int32.Parse (temp[0]), upper = Int32.Parse (temp[1]);
					for (int i = lower; i < upper; i++)
						interpret (block.nestedBlocks, index);
					break;
				case "variable":
					//vars[index]=pirates[index].parameter.Split("~");
					break;
				case "math":
					//math(param, index)
					break;
				case "task":
					//if block.command = task, then enqueue parameter
					//pirates[index].tasks.Enqueue (block.parameter);
					break;
				case "check":
					if (check (block.parameter, index)) {
						interpret (block.nestedBlocks, index);
					}
					break;
			}
		}

	}
	void math(string param, int index)
	{
		string[] arr = param.Split(new Char[] {'~'});
		for(int i = 0;i<arr.Length;i++)
		{
			
		}
	}
	bool check (string param, int index) {
		if (!param.Contains ("~")) {
			if (param == "true")
				return true;
			if (param == "false")
				return false;
			switch (param) {
				case "isNight()":
					return StateMachine.isNight;
					break;
				case "isHungry()":
					return pirates[index].isHungry;
				case "isThirsty()":
					return pirates[index].isThirsty;
				case "isCombat()":
					return StateMachine.isCombat;
					break;
				case "isTired()":
					return pirates[index].isTired;
					break;
				case "isInjured()":
					return pirates[index].isInjured;
					break;
				case "isIdle()":
					return pirates[index].isIdle;
					break;
				case "isMoving()":
					return pirates[index].isMoving;
					break;
			}

		}
		string[] arr = param.Split (new Char[] { '~' });
		bool[] stateBool = new bool[2];
		float[] stateFloat = new float[2];
		int counter = 0;
		for (int i = 0; i != arr.Length; i++) {
			if (arr[i].Contains ("(") && arr[i].Contains (")")) {
				switch (param) {
					case "isNight()":
						stateBool[counter] =  StateMachine.isNight;
						break;
					case "isHungry()":
						stateBool[counter] = pirates[index].isHungry;
						break;
					case "isThirsty()":
						stateBool[counter] = pirates[index].isThirsty;
						break;
					case "isCombat()":
						stateBool[counter] =  StateMachine.isCombat;
						break;
					case "isTired()":
						stateBool[counter] = pirates[index].isTired;
						break;
					case "isInjured()":
						stateBool[counter] = pirates[index].isInjured;
						break;
					case "isIdle()":
						stateBool[counter] = pirates[index].isIdle;
						break;
					case "isMoving()":
						stateBool[counter] = pirates[index].isMoving;
						break;
					case "shipSpeed":
						stateFloat[counter] = StateMachine.shipSpeed;
						break;
					case "shipAngle":
						stateFloat[counter] = StateMachine.shipAngle;
						break;
					case "windSpeed":
						stateFloat[counter] = StateMachine.windSpeed;
						break;
					case "windAngle":
						stateFloat[counter] = StateMachine.windAngle;
						break;
					case "mastAngle":
						stateFloat[counter] = StateMachine.mastAngle;
						break;
				}
			} else if (arr[i] == "true") {
				stateBool[counter] = true;
				counter++;
			} else if (arr[i] == "false") {
				stateBool[counter] = false;
				counter++;
			} else {
				stateFloat[counter] = float.Parse (arr[i]);
				counter++;
			}
		}
		for (int i = 0; i != arr.Length; i++) {
			switch (arr[i]) {
				case "<":
					return stateFloat[0] < stateFloat[1];
					break;
				case ">":
					return stateFloat[0] > stateFloat[1];
					break;
				case "<=":
					return stateFloat[0] <= stateFloat[1];
					break;
				case ">=":
					return stateFloat[0] >= stateFloat[1];
					break;
				case "!=":
					return stateFloat[0] != stateFloat[1];
					break;
				case "==":
					return stateFloat[0] == stateFloat[1];
					break;
				case "||":
					return stateBool[0] || stateBool[1];
					break;
				case "&&":
					return stateBool[0] && stateBool[1];
					break;
			}
		}
		return false;

	}

	/*
		for Every pirate object
			if needs tasks
				for every code block
					if event == true
						run recursively all code blocks inside event block
		^ generates a queue of tasks
	 */

}