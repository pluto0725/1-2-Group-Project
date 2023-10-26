
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int gold;
    private int stage = 1;

    public static GameManager Instance { get; private set; }

    public delegate void StageChangedEventHandler(int newStage);
    public event StageChangedEventHandler OnStageChanged;

    public delegate void GoldChangedEventHandler(int newGoldValue);
    public event GoldChangedEventHandler OnGoldChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gold = PlayerPrefs.GetInt("Gold", 0);
        stage = PlayerPrefs.GetInt("Stage", 1);
    }

    public void EarnGold(int amount)
    {
        gold += amount;
        OnGoldChanged?.Invoke(gold);
    }

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

    public int GetGold()
    {
        return gold;
    }

    public int GetStage()
    {
        return stage;
    }

    public void SetStage(int newStage)
    {
        stage = newStage;
        OnStageChanged?.Invoke(stage);
    }

    public void GameClear()
    {
        SetStage(GetStage() + 1);
        EarnGold(10000);

        PlayerPrefs.SetInt("Gold", GetGold());
        PlayerPrefs.SetInt("Stage", GetStage());
        PlayerPrefs.Save();

        SceneManager.LoadScene("Game");
    }
}
