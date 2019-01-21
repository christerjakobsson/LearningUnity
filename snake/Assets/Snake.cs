using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    List<Transform> tail = new List<Transform>();
    Vector2 dir = Vector2.right;
    bool ate = false;
    public GameObject tailPrefab;

    void Move() {
        // Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(dir);

        if(ate) {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            tail.Insert(0, g.transform);
            ate = false;
        } else if (tail.Count > 0) {
            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        // Food?
        if (coll.name.StartsWith("FoodPrefab", System.StringComparison.Ordinal)) { //TODO change to tag
            // Get longer in next Move call
            ate = true;

            // Remove the Food
            Destroy(coll.gameObject);
        }
        // Collided with Tail or Border
        else {
            // ToDo 'You lose' screen
            Debug.Log("GAME OVER");
            Application.Quit();

        }
    }


    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = Vector2.left;
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = Vector2.down;
    }
}
