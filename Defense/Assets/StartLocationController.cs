using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLocationController : MonoBehaviour {

    private bool onFlag { get; set; }
    private GameObject currentCreatue;
    public List<GameObject> creatureList;
    public GameController controller;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            onFlag = true;
        }
        if(onFlag)
        {
            Debug.Log("StartCoroutine");
            StartCoroutine(Create());
            onFlag = false;
        }
	}
    private IEnumerator Create()
    {
        int counter = controller.count;

        //생성할 크리쳐 결정
        SampleCreature();
        //카운터가 0이상인 동안
        while(counter>0)
        {
            //timeInterval마다 아래 실행
            yield return new WaitForSeconds(controller.timeInterval);
            counter--;
            //creature 생성
            CreateCreature();
        }
    }
    private void CreateCreature()
    {
        GameObject creature = (GameObject)Instantiate(currentCreatue, this.transform.position, Quaternion.identity);
    }
    
    //creature 생성
    private void SampleCreature()
    {
        currentCreatue = creatureList[0];
    }
    
}
