using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private bool constructMode = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit,0.1f))
        {
            if(hit.transform.gameObject==gameObject)
            {
                Debug.Log(hit.transform);
            }
        }
    }
    public void ChangeConstructMode()
    {
        if(constructMode)
        {
            constructMode = false;
        }
        else
        {
            constructMode = true;
        }
    }

}
