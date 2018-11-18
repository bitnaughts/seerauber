using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateController : MonoBehaviour {

    const int LADDER = 0;

    GameObject codebase;
    public PirateObject reference;

    // Use this for initialization
    void Start () {
        reference = new PirateObject ();
        codebase = GameObject.Find ("CodeBase");
    }

    int count = 0;
    Vector2 target = new Vector2 (0, 0);

    

    static string[] nameFirst1 = { "Alex", "Ben", "Bill", "Dan", "Dill", "Ed", "Frank", "Greg", "John", "Jon", "Mart", "Matt", "Nat", "Phil", "Rich", "Sam", "Stan", "Stuart", "Thom", "Will" };
    static string[] nameFirst2 = { "", "", "", "", "", "", "son", "as", "ard", "ward", "uel", "hew", "mund", "iel" };
    static string[] nameLast1 = { "Al", "An", "Arch", "Ard", "Aust", "Bell", "Bick", "Bis", "Brad", "Bran", "Cart", "Cas", "Cax", "Chand", "Chap", "Clar", "Clift", "Daw", "Dix", "Dorm", "Doug", "Ed", "Es", "Fras", "Gard", "Good", "Grif", "Gros", "Had", "Har", "Hol", "John", "Jack", "Lat", "Marsh", "Mart", "Mitch", "Nel", "Nor", "Ob", "Pin", "Pow", "Robin", "Row", "Sal", "Saw", "Sed", "Thomp", "Wal", "Wal", "Whit" };
    static string[] nameLast2 = { "cott", "den", "drews", "man", "all", "ard", "dock", "non", "er", "ton", "well", "ton", "idge", "on", "son", "las", "wards", "mund", "win", "ell", "son", "ford" };

    /*Insults*/
    static string[] insults1 = { "artless", "bawdy", "beslubbering", "bootless", "churlish", "cockered", "clouted", "craven", "currish", "dankish", "dissembling", "droning", "errant", "fawning", "fobbing", "froward", "frothy", "gleeking", "goatish", "gorbellied", "impertinent", "infectious", "jarring", "loggerheaded", "lumpish", "mammering", "mangled", "mewling", "paunchy", "pribbling", "puking", "puny", "qualling", "rank", "reeky", "roguish", "ruttish", "saucy ", "spleeny", "spongy", "surly", "tottering", "unmuzzled", "vain", "venomed", "villainous", "warped", "wayward", "weedy", "yeasty" };
    static string[] insults2 = { "base-court", "bat-fowling", "beef-witted", "beetle-headed", "boil-brained", "clapper-clawed", "clay-brained", "common-kissing", "crook-pated", "dismal-dreaming", "dizzy-eyed", "doghearted", "dread-bolted", "earth-vexing", "elf-skinned", "fat-kidneyed", "fly-bitten", "folly-fallen", "fool-born", "full-gorged", "guts-griping", "half-faced", "hasty-witted", "hedge-born", "hell-hated", "idle-headed", "ill-breeding", "ill-nurtured", "knotty-pated", "milk-livered", "motley-minded", "onion-eyed", "plume-plucked", "pottle-deep", "pox-marked", "reeling-ripe", "rough-hewn", "rude-growing", "rump-fed", "shard-born", "sheep-biting", "spur-galled", "swag-bellied", "tardy-gaited", "tickle-brained", "toad-spotted", "unchin-snouted", "weather-bitten" };
    static string[] insults3 = { "apple-john", "baggage", "barnacle", "bladder", "boar-pig", "bugbear", "bum-bailey", "canker-blossom", "clack-dish", "clotpole", "coxcomb", "codpiece", "death-token", "dewberry", "flap-dragon", "flax-wench", "flirt-gill", "foot-licker", "fustilarian", "giglet", "gudgeon", "haggard", "harpy", "hedge-pig", "horn-beast", "hugger-mugger", "joithead", "lewdster", "lout", "maggot-pie", "malt-worm", "mammet", "measle", "minnow", "miscreant", "moldwarp", "mumble-news", "nut-hook", "pigeon-egg", "pignut", "puttock", "pumpion", "ratsbane", "scut", "skainsmate", "strumpet", "varlot", "vassal", "whey-face", "wagtail" };

   
    //Hobbies                // get food,more clean,if ingred,happy other people for 2,need others similar, improves stat, waste time? lel
    static string[] hobbies = { "fishing", "cleaning", "brewing", "singing", "entertaining", "gambling", "sparring", "studying", "praying" };



    public static string generateName()
    {
        return nameFirst1[(int)(Random.value * nameFirst1.Length)] + nameFirst2[(int)(Random.value * nameFirst2.Length)] + " " + nameLast1[(int)(Random.value * nameLast1.Length)] + nameLast2[(int)(Random.value * nameLast2.Length)];
    }
    public static string generateHobby()
    {
        return hobbies[(int)(Random.value * hobbies.Length)];
    }
    public static string generateCuss(int severity)
    {
        switch (severity)
        {
            case 0:
                return insults3[(int)(Random.value * insults3.Length)];
            case 1:
                return insults2[(int)(Random.value * insults2.Length)] + " " + insults3[(int)(Random.value * insults3.Length)];
            case 2:
                return insults1[(int)(Random.value * insults1.Length)] + " " + insults2[(int)(Random.value * insults2.Length)] + " " + insults3[(int)(Random.value * insults3.Length)];
        }
        return "";
    }
    // Update is called once per frame
    void Update () {
        //print (generateCuss(2));
        // print (reference.getBaseBlock ());
        if (count % 2 == 0) {
            reference.tasks = Interpreter.run (reference); //print(reference.tasks.Count);//reference.tasks.Peek());
            if (reference.tasks.Count > 0) {
                //print (reference.tasks.Peek ()); //reference.tasks.Peek());
                if (reference.tasks.Peek () == "eat") {
                    if (MoveTo (new Vector2 (4, -2))) {
                        reference.tasks.Dequeue ();
                        reference.hunger = 0;
                    }
                } else if (reference.tasks.Peek () == "drink") {
                    if (MoveTo (new Vector2 (2, -4))) {
                        reference.tasks.Dequeue ();
                        reference.thirst = 0;
                    }
                } else if (reference.tasks.Peek () == "sail") {
                    if (MoveTo (new Vector2 (5, 0))) {
                        reference.tasks.Dequeue ();
                        reference.sailing = 0;
                    }
                } else if (reference.tasks.Peek () == "sleep") {
                    if (MoveTo (new Vector2 (4, -4))) {
                        reference.tasks.Dequeue ();
                        reference.sleep = 0;
                    }
                }
            }
        }

        if (count++ == 50) {
            //print (reference.hunger + "," + reference.thirst);
            reference.hunger += Randomizer.getInteger () / 4;
            reference.thirst += Randomizer.getInteger () / 2;
            reference.sailing += Randomizer.getInteger ();
            reference.sleep += Randomizer.getInteger ();
            count = 0;
            //target = new Vector2 (Randomizer.getInteger (), -Randomizer.getInteger ());
        }
        // if (!MoveTo(GetLocation(reference.tasks.peek.target)))

    }

    void OnMouseOver () {
        if (Input.GetMouseButtonDown (0)) {
            UIController.clickOnPirate (reference);
        }
    }
    int GetID (string obj) {
        if (obj == "Ladder") {
            return 0;
        }
        return -1;
    }

    Vector2 GetLocation (string obj) {
        return GetLocation (GetID (obj));
    }
    Vector2 GetLocation (int obj) {
        switch (obj) {
            case LADDER:
                return new Vector2 (-1, 0);
        }
        return new Vector2 (100, 100);
    }
    bool MoveTo (Vector2 target) {
        Vector2 unroundedTransform = transform.position;
        unroundedTransform *= 10;
        transform.position = new Vector2 (((int) unroundedTransform.x) / 10f, ((int) unroundedTransform.y) / 10f);

        if (transform.position.y != target.y) {
            /* Find a ladder */
            if (transform.position.x < GetLocation ("Ladder").x) {
                transform.Translate (new Vector2 (.2f, 0));
            } else if (transform.position.x > GetLocation ("Ladder").x) {
                transform.Translate (new Vector2 (-.2f, 0));
            } else {
                /* Move on ladder */
                if (transform.position.y < target.y) {
                    transform.Translate (new Vector2 (0, .2f));
                } else if (transform.position.y > target.y) {
                    transform.Translate (new Vector2 (0, -.2f));
                }
            }
        } else {
            /* Navigate directly to target */
            if (transform.position.x < target.x) {
                transform.Translate (new Vector2 (.2f, 0));
            } else if (transform.position.x > target.x) {
                transform.Translate (new Vector2 (-.2f, 0));
            } else {
                return true;
            }
        }
        return false;
    }

}