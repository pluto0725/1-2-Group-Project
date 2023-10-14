using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

[RequireComponent(typeof(DragManager))]
public class Item : MonoBehaviour
{
    public int number;

    [SerializeField] private Color[] colors;

    [SerializeField] private Sprite[] images;

    public void SetItem(int newValue, Transform newParent)
    {
        number = newValue;

        UnityEngine.UI.Image imageComponent = GetComponent<UnityEngine.UI.Image>();
        if (imageComponent != null && number >= 0 && number < images.Length)
        {
            imageComponent.sprite = images[number];
        }

        UnityEngine.UI.Text textComponent = GetComponent<UnityEngine.UI.Text>();
        if (textComponent != null)
        {
            textComponent.text = number.ToString();
        }

        transform.SetParent(newParent);
    }

    // SetColor 함수는 더 이상 사용되지 않습니다.
}




