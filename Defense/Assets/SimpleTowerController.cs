using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTowerController : MonoBehaviour {
    private GameObject target;
    private Animator animator;
    private Transform child;
    public GameObject tower;
	// Use this for initialization
	void Start () {
        animator = tower.GetComponent<Animator>();
        child = tower.GetComponentsInChildren<Transform>()[1];
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            child.LookAt(target.transform);
            child.transform.Rotate(-90, 0, 0);
            Shoot();
        }
        else
        {
            animator.SetBool("targeting", false);
        }

	}
    private void OnTriggerEnter(Collider other)
    {
        //타겟이 없고 들어온 타겟이 크리쳐일 경우
        if (target == null && other.tag == "Creature")
        {
            //타겟 지정
            target = other.gameObject;
            animator.SetBool("targeting", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //나간 오브젝트가 지정해놓은 타겟과 같은경우
        if(target==other.gameObject)
        {
            //타겟 해제
            target = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //타겟이 없을경우
        if(target==null&&other.tag=="Creature")
        {
            target = other.gameObject;
        }
    }
    private void Shoot()
    {
        Debug.Log("Shoot!!!!");
    }
}
