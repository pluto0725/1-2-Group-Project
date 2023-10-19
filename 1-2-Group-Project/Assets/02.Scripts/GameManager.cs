using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int gold;

    // �̱��� �ν��Ͻ�
    public static GameManager Instance { get; private set; }

    // ��� ���� �̺�Ʈ
    public delegate void GoldChangedEventHandler(int newGoldValue);
    public event GoldChangedEventHandler OnGoldChanged;

    void Awake()
    {
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // �ʱ� ��� ����
        gold = 0;
    }

    // ��� ȹ�� �޼���
    public void EarnGold(int amount)
    {
        gold += amount;
        OnGoldChanged?.Invoke(gold);
    }

    // ��� �Ҹ� �޼���
    public void SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            OnGoldChanged?.Invoke(gold);
        }
        else
        {
            Debug.LogWarning("��尡 �����մϴ�!");
        }
    }

    // ���� ��� �� ��ȯ �޼���
    public int GetGold()
    {
        return gold;
    }
}
