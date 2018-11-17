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

	//const string[] commandlist = { "loop", "task", "check" };
	//const string[] tasklist = { "sleep", "loadCannon", "eat", "drink" };
	//if command = loop, then parameter is "X -> Y"
	//if command = task, then parameter is from taskList
	//if command = check, parameter is boolean statement

	public CodeBlock () {
        //random amount of subchildren
        int size = (int) (new Random().next() * 10);
		CodeBlock[] nestedBlocks new CodeBlock[size];
		string command="";
		string parameter="";
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
	public void move (int initial,int final)
	{
		CodeBlock temp = this.nestedBlocks[initial];
		this.nestedBlocks[initial]=this.nestedBlocks[final];
		this.nestedBlocks[final]=temp;
	}
}