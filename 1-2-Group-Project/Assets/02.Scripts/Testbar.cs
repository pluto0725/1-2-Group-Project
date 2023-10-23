using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testbar : MonoBehaviour
{
    public Slider healthSlider; // HP �ٸ� ������ �����̴� UI ���
    public Text timerText; // Ÿ�̸� �ؽ�Ʈ UI ��� �߰�
    public int maxHealth = 20000;
    private int currentHealth;
    private float timer = 60.0f; // 60�� Ÿ�̸�

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    private void Update()
    {
        // Ÿ�̸� ������Ʈ
        if (timer > 0)
        {
            timer -= Time.deltaTime; // �ð��� ���ҽ�Ŵ
            UpdateTimerText();
        }
        else
        {
            // Ÿ�̸Ӱ� 0���� �۰ų� ������ ���� ���� �Ǵ� �ٸ� ó���� �߰��� �� �ֽ��ϴ�.
            // ��: GameOver() �޼ҵ� ȣ�� �Ǵ� �ٸ� ó�� �߰�
        }

        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 Ŭ�� �� ü�� ����
            TakeDamage(1000);
        }
    }

    void UpdateTimerText()
    {
        // Ÿ�̸� �ؽ�Ʈ ������Ʈ
        int seconds = Mathf.CeilToInt(timer);
        timerText.text = seconds.ToString() + "s";
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // ���⿡ ���� ���� �Ǵ� �ٸ� ó���� �߰��� �� �ֽ��ϴ�.
            // ��: GameOver() �޼ҵ� ȣ�� �Ǵ� �ٸ� ó�� �߰�
        }

        // HP �� ������Ʈ
        healthSlider.value = currentHealth;
    }

    // ���� ���� �Ǵ� �ٸ� ó���� �߰��� �޼ҵ�
    void GameOver()
    {
        // ���� ���� ó���� �߰��մϴ�.
    }
}
