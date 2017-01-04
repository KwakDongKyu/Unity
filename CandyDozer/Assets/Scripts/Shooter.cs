﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    //프리펩 배열
    public GameObject[] candyPrefab;
    public GameObject[] candySquarePrefab;
    //날아가는 속도와 토크
    public float shotSpeed;
    public float shotTorque;
    //원형캔디 확률
    public int SphereCandyProbability;
    //게임상 길이
    public float baseWidth;
    //부모객체
    public GameObject candyHolder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
            Shot();	
	}
    private void Shot()
    {
        GameObject candy = SampleCandy();
        if (candy != null)
        {
            candy.transform.parent = candyHolder.transform;
            //캔디의 Rigibody를 가져옴
            Rigidbody candyRigibody = candy.GetComponent<Rigidbody>();
            //Rigibody에 힘과 토크를 줌
            candyRigibody.AddForce(transform.forward * shotSpeed);
            candyRigibody.AddTorque(new Vector3(0, shotTorque, 0));
        }
    }
    //랜덤한 캔디를 반환해줌
    private GameObject SampleCandy()
    {
        GameObject prefab = null;

        if (Random.Range(0, 100) <= SphereCandyProbability)//0~99중 원형캔디확률보다 작은수가 나올때
        {
            //랜덤한 인덱스를 골라
            int index = Random.Range(0, candyPrefab.Length);
            //동적으로 생성
            prefab = (GameObject)Instantiate(candyPrefab[index], GetInstantiatePosition(), Quaternion.identity);
        }
        else
        {
            int index = Random.Range(0, candySquarePrefab.Length);
            prefab = (GameObject)Instantiate(candySquarePrefab[index], GetInstantiatePosition(), Quaternion.identity);
        }
        return prefab;
    }
    private Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }
}