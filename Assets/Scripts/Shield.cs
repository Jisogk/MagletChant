using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public int value = 0;
    private Witch witch;
    private void Start()
    {
        witch = GetComponentInParent<Witch>();
        transform.localScale = new Vector2(witch.face * 0.8f, 0.8f);
    }

    private void Update()
    {
        if (value <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }
        transform.position = witch.gameObject.transform.position + new Vector3(0.32f * witch.face, 0.64f, 0f);
        // transform.localScale = witch.gameObject.transform.localScale;
    }


    /*
    public void getShield21(int value) // shield, spdDown
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites.shieldBrown;
        this.value += value;
        StartCoroutine("spdDown");
    }

    public void getShield23(int value)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites.shieldYellow;
        this.value += value;
        StartCoroutine("removeDizzy");
    }

    public void getShield222(int value)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites.shieldGray;
        this.value += value;
    }

    IEnumerator spdDown()
    {
        witch.spd *= 0.6f;
        yield return new WaitForSeconds(2);
        witch.spd /= 0.6f;
    }

    IEnumerator removeDizzy()
    {
        yield return new WaitForSeconds(1);
        //TODO: effect
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites.shieldWhite;
    }
    */
}
