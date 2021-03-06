﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maglet: MonoBehaviour{

    // Maglet tpye
    public static int PHY = 1; // R
    public static int SPI = 2; // G
    public static int MAG = 3; // B


    public int playerID;
    public int type;
    public int damage;
    public int energy;
    public string buff;

    public void set(int p, int t, int d, int e, string buff = "")
    {
        playerID = p; type = t; damage = d; energy = e; this.buff = buff;

    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject enemy = collider.gameObject;
        if (enemy.tag == "Witch")
        {
            Debug.Log("ML & W");
            if (enemy.GetComponent<Witch>().id != playerID)
            {
                enemy.GetComponent<Witch>().hurt(damage);
                enemy.GetComponent<Witch>().getBuff(buff);
                Destroy(gameObject);
            }
            return;
        }
        else if (enemy.tag == "Maglet")
        {
            Debug.Log("ML & ML!");
            // only run on P1 maglet
            if(playerID == 0 && enemy.GetComponent<Maglet>().playerID == 1)
            {
                if(type == enemy.GetComponent<Maglet>().type)
                    // same type
                {
                    int temp = energy;
                    if (buff != "InfiniteEnergy")
                        energy -= enemy.GetComponent<Maglet>().energy;
                    if (enemy.GetComponent<Maglet>().buff != "InfiniteEnergy")
                        enemy.GetComponent<Maglet>().energy -= temp;
                    if (enemy.GetComponent<Maglet>().energy <= 0)
                        Destroy(enemy);
                    if (energy <= 0)
                        Destroy(gameObject);
                }
                else if(type == enemy.GetComponent<Maglet>().type-1 || type == enemy.GetComponent<Maglet>().type + 2)
                    // this > enemy
                {
                    int temp = energy;
                    if (buff != "InfiniteEnergy")
                        energy -= enemy.GetComponent<Maglet>().energy/2;
                    if (enemy.GetComponent<Maglet>().buff != "InfiniteEnergy")
                        enemy.GetComponent<Maglet>().energy -= temp *2;
                    if (enemy.GetComponent<Maglet>().energy <= 0)
                        Destroy(enemy);
                    if (energy <= 0)
                        Destroy(gameObject);
                }
                else
                    // this < enemy
                {
                    int temp = energy;
                    if (buff != "InfiniteEnergy")
                        energy -= enemy.GetComponent<Maglet>().energy * 2;
                    if (enemy.GetComponent<Maglet>().buff != "InfiniteEnergy")
                        enemy.GetComponent<Maglet>().energy -= temp / 2;
                    if (enemy.GetComponent<Maglet>().energy <= 0)
                        Destroy(enemy);
                    if (energy <= 0)
                        Destroy(gameObject);
                }
            }
            return;
        }   
        else if (enemy.tag == "Stone")
        {
            Debug.Log("ML & S!");
            Debug.Log(enemy.GetComponent<MoonStone>().playerID);
            Debug.Log(playerID);
            if (enemy.GetComponent<MoonStone>().playerID != playerID)
            {
                enemy.GetComponent<MoonStone>().hurt(damage);
                Destroy(gameObject);
            }
            return;
        }
            
    }
    
}
