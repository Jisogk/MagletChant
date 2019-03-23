﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyBoard : MonoBehaviour {
    private Witch witch;
    public GameObject Key0, Key1, Key2;
    private Key key;
    public bool isChanting;
    public int weight;
    public int word; // XXX 1R 2G 3B


    private bool IN1, IN2, IN3;

    // Use this for initialization
    void Start () {
        witch = transform.parent.GetComponentInChildren<Witch>();
        // for record chant
        word = 0;
        weight = 100;
        isChanting = false;
    }
	
	// Update is called once per frame
	private void FixedUpdate () {
        if (witch.id == 0 ?
            (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button2)) :
            (Input.GetKeyDown(KeyCode.Joystick2Button1) || Input.GetKeyDown(KeyCode.Joystick2Button2))) {
            if (word > 0 && witch.state == Witch.NORMAL)
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
        else
        {
            IN1 = witch.id == 0 ? Input.GetKeyDown(KeyCode.Joystick1Button3) : Input.GetKeyDown(KeyCode.Joystick2Button3);
            IN2 = witch.id == 0 ? Input.GetKeyDown(KeyCode.Joystick1Button2) : Input.GetKeyDown(KeyCode.Joystick2Button2);
            IN3 = witch.id == 0 ? Input.GetKeyDown(KeyCode.Joystick1Button1) : Input.GetKeyDown(KeyCode.Joystick2Button1);

            key = IN1 ? Key0.GetComponent<Key>() :
                IN2 ? Key1.GetComponent<Key>() :
                IN3 ? Key2.GetComponent<Key>() : null;

            if (key != null && !key.isChanted)
            {

                if (!key.isFrozen && !isChanting)
                {
                    isChanting = true;
                    // witch.state = Witch.CHANGTING;
                    key.isChanted = true;
                    word += weight * key.color;
                    weight /= 10;
                    key.GetComponent<SpriteRenderer>().sprite = Sprites.getKey1(key.color);
                    key.transform.localScale = new Vector2(0.8f, 0.8f);
                }
                else if (!key.isFrozen && isChanting)
                {
                    key.isChanted = true;
                    word += weight * key.color;
                    weight /= 10;
                    key.GetComponent<SpriteRenderer>().sprite = Sprites.getKey1(key.color);
                    key.transform.localScale = new Vector2(0.8f, 0.8f);
                }
            }

        }
        
    }
}
