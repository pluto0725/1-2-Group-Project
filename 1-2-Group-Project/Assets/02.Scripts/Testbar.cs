using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testbar : MonoBehaviour
{
    public Slider healthSlider; // HP �ٸ� ������ �����̴� UI ���
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
            // ���콺 Ŭ�� �� ü�� ����
            TakeDamage(1000);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // ���⿡ ���� ���� �Ǵ� �ٸ� ó���� �߰��� �� �ֽ��ϴ�.
        }

        // HP �� ������Ʈ
        healthSlider.value = currentHealth;
    }
}
