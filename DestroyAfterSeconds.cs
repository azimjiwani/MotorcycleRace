using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

	public float seconds = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		seconds -= Time.deltaTime;
		if (seconds <= 0f) {
			Destroy (this.gameObject);
		}
	}
}
