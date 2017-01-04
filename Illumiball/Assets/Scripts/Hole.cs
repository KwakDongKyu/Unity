using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    public string activeTag;
    private bool fall_in;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool IsFallIn()
    {
        return fall_in;
    }
    //안으로 들어올 때
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==activeTag)
        {
            fall_in = true;
        }
    }

    //밖으로 나갈 때
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag==activeTag)
        {
            fall_in = false;
        }
    }

    //충돌이 발생하면 메 프레임마다 실행
    void OnTriggerStay(Collider other)//other은 충돌한 객체
    {
        //충돌한 객체의 Rigibody 가져옴
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        //자신의 위치-충돌한 객체의 위치 = 방향
        Vector3 direction = transform.position - other.gameObject.transform.position;
        //방향 노말라이즈
        direction.Normalize();

        //테그가 같으면
        if(other.gameObject.tag==activeTag)
        {
            //빨아들일때 가속도 감속
            r.velocity *= 0.9f;
            //질량에 따른 힘을 방향으로 가함
            r.AddForce(direction * r.mass * 20.0f);
        }
        else
        {
            r.AddForce(-direction * r.mass * 80.0f);
        }
    }
}
