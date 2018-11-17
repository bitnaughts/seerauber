public class CodeBlock
{
    //BRIAN'S UI CODE
    bool isDragging = false;
    int positionX = 0; // for draggy drags
    int positionY = 0;
    
    int sizeX = 200; //scales with parameters...
    int sizeY = 100; //set size?



	const string[] commandlist = {"loop", "task", "check"};
	const string[] tasklist = {"sleep", "loadCannon","eat","drink"};
	//if command = loop, then parameter is "X -> Y"
	//if command = task, then parameter is from taskList
	//if command = check, parameter is boolean statement
						
	public CodeBlock () {
		CodeBlock[] block;
		string command;
		string parameter;
		boolean endScope;		
		
		
		
	}
	
}
