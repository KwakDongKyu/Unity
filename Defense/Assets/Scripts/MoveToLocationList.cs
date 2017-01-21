using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 
public class MoveToLocationList : MonoBehaviour {

    private Information info;
    private Rigidbody rigid;
    
    private int targetIdx = 0;

    public List<GameObject> location;
    private GameController controller;
    // Use this for initialization
    void Start () {
        info = GetComponent<Information>();
        controller = GameObject.Find("GameController").GetComponent<GameController>();

        location = new List<GameObject>(4);
        SetLocation();
        //처음 목표 방향으로 회전
        this.transform.LookAt(location[targetIdx].transform);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //앞으로 이동
        this.transform.Translate(Vector3.forward * info.speed * Time.deltaTime);
    }
    //다음 목적지로 이동
    public void Next()
    {
        //현재 인덱스가 리스트 전체 수보다 작을 때
        if (targetIdx<location.Count-1)
        {
            targetIdx++;
        }
        this.transform.LookAt(location[targetIdx].transform);
    }
    private void SetLocation()
    {
        for (int i = 0; i < controller.locationList.Count; i++)
            location.Add(controller.locationList[i]);
    }
}
