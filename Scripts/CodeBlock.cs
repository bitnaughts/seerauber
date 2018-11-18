using System;
using System.Collections.Generic;
public class CodeBlock {
    //BRIAN'S UI CODE
    public bool isDragging = false;
    public bool isHovering = false;

    public int sizeX = 200; //scales with parameters...
    public int sizeY = 100; //set size?
    public CodeBlock[] nestedBlocks;
    public string command;
    public string parameter;

    public int indent;

    //const string[] commandlist = { "loop", "task", "check","variable","math" };
    //const string[] tasklist = { "sleep", "loadCannon", "eat", "drink" };
    //if command = loop, then parameter is "X-Y"
    //if command = task, then parameter is from taskList
    //if command = check, parameter is boolean statement
    public CodeBlock () {

        //Randomizer.getInteger()
        nestedBlocks = new CodeBlock[4];
        nestedBlocks[0] = new CodeBlock (new CodeBlock[1] { new CodeBlock ("task", "loadCannon") }, "check", "isCombat");
        nestedBlocks[1] = new CodeBlock (new CodeBlock[1] { new CodeBlock ("check", "hunger~<~10") }, "check", "isDay");
        nestedBlocks[1].nestedBlocks[0].nestedBlocks = new CodeBlock[1] { new CodeBlock ("task", "eat") };
        nestedBlocks[2] = new CodeBlock (new CodeBlock[1] { new CodeBlock ("task", "sail") }, "check", "isSailing");
        nestedBlocks[3] = new CodeBlock (new CodeBlock[1] { new CodeBlock ("task", "sleep") }, "check", "isNight");
    }
    public CodeBlock (CodeBlock[] blockarray, string com, string param) {
        nestedBlocks = blockarray;
        command = com;
        parameter = param;
    }
    public CodeBlock (string com, string param) {
        command = com;
        parameter = param;
    }
    public static string printOut (CodeBlock[] blockArr) {
        string str = "";
        foreach (CodeBlock block in blockArr) {
            //return a string to print to console
            str += (block.parameter) + "\n"; //isn't a function lol
            if (block.nestedBlocks != null)
                str += printOut (block.nestedBlocks);

        }
        return str;
    }

    public static CodeBlock[] toArray (CodeBlock[] input, int depth) {
        List<CodeBlock> output = new List<CodeBlock> ();
        foreach (CodeBlock block in input) {
            block.indent = depth;
            output.Add (block);
            if (block.nestedBlocks != null) {
                output.AddRange (toArray (block.nestedBlocks, depth + 25));
            }

        }
        return output.ToArray ();

    }

    public void addToEnd (string command, string parameter) {
        if (this.nestedBlocks == null) {
            CodeBlock newBlock = new CodeBlock (command, parameter);
            CodeBlock[] newBlockArray = { newBlock };
            this.nestedBlocks = newBlockArray;
        } else {
            CodeBlock[] newBlockArray = new CodeBlock[this.nestedBlocks.Length + 1];
            CodeBlock newBlock = new CodeBlock (command, parameter);
            for (int i = 0; i != newBlockArray.Length; i++) {
                newBlockArray[i] = this.nestedBlocks[i];
            }
            newBlockArray[newBlockArray.Length - 1] = newBlock;
            this.nestedBlocks = newBlockArray;
        }

    }
    public void addToIndex (string command, string parameter, int index) {
        CodeBlock[] newBlockArray = new CodeBlock[this.nestedBlocks.Length + 1];
        CodeBlock newBlock = new CodeBlock (command, parameter);
        for (int i = 0; i != newBlockArray.Length; i++) {
            if (i == index) {
                newBlockArray[i] = newBlock;
            } else {
                newBlockArray[i] = this.nestedBlocks[i];
            }
        }
        this.nestedBlocks = newBlockArray;
    }
    public void move (int initial, int final) {
        CodeBlock temp = this.nestedBlocks[initial];
        this.nestedBlocks[initial] = this.nestedBlocks[final];
        this.nestedBlocks[final] = temp;
    }
}