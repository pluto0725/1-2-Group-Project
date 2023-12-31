using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Testbar : MonoBehaviour
{
    public Slider healthSlider; // HP 바를 연결할 슬라이더 UI 요소
    public Text timerText; // 타이머 텍스트 UI 요소 추가
    public int maxHealth = 20000;
    private int currentHealth;
    private float timer = 60.0f; // 60초 타이머

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    private void Update()
    {
        // 타이머 업데이트
        if (timer > 0)
        {
            timer -= Time.deltaTime; // 시간을 감소시킴
            UpdateTimerText();
        }
        else
        {
            // 타이머가 0보다 작거나 같으면 게임 오버 또는 다른 처리를 추가할 수 있습니다.
            // 예: GameOver() 메소드 호출 또는 다른 처리 추가
            LoadGameScene(); // 60초가 지나면 Game 씬으로 이동
        }

        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 시 체력 감소
            TakeDamage(1000);
        }
    }

    void UpdateTimerText()
    {
        // 타이머 텍스트 업데이트
        int seconds = Mathf.CeilToInt(timer);
        timerText.text = seconds.ToString() + "s";
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // 여기에 게임 오버 또는 다른 처리를 추가할 수 있습니다.
            // 예: GameOver() 메소드 호출 또는 다른 처리 추가
            GameManager.Instance.GameClear(); // 게임 오버 시 Game 씬으로 이동
        }

        // HP 바 업데이트
        healthSlider.value = currentHealth;
    }

    // 게임 오버 또는 다른 처리를 추가할 메소드
    void GameOver()
    {
        // 게임 오버 처리를 추가합니다.
        LoadGameScene(); // 게임 오버 시 Game 씬으로 이동
    }

    // "Game" 씬으로 이동하는 메소드

 

    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
}

