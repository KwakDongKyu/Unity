using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallInChecker : MonoBehaviour {

    public Hole red;
    public Hole green;
    public Hole blue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        string label = "";

        if(red.IsFallIn()&&green.IsFallIn()&&blue.IsFallIn())
        {
            label = "Fall in hole!";
        }

        GUI.Label(new Rect(0, 0, 100, 30), label);
    }
}
