using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {
    //시작위치
    Vector3 startPosition;
    //변위
    public float amplitude;
    //속도
    public float speed;
	// Use this for initialization
	void Start () {
        //시작지점을 저장
        startPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        //시간에 따른 sin곡선대로 위치 변화
        float z = amplitude * Mathf.Sin(Time.time * speed);//시간을 기준으로 움직임 결정

        transform.localPosition = startPosition + new Vector3(0,0,z);
	}
}
