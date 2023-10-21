using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testbar : MonoBehaviour
{
    public Slider healthSlider; // HP 바를 연결할 슬라이더 UI 요소
    public int maxHealth = 20000;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭 시 체력 감소
            TakeDamage(1000);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // 여기에 게임 오버 또는 다른 처리를 추가할 수 있습니다.
        }

        // HP 바 업데이트
        healthSlider.value = currentHealth;
    }
}
