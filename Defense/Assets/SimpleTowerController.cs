using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTowerController : MonoBehaviour {
    private GameObject target;
    private Animator animator;
    private TowerInformation info;
    
	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        info = GetComponent<TowerInformation>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
        else
        {
            animator.SetBool("target", false);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        //타겟이 없고 들어온 타겟이 크리쳐일 경우
        if (target == null && other.tag == "Creature")
        {
            //타겟 지정
            target = other.gameObject;
            animator.SetBool("target", true);
            StartCoroutine(Shoot());
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
            StartCoroutine(Shoot());
        }
    }
    private IEnumerator Shoot()
    {
        GameObject originTarget = target;
        int deb = 0;
        while(originTarget==target)
        {
            animator.SetTrigger("shoot");

            Debug.Log("Shoot!!" + (++deb).ToString());

            yield return new WaitForSeconds(1 / info.attackPerSec);
        }
    }
}
