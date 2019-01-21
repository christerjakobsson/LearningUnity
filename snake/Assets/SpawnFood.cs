using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    public GameObject foodPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;


    void Spawn() {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        // y position between top and bottom border
        int y = (int)Random.Range(borderTop.position.y, borderBottom.position.y);

        // Instantiate the food at x, y
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start() {
        // Spawn food every 4 seconds starting from 3.
        InvokeRepeating("Spawn", 3, 4);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
