using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchPlayer : Witch {
    // private GameObject ChargeG;
    // private GameObject ChargeR;
    // private GameObject ChargeB;
    // private GameObject HPUI;

    void Update()
    {
        updateUsual();
    }

    protected void Start()
    {
        HP = 50; HPmax = 50;
        // HPUI = GameObject.Find("HP");
        // red = 0; ChargeR = GameObject.Find("ChargeR");
        // green = 0; ChargeG = GameObject.Find("ChargeG");
        // blue = 0; ChargeB = GameObject.Find("ChargeB");
        transform.localScale = new Vector2(face * 1.8f, 1.8f);
        // gameObject.GetComponent<PolygonCollider2D>().isTrigger = true; // will disable ground
        shield = shieldObject.GetComponent<Shield>();
    }

    void updateMove()
    {
        // if (isFrozen)
        //    return;
        if (state == NORMAL && Input.GetKeyDown(KeyCode.W) && row > 0)
        {
            target = row - 1;
            move();
        }
        else if(state == NORMAL && Input.GetKeyDown(KeyCode.S) && row < 2)
        {
            target = row + 1;
            move();
        }
    }

    /*
    void updateUI()
    {
        HPUI.transform.localScale = new Vector3((float)HP / HPmax * 7.9f, 0.8f, 1f);
        HPUI.transform.position = new Vector2((float)HP / HPmax * 2.54f - 0.76f, -2.965f);

        ChargeR.transform.localScale = new Vector3(red / 100f * 7.9f, 0.8f, 1f);
        ChargeR.transform.position = new Vector3(red / 50f * 1.27f - 0.76f, -4.36f, 0.1f);

        ChargeG.transform.localScale = new Vector3(green / 100f * 7.9f, 0.8f, 1f);
        ChargeG.transform.position = new Vector2(green / 50f * 1.27f - 0.76f + 0.64f * red / 100f * 7.9f, -4.36f);

        ChargeB.transform.localScale = new Vector3(blue / 100f * 7.9f, 0.8f, 1f);
        ChargeB.transform.position = new Vector2(blue / 50f * 1.27f - 0.76f + 0.64f * (red + green) / 100f * 7.9f, -4.36f);
    }
    */



    protected void updateUsual()
    {
        updateMove();
        // updateUI();
        HP = HP < 0 ? 0 : HP;
        if (HP <= 0)
        { // game over

        }
    }

    public void chant(int word)
    {
        state = CHANGTING;
        Debug.Log("Maglet!");
        switch (word)
        {
            case 100: skill100(); break;
            case 200: skill200(); break;
            case 300: skill300(); break;
            case 110: skill110(); break;
            case 220: skill220(); break;
            case 330: skill330(); break;
            case 111: skill111(); break;
            case 222: skill222(); break;
            case 333: skill333(); break;
            default: createMaglet(1, 1, 1, Sprites.MagletRed); break;
        }
        StartCoroutine("changeSpriteChant");
    }

}
