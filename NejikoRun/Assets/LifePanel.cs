using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour {
    public GameObject[] icons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateLife(int life)
    {
        //아이콘의 길이만큼 반복하면서
        for(int i=0;i<icons.Length;i++)
        {
            //i가 라이프보다 작으면 활성화
            if (i < life)
                icons[i].SetActive(true);
            //아니면 false
            else
                icons[i].SetActive(false);
        }
    }
}
