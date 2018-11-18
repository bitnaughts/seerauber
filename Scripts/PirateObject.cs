
using System;
using System.Collections.Generic;
public class PirateObject
{
    CodeBlock baseBlock;
    public Queue<string> tasks;
        //events in it
        //tasks and loops n stuff
    string name; 
    public bool isHungry, isThirsty, isTired, isInjured, isIdle, isMoving;
    public int hunger=9;
    public int thirst=9;
    public int sailing=25;
    public int sleep=20;
    public PirateObject() {
        baseBlock = new CodeBlock();
        tasks = new Queue<string>();
        hunger=9;
        thirst=9;
        sailing=25;
        sleep = 20;
    }
    public CodeBlock getBaseBlock()
    {
        return baseBlock;
    }







}
