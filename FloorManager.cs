using UnityEngine;
using System.Collections;

public class FloorManager : MonoBehaviour {

	public GameObject[] floors;
	public Player player;
	public float floorSize;

	public float playerOffset = 18f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject floor in floors) {
			if (floor.transform.position.z < player.transform.position.z - playerOffset) {
				floor.transform.position = new Vector3 (
					floor.transform.position.x,
					floor.transform.position.y,
					floor.transform.position.z + floorSize * floors.Length
				);
			}
		}
	}
}
