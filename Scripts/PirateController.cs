using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateController : MonoBehaviour {

    const int LADDER = 0;

    GameObject codebase;
    PirateObject reference;

    // Use this for initialization
    void Start () {
        reference = new PirateObject ();
        codebase = GameObject.Find("CodeBase");
    }

    int count = 0;
    Vector2 target = new Vector2(0,0);

    // Update is called once per frame
    void Update () {

        if (count++ == 100)
        {
            count = 0;
            target = new Vector2(Randomizer.getInteger(), -Randomizer.getInteger());
        }
        MoveTo(target);
        // if (!MoveTo(GetLocation(reference.tasks.peek.target)))

    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0))
        {
            codebase.GetComponent<UIController>().clickOnPirate(reference);
        }
    }
    int GetID(string obj) {
        if (obj == "Ladder") {
            return 0;
        }
        return -1;
    }

    Vector2 GetLocation (string obj) {
        return GetLocation(GetID(obj));
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
        transform.position = new Vector2(((int)unroundedTransform.x)/10f, ((int)unroundedTransform.y)/10f);

        if (transform.position.y != target.y) {
            /* Find a ladder */
            if (transform.position.x < GetLocation ("Ladder").x) {
                transform.Translate (new Vector2 (.1f, 0));
            } else if (transform.position.x > GetLocation ("Ladder").x) {
                transform.Translate (new Vector2 (-.1f, 0));
            } else {
                /* Move on ladder */
                if (transform.position.y < target.y) {
                    transform.Translate (new Vector2 (0, .1f));
                } else if (transform.position.y > target.y) {
                    transform.Translate (new Vector2 (0, -.1f));
                }
            }
        } else {
            /* Navigate directly to target */
            if (transform.position.x < target.x) {
                transform.Translate (new Vector2 (.1f, 0));
            } else if (transform.position.x > target.x) {
                transform.Translate (new Vector2 (-.1f, 0));
            } else {
                return true;
            }
        }
        return false;
    }

}