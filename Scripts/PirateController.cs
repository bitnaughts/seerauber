using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirateController : MonoBehaviour {

    static string[] nameFirst1 = { "Alex", "Ben", "Bill", "Dan", "Dill", "Ed", "Frank", "Greg", "John", "Jon", "Mart", "Matt", "Nat", "Phil", "Rich", "Sam", "Stan", "Stuart", "Thom", "Will" };
    static string[] nameFirst2 = { "", "", "", "", "", "", "son", "as", "ard", "ward", "uel", "hew", "mund", "iel" };
    static string[] nameLast1 = { "Al", "An", "Arch", "Ard", "Aust", "Bell", "Bick", "Bis", "Brad", "Bran", "Cart", "Cas", "Cax", "Chand", "Chap", "Clar", "Clift", "Daw", "Dix", "Dorm", "Doug", "Ed", "Es", "Fras", "Gard", "Good", "Grif", "Gros", "Had", "Har", "Hol", "John", "Jack", "Lat", "Marsh", "Mart", "Mitch", "Nel", "Nor", "Ob", "Pin", "Pow", "Robin", "Row", "Sal", "Saw", "Sed", "Thomp", "Wal", "Wal", "Whit" };
    static string[] nameLast2 = { "cott", "den", "drews", "man", "all", "ard", "dock", "non", "er", "ton", "well", "ton", "idge", "on", "son", "las", "wards", "mund", "win", "ell", "son", "ford" };

    //Hobbies                // get food,more clean,if ingred,happy other people for 2,need others similar, improves stat, waste time? lel
    static string[] hobbies = { "fishing", "cleaning", "brewing", "singing", "entertaining", "gambling", "sparring", "studying", "praying" };

    // Use this for initialization
    void Start()
    {

    }

    int count = 0;

    // Update is called once per frame
    void Update()
    {
        if (count++ == 100)
        {
            
            count = 0;
            GameObject.Find("Text").GetComponent<Text>().text = generateName();
        }
    }



    public static string generateName()
    {
        return nameFirst1[(int)(Random.value * nameFirst1.Length)] + nameFirst2[(int)(Random.value * nameFirst2.Length)] + " " + nameLast1[(int)(Random.value * nameLast1.Length)] + nameLast2[(int)(Random.value * nameLast2.Length)];
    }
    public static string generateHobby()
    {
        return hobbies[(int)(Random.value * hobbies.Length)];
    }
}
