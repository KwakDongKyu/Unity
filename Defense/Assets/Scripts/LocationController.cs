using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour {
    private MoveToLocationList locationList;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //로케이션리스트 스크립트를 가져옴
        locationList = other.gameObject.GetComponent<MoveToLocationList>();
        locationList.Next();
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
