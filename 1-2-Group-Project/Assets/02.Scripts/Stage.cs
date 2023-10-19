using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stage : MonoBehaviour
{
    public class StageChangedEvent : UnityEvent<int> { }

    public int stage = 1; // 스테이지 값을 Inspector에서 설정할 수 있도록 public 변수로 선언
    public static StageChangedEvent OnStageChanged = new StageChangedEvent();

    public GameObject Stage1; // 스테이지 1에서 활성화할 오브젝트
    public GameObject Stage1Monster;
    public GameObject Stage2; // 스테이지 2에서 활성화할 오브젝트
    public GameObject Stage2Monster;

    void Start()
    {
        ChangeStage(stage);
        OnStageChanged.Invoke(stage);

        // 스테이지에 따라 골드를 생성하는 코루틴 실행
        StartCoroutine(GenerateGold());

    
    }

    IEnumerator GenerateGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            int goldToAdd = 0;
            switch (stage)
            {
                case 1:
                    goldToAdd = 50;
                    break;
                case 2:
                    goldToAdd = 100;
                    break;
                // 스테이지 3에서 150골드 생성
                case 3:
                    goldToAdd = 150;
                    break;
                default:
                    goldToAdd = 0;
                    break;
            }

            // 생성된 골드를 GameManager로 전달
            GameManager.Instance.EarnGold(goldToAdd);
            int currentGold = GameManager.Instance.GetGold();
            Debug.Log("현재 골드: " + currentGold);
        }
    }

    // 스테이지 변경 시 호출되는 메서드
    public void ChangeStage(int newStage)
    {
        stage = newStage;
        OnStageChanged.Invoke(stage);

        // 스테이지에 따라 오브젝트 활성화/비활성화 처리
        Stage1.SetActive(stage == 1);
        Stage1Monster.SetActive(stage == 1);
        Stage2.SetActive(stage == 2);
        Stage2Monster.SetActive(stage == 2);
        // 스테이지 3을 추가할 경우 여기에 필요한 처리를 추가하면 됩니다.
    }
}
