using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAI : Witch {

    // for testing
    bool isShooting = false;
    private void Update()
    {
        // for test
        // MFST freeze
        if (Input.GetKeyDown(KeyCode.L))
            createMaglet(1, 10, 1, Sprites.MagletPurple, 1, "MFSTFreeze");









        /* basic
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine("testShoot");
        }
        */


        if (state == NORMAL && Input.GetKeyDown(KeyCode.UpArrow) && row > 0)
        {
            target = row - 1;
            move();
        }
        else if (state == NORMAL && Input.GetKeyDown(KeyCode.DownArrow) && row < 2)
        {
            target = row + 1;
            move();
        }
    }

    IEnumerator testShoot()
    {
        yield return new WaitForSeconds(2);
        createMaglet(1, 10, 1, Sprites.MagletRed, 1);
        isShooting = false;
    }

}
