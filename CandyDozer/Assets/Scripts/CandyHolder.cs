using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour {

    private int candyAmount = 30;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ConsumeCandy()
    {
        if (candyAmount > 0)
            candyAmount--;
    }
    public int GetCandyAmount()
    {
        return candyAmount;
    }
    public void AddCandy()
    {
        candyAmount++;
    }
    
    private void OnGUI()
    {
        GUI.color = Color.black;
        string label = "Candy : " + candyAmount;
        GUI.Label(new Rect(0, 0, 400, 100),label);
    }
}
