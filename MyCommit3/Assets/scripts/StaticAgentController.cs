using UnityEngine;
using System.Collections;

public class StaticAgentController : MonoBehaviour {

	public int myID;

	// Use this for initialization
	void Start () {
		myID = Camera.main.GetComponent<SpawnAgent>().staticCounter;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public int getID() {
		return myID;
	}
}
