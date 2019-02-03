using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyBoard : MonoBehaviour {
    public GameObject witchObj;
    public WitchPlayer witch;
    public GameObject Key0, Key1, Key2;
    public bool isChanting;
    public int weight;
    public int word; // XXX 0R 1G 2B


    // Use this for initialization
    void Start () {
        word = 0;
        weight = 100;
        isChanting = false;
        witch = witchObj.GetComponent<WitchPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            if (word > 0)
            {
                Debug.Log(word);

                witch.chant(word);
                word = 0;
                if (Key0.GetComponent<Key>().isChanted)
                    Key0.GetComponent<Key>().refresh();
                if (Key1.GetComponent<Key>().isChanted)
                    Key1.GetComponent<Key>().refresh();
                if (Key2.GetComponent<Key>().isChanted)
                    Key2.GetComponent<Key>().refresh();
                weight = 100;
                isChanting = false;
            }
        }
    }
}
