using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maglet: MonoBehaviour{
    
    // Maglet tpye

    public int player;
    public int damage;
    public int energy;
    public string buff;

    public void set(int p, int d, int e, string buff = "")
    {
        player = p; damage = d; energy = e; this.buff = buff;

    }

    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject enemy = collider.gameObject;
        if (enemy.tag == "Witch")
        {
            Debug.Log("ML & W");
            if (enemy.GetComponent<Witch>().player != player)
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
            if(player == 0 && enemy.GetComponent<Maglet>().player == 1)
            {
                
                int temp = energy;
                if(buff!="MagletWuxiannaijiu")
                    energy -= enemy.GetComponent<Maglet>().energy;
                if(enemy.GetComponent<Maglet>().buff!= "MagletWuxiannaijiu")
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
            if (enemy.GetComponent<MoonStone>().player != player)
            {
                enemy.GetComponent<MoonStone>().hurt(damage);
                Destroy(gameObject);
            }
            return;
        }
            
    }
    
}
