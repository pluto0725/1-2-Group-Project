using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stage : MonoBehaviour
{
    public class StageChangedEvent : UnityEvent<int> { }

    public static StageChangedEvent OnStageChanged = new StageChangedEvent();

    public GameObject Stage1; // �������� 1���� Ȱ��ȭ�� ������Ʈ
    public GameObject Stage1Monster;
    public GameObject Stage2; // �������� 2���� Ȱ��ȭ�� ������Ʈ
    public GameObject Stage2Monster;

    void Start()
    {
        ChangeStage(GameManager.Instance.GetStage());
        OnStageChanged.Invoke(GameManager.Instance.GetStage());

        // ���������� ���� ��带 �����ϴ� �ڷ�ƾ ����
        StartCoroutine(GenerateGold());
    }

    // ... (���� �ڵ�� ����)

    IEnumerator GenerateGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            int goldToAdd = 0;
            switch (GameManager.Instance.GetStage())
            {
                case 1:
                    goldToAdd = 50;
                    break;
                case 2:
                    goldToAdd = 100;
                    break;
                case 3:
                    goldToAdd = 150;
                    break;
                default:
                    goldToAdd = 0;
                    break;
            }

            // ������ ��带 GameManager�� ����
            GameManager.Instance.EarnGold(goldToAdd);
            int currentGold = GameManager.Instance.GetGold();
            Debug.Log("���� ���: " + currentGold);
        }
    }

    // �������� ���� �� ȣ��Ǵ� �޼���
    public void ChangeStage(int newStage)
    {
        OnStageChanged.Invoke(newStage);

        // ���������� ���� ������Ʈ Ȱ��ȭ/��Ȱ��ȭ ó��
        Stage1.SetActive(newStage == 1);
        Stage1Monster.SetActive(newStage == 1);
        Stage2.SetActive(newStage == 2);
        Stage2Monster.SetActive(newStage == 2);
        // �������� 3�� �߰��� ��� ���⿡ �ʿ��� ó���� �߰��ϸ� �˴ϴ�.
    }
}
