using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Witch : MonoBehaviour {

    public int id;

    // state machine
    public int state;
    public static int NORMAL = 0;
    // public static int CHANGTING = 1;
    public static int CASTING = 2;
    public static int MOVING = 3;
    public static int DIZZY = 4;

	public int row;
    public int target; // for move

	public int face;
    public int HPmax;
	public int HP;

	public Sprite spriteNormal;
	public Sprite spriteUp;
	public Sprite spriteDown;
	public Sprite spriteChant;
	
    // for dazhao
    // public int red;
    // public int green;
    // public int blue;

    public Shield shield;
    public GameObject enemy;
    private KeyBoard keyboard;

    public GameObject moon0, moon1, moon2;
    public GameObject HPBar;

    private float yInput;

    private void Start()
    {
        HPmax = 3000;
        HP = HPmax;
        transform.localScale = new Vector2(face * 1.8f, 1.8f);
        shield = GetComponentInChildren<Shield>();
        keyboard = GetComponentInParent<Transform>().gameObject.GetComponentInChildren<KeyBoard>();
    }

    private void FixedUpdate()
    {
        updateMove();
    }

    public void relocate() // very useful
    {
        transform.position = new Vector2(transform.position.x, Global.getY(row));
        GetComponent<SpriteRenderer>().sprite = spriteNormal;
        state = NORMAL;
    }

    // logic:
    // can always chant
    // when move, cannot cast
    // when cast,cannot move


    // if chanting then forbid moving
    public void chant(int word)
    {
        // already judge whether NORMAL in Class.Keyboard
        state = CASTING;
        Debug.Log("Cast!");
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
            default: break; //TODO: fangpi
        }
        StartCoroutine("changeSpriteChant");
    }

    IEnumerator changeSpriteChant()
    {
        GetComponent<SpriteRenderer>().sprite = spriteChant;
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().sprite = spriteNormal;
        state = NORMAL;
    }

	// up and down
	public void move()
	{
		if(state != NORMAL)
        {
            target = row;
            return;
        }
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
        // TODO: 硬直
        // TODO: hurt anima
        if (shield.value >= value)
            shield.value -= value;
        else
        {
            HP -= (value - shield.value);
            shield.value = 0;
            if (HP < 0)
            {
                HP = 0;
                // TODO: Gameover
                Global.GameOver(1 - id);
            }
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
        HPBar.transform.localScale = new Vector2((float)HP / HPmax * 11.5f * face, 1.5f);
    }

    public GameObject createMaglet(int spd, int damage, int energy, Sprite sprite, float scale, string buff = "")
    {
        GameObject maglet = new GameObject();
        maglet.tag = "Maglet";
        maglet.transform.position = new Vector2(transform.position.x + 2 * face, Global.getY(row) + 1f);
        maglet.transform.localScale = new Vector3(face * scale, scale, scale);
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

    public void skill100() { createMaglet(1, 100, 1, Sprites.MagletRed, 1); }
    public void skill200() { createMaglet(1, 100, 1, Sprites.MagletGreen, 1); }
    public void skill300() { createMaglet(1, 100, 1, Sprites.MagletBlue, 1); }
    public void skill110() { createMaglet(1, 225, 2, Sprites.MagletRed, 1.25f); }
    public void skill220() { createMaglet(1, 225, 2, Sprites.MagletGreen, 1.25f); }
    public void skill330() { createMaglet(1, 225, 2, Sprites.MagletBlue, 1.25f); }
    public void skill111() { createMaglet(1, 500, 3, Sprites.MagletRed, 1.5f); }
    public void skill222() { createMaglet(1, 500, 3, Sprites.MagletGreen, 1.5f); }
    public void skill333() { createMaglet(1, 500, 3, Sprites.MagletBlue, 1.5f); }

    public void freeze()
    {
        keyboard.Key2.GetComponent<Key>().freeze();
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

    void updateMove()
    {
        if (state != NORMAL)
            return;

        yInput = id == 0 ? Input.GetAxis("Vertical 1") : Input.GetAxis("Vertical 2");
        if (yInput > 0.1f && state == NORMAL && row > 0)
        {
            target = row - 1;
            move();
        }
        else if (yInput < -0.1f && state == NORMAL && row < 2)
        {
            target = row + 1;
            move();
        }
    }



    public void getBuff(string buff)
    {
        // TODO: a lot
        switch (buff)
        {
            case "": return;
            case "MFSTFreeze": Debug.Log("Freeze!"); freeze(); break;
            case "Dizzy": Debug.Log("Dizzy!"); dizzy(); break;

            default: break;






        }

    }



}
