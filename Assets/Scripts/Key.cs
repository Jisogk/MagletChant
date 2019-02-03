using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    // key pin
    public int color;
    public bool isChanted;
    public bool isCreating;
    private KeyBoard keyboard;

    // MFST skill
    public bool isFrozen;
    private GameObject Chain;

    void Start()
    {
        isChanted = false;
        isCreating = false;
        isFrozen = false;
        keyboard = GetComponentInParent<KeyBoard>();

        //MFST
        if(Global.charID1 == 0) // enemy, all 0 temorary
        {
            Chain = new GameObject();
            Chain.transform.position = transform.position;
            Chain.AddComponent<SpriteRenderer>().sprite = Sprites.KeyChain;
            Chain.GetComponent<SpriteRenderer>().sortingLayerName = "UI";
            Chain.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    private void OnMouseOver()
    {
        if (isChanted)
            return;

        if (!isFrozen && !keyboard.isChanting && Input.GetMouseButtonDown(0))
        {
            keyboard.isChanting = true;
            keyboard.witch.state = Witch.CHANGTING;
            isChanted = true;
            keyboard.word += keyboard.weight * color;
            keyboard.weight /= 10;
            GetComponent<SpriteRenderer>().sprite = Sprites.getKey1(color);
            transform.localScale = new Vector2(0.8f, 0.8f);
        }
        else if (!isFrozen && keyboard.isChanting && Input.GetMouseButton(0))
        {
            isChanted = true;
            keyboard.word += keyboard.weight * color;
            keyboard.weight /= 10;
            GetComponent<SpriteRenderer>().sprite = Sprites.getKey1(color);
            transform.localScale = new Vector2(0.8f, 0.8f);
        }
    }

    public void refresh()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        isCreating = true;
        // TOGO: refreshing animation
        StartCoroutine("waitAndRefresh");
    }


    IEnumerator waitAndRefresh()
    {
        yield return new WaitForSeconds(0.3f);
        float f = Random.Range(0f, 3f);
        if (f < 1)
            color = 1;
        else if (f < 2)
            color = 2;
        else
            color = 3;
        GetComponent<SpriteRenderer>().sprite = Sprites.getKey0(color);
        transform.localScale = new Vector2(1, 1);
        isCreating = false;
        isChanted = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    // MFST skill
    public void freeze()
    {
        if (!isFrozen)
        {
            isFrozen = true;
            // TODO: chain anima
            Chain.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine("waitAndThaw");
        }
        else
        {
            StopCoroutine("waitAndThaw");
            // TODO: chain anima
            Chain.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine("waitAndThaw");
        }

    }

    public void thaw()
    {
        Chain.GetComponent<SpriteRenderer>().enabled = false;
        isFrozen = false;
    }

    IEnumerator waitAndThaw()
    {
        yield return new WaitForSeconds(2);
        thaw();
    }


    /*

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))&& isChanting)
        {
            // random color
            color = Sprites.randomColor();
            GetComponent<SpriteRenderer>().sprite = Sprites.randomSprite(color);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            transform.localScale = new Vector3(1, 1, 1);
            StartCoroutine("waitAndNewKey");
            
        }
    }

    IEnumerator waitAndNewKey()
    {
        // TODO: Anime
        yield return new WaitForSeconds(0.25f);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        isChanting = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked();
        }
    }

    public void clicked()
    {
        // gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (!isChanting)
        {
            isChanting = true;
            // GetComponent<SpriteRenderer>().sprite = Sprites.chanting;
            transform.localScale = new Vector2(0.8f, 0.8f);
            chant.chanting.Add(new Rune(color, id, chant.runePos(), GetComponent<SpriteRenderer>().sprite));
        }
    }
    */
}
