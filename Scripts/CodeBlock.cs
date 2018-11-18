using System;
public class CodeBlock {
    //BRIAN'S UI CODE
    public bool isDragging = false;
    public bool isHovering = false;

    public int positionX = 0; // for draggy drags
    public int positionY = 0;

    public int sizeX = 200; //scales with parameters...
    public int sizeY = 100; //set size?
    public CodeBlock[] nestedBlocks;
    public string command;
    public string parameter;

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
		nestedBlocks[1].nestedBlocks = new CodeBlock[1]{ new CodeBlock("task","eat")};
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
	public string printOut(CodeBlock[] blockArr)
	{
		string out;
		foreach (CodeBlock block in blocks)
		{
            //return a string to print to console
			out += (CodeBlock.parameter); //isn't a function lol
			if
		}
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