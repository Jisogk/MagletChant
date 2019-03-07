using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maglet: MonoBehaviour{
    
    // Maglet tpye

    public int playerID;
    public int damage;
    public int energy;
    public string buff;

    public void set(int p, int d, int e, string buff = "")
    {
        playerID = p; damage = d; energy = e; this.buff = buff;

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
            if(playerID == 0 && enemy.GetComponent<Maglet>().playerID == 1)
            {
                
                int temp = energy;
                if(buff!="InfiniteEnergy")
                    energy -= enemy.GetComponent<Maglet>().energy;
                if(enemy.GetComponent<Maglet>().buff!= "InfiniteEnergy")
                    enemy.GetComponent<Maglet>().energy -= temp;
                if (enemy.GetComponent<Maglet>().energy <= 0)
                    Destroy(enemy);
                if (energy <= 0)
                    Destroy(gameObject);
            }
            return;
        }   
        else if (enemy.tag == "Stone")
        {
            Debug.Log("ML & S!");
            if (enemy.GetComponent<MoonStone>().playerID != playerID)
            {
                enemy.GetComponent<MoonStone>().hurt(damage);
                Destroy(gameObject);
            }
            return;
        }
            
    }
    
}
