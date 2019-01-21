using System;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour {

    public static int w = 10;
    public static int h = 20;
    public static Transform[,] grid = new Transform[w,h];
    public static int Level;
    private static readonly int MaxLevel = 10;
    public static int Score { get; set; }


    // Use this for initialization
    void Start () {
  
    }

    public static Vector2 RoundVector2(Vector2 v) {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool InsideBorder(Vector2 pos) {
        return  (int) pos.x >= 0 && 
				(int) pos.x < w && 
				(int) pos.y >= 0;
    }

	public static void DeleteRow(int y) {
		for (int x = 0; x < w; ++x) {
			Destroy (grid [x, y].gameObject);
			grid [x, y] = null;
		}
	}

	public static void DecreaseRow(int y) {
		for (int x = 0; x < w; ++x) {
			if (grid [x, y] != null) {
				grid [x, y - 1] = grid [x, y];
				grid [x, y] = null;

				grid [x, y - 1].position += new Vector3 (0, -1, 0); 
			}
		}
	}

	public static void DecreaseRowsAbove(int y) {
		for (int i = y; i < h; ++i) {
			DecreaseRow (i);
		}
	}

	public static bool IsRowFull(int y) {
		for (int x = 0; x < w; ++x) {
			if (grid [x, y] == null)
				return false;
		}

		return true;
	}

	public static int DeleteFullRows() {
        int count = 0;
		for (int y = 0; y < h; ++y) {
			if(IsRowFull(y)) {
                count++;
				DeleteRow (y);
				DecreaseRowsAbove(y + 1);
				--y;
			}
		}
        if(count > 0) {
            CalculateScore(count);
        }

        return count;
    }

    private static void CalculateScore(int count) {
        if (count <= 0)
            return;
            //  40 * (n + 1)    100 * (n + 1)   300 * (n + 1)   1200 * (n + 1)
        var point = 40;
        switch(count) {
            case 1:
                point = 40;
                break;
            case 2:
                point = 100;
                break;
            case 3:
                point = 300;
                break;
            case 4:
                point = 1200;
                break;
        }
        var sum = point * (Level + 1);
        Score += point * (Level + 1);

    }

    internal static bool IsMaxLevel() {
        return Level == MaxLevel;
    }
}