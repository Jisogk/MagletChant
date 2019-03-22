using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Global : MonoBehaviour {
	public static float y0, y1, y2;
    public static int charID0;
    public static int charID1;

	
	// Use this for initialization
	void Start () {
		y0 = GameObject.Find("Row0").transform.position.y;
		y1 = GameObject.Find("Row1").transform.position.y;
		y2 = GameObject.Find("Row2").transform.position.y;

        charID0 = 0;
        charID1 = 0;
	}

    public static float getY(int row)
    {
        if (row == 2) return y2;
        if (row == 1) return y1;
        return y0;
    }

    public static void GameOver(int winner)
    {
        Time.timeScale = 0f;
        EditorUtility.DisplayDialog("Game Over", (winner == 0 ? "P1" : "P2") + " wins", "确认", "取消");
    }


	/*
	// Update is called once per frame
	void Update () {
		
	}
	*/
}
