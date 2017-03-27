using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w,h];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Vector2 RoundVector2(Vector2 v) {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool InsideBorder(Vector2 pos) {
        return (int) pos.x >= 0 && (int) pos.x < w && (int) pos.y >= h;
    }
}
