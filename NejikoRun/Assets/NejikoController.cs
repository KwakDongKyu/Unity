
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour {
    //달릴 레인과 레인의 폭 설정
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    //캐릭터 컨트롤러와 애니메이터 객체
    private CharacterController controller;
    public Animator animator { get; private set; }
    //달릴 레인의 번호
    private int targetLane;
    //움직일 방향 벡터 기본값으로 제로벡터
    Vector3 moveDirection = Vector3.zero;

    //중력값,이동속도 점프 속도 설정
    public float gravity;
    public float speedZ;
    public float speedJump;
    public float speedX;//좌우 이동 속도
    public float accelerationZ;//전진 가속도

    //Hit처리를 위한 변수들
    const int DefaultLife = 3;
    public float StunDuration = 0.5f;
    private int life = DefaultLife;
    private float recoverTime = 0.0f;

    // Use this for initialization
    void Start () {
        //캐릭터컨트롤러와 애니메이터 객체 가져옴
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //디버그용 키보드 입력 처리
        if (Input.GetKeyDown("left"))
            MoveToLeft();
        if (Input.GetKeyDown("right"))
            MoveToRight();
        if (Input.GetKeyDown("space"))
            Jump();


        //땅에 붙어있을때만 실행
		if(!IsStun())
        {
            //z축으로 일정하게 가속도를 줌
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            //X축 방향이동속도는 목표까지 차등비율로 계산
            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;

            //수평입력값을 이용해 회전
            //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

            //점프 입력시
            //if (Input.GetButton("Jump"))
            //{
            //    Jump();
            //}
        }
        else
        {
            moveDirection.x = moveDirection.z = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        //아래 방향으로 중력값을 항상 적용(deltaTime을 이용하여 프레임간의 차이 보정)
        moveDirection.y -= gravity * Time.deltaTime;

        //moveDirection을 글로벌 좌표로 변환(캐릭터는 z로 움직이지만 글로벌좌표는 다르기 때문)
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        //컨트롤러를 이용해 움직이도록 함(deltaTime을 이용하여 프레임간 보정)
        controller.Move(globalDirection * Time.deltaTime);
        //이동후 땅에 닿을경우 y값 초기화
        if (controller.isGrounded)
            moveDirection.y = 0;
        //run과idle 조정
        animator.SetBool("run", moveDirection.z > 0.0f);
	}
    //왼쪽으로 이동
    public void MoveToLeft()
    {
        if (IsStun())
            return;
        if (controller.isGrounded && targetLane > MinLane)
            targetLane--;
    }
    public void MoveToRight()
    {
        if (IsStun())
            return;
        if (controller.isGrounded && targetLane < MaxLane)
            targetLane++;
    }
    public void Jump()
    {
        if (IsStun())
            return;
        if (controller.isGrounded)
        {
            //y에 값을 입력
            moveDirection.y = speedJump;
            //애니메이터의 jump트리거 설정
            animator.SetTrigger("jump");
        }
    }
    public int Life()
    {
        return life;
    }
    public bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStun())
            return;
        if (hit.gameObject.tag == "Robo")
        {
            life--;
            recoverTime = StunDuration;
            animator.SetTrigger("damage");
            Destroy(hit.gameObject);
        }
    }
}
