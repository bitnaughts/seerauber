using System;
using System.Collections;
using System.Collections.Generic;

public static class Interpreter {
//	public static PirateObject[] pirates;
	//string[,] vars = new string[20,2];
	public static string task = "unset";
	public static Queue<string> run (PirateObject pirate)
	{
		return interpret (pirate.getBaseBlock ().nestedBlocks, pirate, new Queue<string>());
	}
	/* public static void run () {

		for (int i = 0; i < pirates.Length; i++) {
			if (pirates[i].tasks.Count == 0)
				interpret (pirate.getBaseBlock ().nestedBlocks, pirate,new Queue<string>);
		}
	}*/

	public static Queue<string> interpret (CodeBlock[] blocks,PirateObject pirate,Queue<string> queue) {
		
		foreach (CodeBlock block in blocks) {
			switch (block.command) {
				case "loop":
					string[] temp = block.parameter.Split (new Char[] { '~' });
					int lower = Int32.Parse (temp[0]), upper = Int32.Parse (temp[1]);
					for (int i = lower; i < upper; i++)
						queue = interpret (block.nestedBlocks, pirate,queue);
					break;
				case "variable":
					//vars[index]=pirates[index].parameter.Split("~");
					break;
				case "math":
					//math(param, index)
					break;
				case "task":
					//if block.command = task, then enqueue parameter
					//task = block.parameter;
					queue.Enqueue (block.parameter);
					break;
				case "check":
				//	task = check (block.parameter, index) + "";
					if (check (block.parameter, pirate)) {
						queue = interpret (block.nestedBlocks, pirate,queue);
					}
					break;
			}
		}
		return queue;

	}
	public static void math (string param, int index) {
		/*
				string[] splitParameterArray = param.Split (new Char[] { '~' });
				float[] floats = new float[2];
				int counter = 0;
				for (int i = 0; i < splitParameterArray.Length; i++) {
					switch (param) {
						case "shipSpeed()":
							floats[counter] = StateMachine.shipSpeed;
							counter++;
							break;
						case "shipAngle()":
							floats[counter] = StateMachine.shipAngle;
							counter++;
							break;
						case "windSpeed()":
							floats[counter] = StateMachine.windSpeed;
							counter++;
							break;
						case "windAngle()":
							floats[counter] = StateMachine.windAngle;
							counter++;
							break;
						case "mastAngle()":
							floats[counter] = StateMachine.mastAngle;
							counter++;
							break;
					}
					if (splitParameterArray[i] == "true") {
						bools[counter] = true;
						counter++;
					} else if (splitParameterArray[i] == "false") {
						bools[counter] = false;
						counter++;
					} else {
						stateFloat[counter] = float.Parse (splitParameterArray[i]);
						counter++;
					}
				}
				for (int i = 0; i != splitParameterArray.Length; i++) 
				{
					switch (splitParameterArray[i]) 
					{
						case "+":
							vars[index,1] = floats[0] + floats[1];
							break;
						case "-":
							vars[index,1] = floats[0] - floats[1];
							break;
						case "*":
							vars[index,1] = floats[0] * floats[1];
							break;
						case "/":
							vars[index,1] = floats[0] / floats[1];
							break;
					}
				}

			*/
	}
	public static bool check (string param, PirateObject pirate) {
		if (!param.Contains ("~")) {
			if (param == "true")
				return true;
			if (param == "false")
				return false;
			switch (param) {
				case "isNight":
					return StateMachine.isNight;
					break;
				case "isDay":
					return StateMachine.isDay;
					break;
				case "isHungry":
					return pirate.isHungry;
				case "isThirsty":
					return pirate.isThirsty;
				case "isCombat":
					return StateMachine.isCombat;
					break;
				case "isTired":
					return pirate.isTired;
					break;
				case "isInjured":
					return pirate.isInjured;
					break;
				case "isIdle":
					return pirate.isIdle;
					break;
				case "isMoving":
					return pirate.isMoving;
					break;
				case "isSailing":
					return StateMachine.isSailing;
					break;
			}

		} else {
			string[] splitParameterArray = param.Split ('~');
			// hunger~<~10
			bool[] stateBool = new bool[4];
			int[] stateFloat = new int[4];
			int counter = 0;

			for (int i = 0; i < splitParameterArray.Length; i += 2) {
				//if (splitParameterArray[i].Contains ("(") && splitParameterArray[i].Contains (")")) {
				if (splitParameterArray[i] == "hunger") {
					stateFloat[counter] = pirate.hunger;
					counter++;
				} else if (splitParameterArray[i] == "thirst") {
					stateFloat[counter] = pirate.thirst;
					counter++;
				}
				else if (splitParameterArray[i] == "sleep") {
					stateFloat[counter] = pirate.sleep;
					counter++;
				}
				else if (splitParameterArray[i] == "sailing") {
					stateFloat[counter] = pirate.sailing;
					counter++;
				
				} else if (splitParameterArray[i] == "true") {
					stateBool[counter] = true;
					counter++;
				} else if (splitParameterArray[i] == "false") {
					stateBool[counter] = false;
					counter++;
				} else {
					//	task = param + ", " + i + "," + splitParameterArray.Length.ToString ();
					stateFloat[counter] = Int32.Parse (splitParameterArray[i]);
					counter++;
				}

			}
			counter = 0;
			//task = stateFloat[counter].ToString () + ", "+stateFloat[counter + 1];
			switch (splitParameterArray[1]) {
				case "<":
				//task = stateFloat[counter].ToString () + ",++ "+stateFloat[counter + 1];
					return stateFloat[counter] < stateFloat[counter + 1];
					break;
				case ">":
					return stateFloat[counter] > stateFloat[counter + 1];
					break;
				case "<=":
					return stateFloat[counter] <= stateFloat[counter + 1];
					break;
				case ">=":
					return stateFloat[counter] >= stateFloat[counter + 1];
					break;
				case "!=":
					return stateFloat[counter] != stateFloat[counter + 1];
					break;
				case "==":
					return stateFloat[counter] == stateFloat[counter + 1];
					break;
				case "||":
					return stateBool[counter] || stateBool[counter + 1];
					break;
				case "&&":
					return stateBool[counter] && stateBool[counter + 1];
					break;
			}

			return false;
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