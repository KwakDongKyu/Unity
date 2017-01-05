using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour {

    private int point = 0;
    public GameObject effectPrefab;
    public Vector3 effectRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Candy")
        {
            Destroy(other.gameObject);
            point++;

            if(effectPrefab!=null)
            {
                Instantiate(effectPrefab, other.transform.position, Quaternion.Euler(effectRotation));
            }
        }
    }
    void OnGUI()
    {
        string label = "POINT : " + point;
        GUI.color = Color.black;
        GUI.Label(new Rect(500, 0, 800, 100), label);
    }
}
