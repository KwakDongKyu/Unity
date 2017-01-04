using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

    Vector3 startPosition;

    public float amplitude;
    public float speed;
	// Use this for initialization
	void Start () {
        startPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        float z = amplitude * Mathf.Sin(Time.time * speed);//시간을 기준으로 움직임 결정

        transform.localPosition = startPosition + new Vector3(0,0,z);
	}
}
