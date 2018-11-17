public class CodeBlock {
	//BRIAN'S UI CODE
	bool isDragging = false;
	bool isHoving = false;

	int positionX = 0; // for draggy drags
	int positionY = 0;

	int sizeX = 200; //scales with parameters...
	int sizeY = 100; //set size?

	CodeBlock[] block;
	string command;
	string parameter;

	//const string[] commandlist = { "loop", "task", "check" };
	//const string[] tasklist = { "sleep", "loadCannon", "eat", "drink" };
	//if command = loop, then parameter is "X -> Y"
	//if command = task, then parameter is from taskList
	//if command = check, parameter is boolean statement

	public CodeBlock () {
		CodeBlock[] block;
		string command;
		string parameter;
	}
	public CodeBlock (CodeBlock[] blockarray, string com, string param) {
		block = blockarray;
		command = com;
		parameter = param;
	}
	public CodeBlock (string com, string param) {
		command = com;
		parameter = param;
	}

	public void addToEnd (string command, string parameter) {
		if (this.block == null) {
			CodeBlock newBlock = new CodeBlock (command, parameter);
			CodeBlock[] newBlockArray = { newBlock };
			this.block = newBlockArray;
		} else {
			CodeBlock[] newBlockArray = new CodeBlock[this.block.Length + 1];
			CodeBlock newBlock = new CodeBlock (command, parameter);
			for (int i = 0; i != newBlockArray.Length; i++) {
				newBlockArray[i] = this.block[i];
			}
			newBlockArray[newBlockArray.Length - 1] = newBlock;
			this.block = newBlockArray;
		}
        
         
	}
	public void addToIndex (string command, string parameter, int index) {
		CodeBlock[] newBlockArray = new CodeBlock[this.block.Length + 1];
		CodeBlock newBlock = new CodeBlock (command, parameter);
		for (int i = 0; i != newBlockArray.Length; i++) {
			if (i == index) {
				newBlockArray[i] = newBlock;
			} else {
				newBlockArray[i] = this.block[i];
			}
		}
		this.block = newBlockArray;
	}
	public void move (int initial,int final)
	{
		CodeBlock temp = this.block[initial];
		this.block[initial]=this.block[final];
		this.block[final]=temp;
	}
}