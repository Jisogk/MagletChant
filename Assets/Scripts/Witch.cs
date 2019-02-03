using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Witch : MonoBehaviour {

    public int player;
    // state machine
    public int state;
    public static int NORMAL = 0;
    public static int CHANGTING = 1;
    public static int MOVING = 2;
    public static int DIZZY = 3;

	public int row;
    public int target; // for move

	public int face;
    public int HPmax;
	public int HP;

	public Sprite spriteNormal;
	public Sprite spriteUp;
	public Sprite spriteDown;
	public Sprite spriteChant;
	
    // public int red;
    // public int green;
    // public int blue;

    public GameObject shieldObject;
    public Shield shield;
    public GameObject enemy;
    public GameObject keyboard;

    public GameObject moon0, moon1, moon2;
    public GameObject HPBar;

    private void Start()
    {
        HP = 50; HPmax = 50;
        transform.localScale = new Vector2(face * 1.8f, 1.8f);
        shield = shieldObject.GetComponent<Shield>();
    }

    public void relocate() // very useful
    {
        transform.position = new Vector2(transform.position.x, Global.getY(row));
        GetComponent<SpriteRenderer>().sprite = spriteNormal;
        state = NORMAL;
    }

    // if chanting then forbid moving
    public void chant(int word)
    {
        relocate();
        state = CHANGTING;
        StartCoroutine("changeSpriteChant");
    }

    IEnumerator changeSpriteChant()
    {
        GetComponent<SpriteRenderer>().sprite = spriteChant;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = spriteNormal;
        state = NORMAL;
    }

	// up and down
	public void move()
	{
		if(state != NORMAL)
			return;
        state = MOVING;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * (Global.getY(target) - Global.getY(row)) / 0.2f;
        StartCoroutine("changeSpriteMove");
    }

    IEnumerator changeSpriteMove()
    {
        GetComponent<SpriteRenderer>().sprite = spriteUp;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().sprite = spriteDown;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        row = target;
        relocate();
    }

    public void hurt(int value)
    {
        // relocate if YingZhi
        // TODO: hurt anima
        if (shield.value >= value)
            shield.value -= value;
        else
        {
            HP -= (value - shield.value);
            shield.value = 0;
        }
        refreshHPBar();
    }

    public void cure(int value)
    {   
        // TODO: cure anima
        HP += value;
        if (HP > HPmax)
            HP = HPmax;
        refreshHPBar();
    }

    public void refreshHPBar()
    {
        float warning = 0.3f;
        if ((float)HP / HPmax < warning)
            HPBar.GetComponent<SpriteRenderer>().sprite = Sprites.BarR;
        else
            HPBar.GetComponent<SpriteRenderer>().sprite = Sprites.BarG;
        HPBar.transform.localScale = new Vector2(-(float)HP / HPmax * 11.5f * face, 1.5f);
    }

    public GameObject createMaglet(int spd, int damage, int energy, Sprite sprite, string buff = "")
    {
        GameObject maglet = new GameObject();
        maglet.tag = "Maglet";
        maglet.transform.position = new Vector2(transform.position.x + 2 * face, Global.getY(row) + 1f);
        maglet.transform.localScale = new Vector3(face, 1, 1);
        maglet.AddComponent<Maglet>().set((1 - face) / 2, damage, energy, buff);
        maglet.AddComponent<SpriteRenderer>().sprite = sprite;


        maglet.AddComponent<PolygonCollider2D>().isTrigger = true;

        Rigidbody2D rigid = maglet.AddComponent<Rigidbody2D>();
        rigid.gravityScale = 0;
        rigid.velocity = new Vector2(spd * face * 2f, 0);
        rigid.drag = 0; rigid.angularDrag = 0;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;

        return maglet;
    }

    public void createShield(int value, Sprite sprite)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        shield.value += value;
    }

    public void skill100() { createMaglet(1, 1, 1, Sprites.MagletRed); }
    public void skill200() { createMaglet(1, 1, 1, Sprites.MagletGreen); }
    public void skill300() { createMaglet(1, 1, 1, Sprites.MagletBlue); }
    public void skill110() { }
    public void skill220() { }
    public void skill330() { }
    public void skill111() { }
    public void skill222() { }
    public void skill333() { }

    public void freeze()
    {
        keyboard.GetComponent<KeyBoard>().Key2.GetComponent<Key>().freeze();
    }

    public void dizzy()
    {
        relocate();
        state = DIZZY;
        StartCoroutine("changeSpriteDizzy");
    }


    IEnumerator changeSpriteDizzy()
    {
        // TODO: dizzy anima
        yield return new WaitForSeconds(0.5f);
        state = NORMAL;
    }

    public void getBuff(string buff)
    {
        switch (buff)
        {
            case "": return;
            case "MFSTFreeze": Debug.Log("Freeze!"); freeze(); break;
            case "Dizzy": Debug.Log("Dizzy!"); dizzy(); break;

            default: break;






        }

    }



}
