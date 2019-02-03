using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMFST : WitchPlayer
{
    public new void skill100() { createMaglet(1, 1, 1, Sprites.MagletRed, "MFSTFreeze"); }
    public new void skill200()
    {
        Maglet m = createMaglet(1, 1, 1, Sprites.MagletGreen).GetComponent<Maglet>();
        m.energy = (int)((float)m.energy * HPmax / HP);
    }
    public new void skill300() { /* fenshen */ }
    public new void skill110() {
        hurt((int)(HP * 0.05f));
        createShield((int)((HPmax - HP)*0.2f), Sprites.ShieldWhite);
    }
    public new void skill220() { enemy.GetComponent<Witch>().freeze(); }
    public new void skill330() { createMaglet(1, 1, 1, Sprites.MagletRed, "MagletWuxiannaijiu"); }
    public new void skill111() { /* dizzy */}
    public new void skill222() {
        hurt((int)(HP * 0.05f));
        moon0.GetComponent<MoonStone>().multiply(2);
        moon1.GetComponent<MoonStone>().multiply(2);
        moon2.GetComponent<MoonStone>().multiply(2);
    }
    public new void skill333() {
        hurt((int)(HP * 0.05f));
        // magelt
    }

}
