using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonStone : MonoBehaviour {
    public int playerID;
    public int HPMax;
    public int HP;
    public GameObject bar;
	// Use this for initialization
	void Start () {
        HPMax = 3000;
        HP = HPMax;
        bar.transform.localScale = new Vector2(4, 0.3f);
	}
	
    public void refresh()
    {
        float warning = 0.3f;
        if ((float)HP / HPMax < warning)
            bar.GetComponent<SpriteRenderer>().sprite = Sprites.BarR;
        else
            bar.GetComponent<SpriteRenderer>().sprite = Sprites.BarG;
        bar.transform.localScale = new Vector2((float)HP/HPMax * 4, 0.3f);
    }

    public void hurt(int damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            HP = 0;
            // TODO: GameOver
            Global.GameOver(1 - playerID);
        }
        refresh();
        
        // TODO: check win

    }

    public void multiply(float rate)
    {
        HP = (int)(HP * rate);
        if (HP > HPMax)
            HP = HPMax;
        else if (HP < 0)
        {
            HP = 0;
            // TODO: GameOver
        }
        
    }

    /*
	// Update is called once per frame
	void Update () {
		
	}
    */
}
