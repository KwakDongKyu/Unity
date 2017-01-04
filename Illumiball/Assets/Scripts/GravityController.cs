using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

    //중력가속도 상수
    const float Gravity = 9.81f;

    //중력가속도 배수
    public float GravityScale=1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //벡터객체 생성
        Vector3 vector = new Vector3();

        //에디터 실행
        if (Application.isEditor)
        {
            //수평,수직 입력값의 세기(-1~+1)를 가져옴
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            //z가 눌린상태일 경우
            if (Input.GetKey("z"))
            {
                vector.y = 1.0f;
            }
            //아닐경우
            else
            {
                vector.y = -1.0f;
            }
        }
        //기기 실행
        else
        {
            //가속도계의 좌표와 유니티의 좌표가 다름
            vector.x = Input.acceleration.x;
            vector.y = Input.acceleration.z;
            vector.z = Input.acceleration.y;
        }
        //중력가속도 상수를 벡터에 곱해줌 gravity는 Vector3 타입
        Physics.gravity = Gravity * vector.normalized * GravityScale;
	}
}
