using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour {

    private int candyAmount = 30;
    public int defaultCandyAmount = 30;
    const int recoverySeconds = 10;
    private int counter = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetCandyAmount() < defaultCandyAmount&&counter<=0)
        {
            StartCoroutine(RecoverCandy());
        }
		
	}
    IEnumerator RecoverCandy()
    {
        counter = recoverySeconds;

        while (counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }
        candyAmount++;
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
        if (counter > 0)
        {
            label += "(" + counter + ")";
        }
        GUI.Label(new Rect(0, 0, 400, 100),label);
    }
}
