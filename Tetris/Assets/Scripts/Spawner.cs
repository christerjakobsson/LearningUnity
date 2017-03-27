using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Groups;

    // Use this for initialization
    void Start() {
        SpawnNext();
    }

    private void SpawnNext() {
        int i = Random.Range(0, Groups.Length);
        Instantiate(Groups[i], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {

    }
}
