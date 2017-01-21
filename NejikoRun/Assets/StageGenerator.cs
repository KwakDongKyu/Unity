using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {
    const int StageTipSize = 30;

    private int currentTipIndex;

    public Transform character;//대상 케릭터
    public GameObject[] stageTips;//스테이지의 프리펩 배열
    public int startTipIndex;//자동 생성 개시 인덱스
    public int preInstantiate;//미리 생성해서 읽어들일 스테이지 팁의 개수
    public List<GameObject> generatedStageList = new List<GameObject>();//생성된 스테이지 팁 리스트

	// Use this for initialization
	void Start () {
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
	}
	
	// Update is called once per frame
	void Update () {
        //캐릭터위치에서 현재 스테이지 팁의 인덱스를 구함
        int charaPositionIndex = (int)(character.position.z / StageTipSize);

        //다음의 스테이지 팁에 들어가면 스테이지의 업데이트
        if(charaPositionIndex+preInstantiate>currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
	}
    //지정한 곳까지 스테이지 팁을 생성
    private void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex)
            return;

        for(int i=currentTipIndex+1;i<=toTipIndex;i++)
        {
            GameObject stageObject = GenerateStage(i);

            //생성한 스테이지를 리스트에 추가
            generatedStageList.Add(stageObject);
        }
        while (generatedStageList.Count > preInstantiate + 2)
            DestroyOldestStage();

        currentTipIndex = toTipIndex;

    }
    //지정한 인덱스 위치에 스테이지 생성
    private GameObject GenerateStage(int tipIndex)
    {
        //프리펩 배열의 길이를 이용하여 인덱스를 랜덤하게
        int nextStageTip = Random.Range(0, stageTips.Length);
        //게임오브젝트 생성
        GameObject stageObject = (GameObject)Instantiate(stageTips[nextStageTip], new Vector3(0, 0, tipIndex * StageTipSize), Quaternion.identity);

        return stageObject;
    }
    //스테이지 삭제
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
