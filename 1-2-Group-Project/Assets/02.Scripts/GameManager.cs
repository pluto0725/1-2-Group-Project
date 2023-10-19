using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int gold;

    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    // 골드 변경 이벤트
    public delegate void GoldChangedEventHandler(int newGoldValue);
    public event GoldChangedEventHandler OnGoldChanged;

    void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // 초기 골드 설정
        gold = 0;
    }

    // 골드 획득 메서드
    public void EarnGold(int amount)
    {
        gold += amount;
        OnGoldChanged?.Invoke(gold);
    }

    // 골드 소모 메서드
    public void SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            OnGoldChanged?.Invoke(gold);
        }
        else
        {
            Debug.LogWarning("골드가 부족합니다!");
        }
    }

    // 현재 골드 양 반환 메서드
    public int GetGold()
    {
        return gold;
    }
}
