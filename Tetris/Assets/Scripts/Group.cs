using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

	// Time since last gravity tick
	float lastFall = 0;

	// Use this for initialization
	void Start () {
		if (!IsValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {	
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-1, 0, 0);

			if (IsValidGridPos ())
				UpdateGrid ();
			else
				transform.position += new Vector3 (1, 0, 0);

		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1, 0, 0);

			if (IsValidGridPos ())
				UpdateGrid ();
			else
				transform.position += new Vector3 (-1, 0, 0);
			
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.Rotate (0, 0, -90);


			if (IsValidGridPos ())
				UpdateGrid ();
			else
				transform.Rotate (0, 0, 90);
		} else if (Input.GetKeyDown(KeyCode.DownArrow) ||
			Time.time - lastFall >= 1) {
			// Modify position
			transform.position += new Vector3(0, -1, 0);

			// See if valid
			if (IsValidGridPos()) {
				// It's valid. Update grid.
				UpdateGrid();
			} else {
				// It's not valid. revert.
				transform.position += new Vector3(0, 1, 0);

				// Clear filled horizontal lines
				Grid.deleteFullRows();

				// Spawn next Group
				FindObjectOfType<Spawner>().SpawnNext();

				// Disable script
				enabled = false;
			}

			lastFall = Time.time;
		}
	}

	bool IsValidGridPos() {
		foreach (Transform child in transform) {
			Vector2 v = Grid.RoundVector2 (child.position);

			if (!Grid.InsideBorder (v)) {
				return false;
			}

			if (Grid.grid [(int)v.x, (int)v.y] != null &&
				Grid.grid [(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void UpdateGrid() {
		for (int y = 0; y < Grid.h; ++y) 
			for (int x = 0; x < Grid.w; ++x)
				if (Grid.grid[x, y] != null)
				if (Grid.grid [x, y].parent == transform)
					Grid.grid [x, y] = null;
			

		foreach(Transform child in transform) {
			Vector2 v = Grid.RoundVector2 (child.position);
			Grid.grid [(int)v.x, (int)v.y] = child;
		}
	}
}
