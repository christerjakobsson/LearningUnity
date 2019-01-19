using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject[] Groups;
	public GameObject NextGroup;

    // Use this for initialization
    void Start() {
        SpawnNext(); 
    }

    public void SpawnNext() {
		var pos = GameObject.Find("NextBlock").transform.position;
		if (NextGroup == null) {
			var i = Random.Range (0, Groups.Length - 1);
			var g = Instantiate(Groups[i], transform.position, Quaternion.identity);
			i = Random.Range (0, Groups.Length-1);
			NextGroup = Instantiate(Groups [i], pos, Quaternion.identity);
			g.GetComponent<Group> ().isActive = true;

		} else {			
			var g = Instantiate(NextGroup, transform.position, Quaternion.identity);
			Destroy (NextGroup);
			NextGroup = null;

			var i = Random.Range (0, Groups.Length - 1);
			NextGroup = Instantiate(Groups [i], pos, Quaternion.identity);	
			g.GetComponent<Group> ().isActive = true;
		}	
    }

    // Update is called once per frame
    void Update() {

    }
}
