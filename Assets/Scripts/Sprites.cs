using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites : MonoBehaviour {

    public static Sprite KeyR0;
    public static Sprite KeyG0;
    public static Sprite KeyB0;
    public static Sprite KeyR1;
    public static Sprite KeyG1;
    public static Sprite KeyB1;

    public static Sprite MagletRed;
    public static Sprite MagletYellow;
    public static Sprite MagletBlue;
    public static Sprite MagletGreen;
    public static Sprite MagletPurple;
    public static Sprite MagletGrey;

    public static Sprite BarG;
    public static Sprite BarR;

    public static Sprite ShieldWhite;
    //MFST
    public static Sprite KeyChain;



    // Use this for initialization
    void Start () {
        KeyR0 = GameObject.Find("Key0").GetComponent<SpriteRenderer>().sprite;
        KeyG0 = GameObject.Find("Key1").GetComponent<SpriteRenderer>().sprite;
        KeyB0 = GameObject.Find("Key2").GetComponent<SpriteRenderer>().sprite;
        KeyR1 = GameObject.Find("R1").GetComponent<SpriteRenderer>().sprite;
        KeyG1 = GameObject.Find("G1").GetComponent<SpriteRenderer>().sprite;
        KeyB1 = GameObject.Find("B1").GetComponent<SpriteRenderer>().sprite;

        MagletRed = GameObject.Find("MagletRed").GetComponent<SpriteRenderer>().sprite;
        MagletYellow = GameObject.Find("MagletYellow").GetComponent<SpriteRenderer>().sprite;
        MagletBlue = GameObject.Find("MagletBlue").GetComponent<SpriteRenderer>().sprite;
        MagletGreen = GameObject.Find("MagletGreen").GetComponent<SpriteRenderer>().sprite;
        MagletPurple = GameObject.Find("MagletPurple").GetComponent<SpriteRenderer>().sprite;
        MagletGrey = GameObject.Find("MagletGrey").GetComponent<SpriteRenderer>().sprite;

        BarG = GameObject.Find("BarG").GetComponent<SpriteRenderer>().sprite;
        BarR = GameObject.Find("BarR").GetComponent<SpriteRenderer>().sprite;

        ShieldWhite = GameObject.Find("ShieldWhite").GetComponent<SpriteRenderer>().sprite;

        // MFST
        if (Global.charID1 == 0) // enemy
        {
            // TODO: dynamic load
            KeyChain = GameObject.Find("KeyChain").GetComponent<SpriteRenderer>().sprite;
            // TODO char load
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Sprite getKey0(int color)
    {
        if (color == 1) return KeyR0;
        if (color == 2) return KeyG0;
        return KeyB0;
    }

    public static Sprite getKey1(int color)
    {
        if (color == 1) return KeyR1;
        if (color == 2) return KeyG1;
        return KeyB1;
    }

}
