using System;
using System.Collections;
using System.Collections.Generic;

public static class Interpreter {
	public static PirateObject[] pirates;
	//string[,] vars = new string[20,2];
	public static string task;
	public static void run () {

		for (int i = 0; i < pirates.Length; i++) {
			if (pirates[i].tasks.Count == 0)
				interpret (pirates[i].getBaseBlock ().nestedBlocks, i);
		}
	}

	public static void interpret (CodeBlock[] blocks, int index) {
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
					//task = block.parameter;
					pirates[index].tasks.Enqueue (block.parameter);
					break;
				case "check":
					if (check (block.parameter, index)) {
						interpret (block.nestedBlocks, index);
					}
					break;
			}
		}

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
	public static bool check (string param, int index) {
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
					return pirates[index].isHungry;
				case "isThirsty":
					return pirates[index].isThirsty;
				case "isCombat":
					return StateMachine.isCombat;
					break;
				case "isTired":
					return pirates[index].isTired;
					break;
				case "isInjured":
					return pirates[index].isInjured;
					break;
				case "isIdle":
					return pirates[index].isIdle;
					break;
				case "isMoving":
					return pirates[index].isMoving;
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

			for (int i = 0; i < splitParameterArray.Length; i+=2) {
				//if (splitParameterArray[i].Contains ("(") && splitParameterArray[i].Contains (")")) {
				if (param == "hunger") {
					stateFloat[counter] = pirates[index].hunger;
				} else if (param == "isThirsty") {
					stateBool[counter] = pirates[index].isThirsty;
				} else if (splitParameterArray[i] == "true") {
					stateBool[counter] = true;
					counter++;
				} else if (splitParameterArray[i] == "false") {
					stateBool[counter] = false;
					counter++;
				} else  {
					task = param + ", " + i + "," + splitParameterArray.Length.ToString ();
					stateFloat[counter] = Int32.Parse (splitParameterArray[i]);
					counter++;
				}

			}
			counter = 0;
			switch (splitParameterArray[1]) {
				case "<":
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