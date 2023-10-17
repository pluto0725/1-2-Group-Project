using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public string MonsterName;

    public int Current_HP;
    public int HP;

    public int Attack;
    public Text Hp;


    private void Start()
    {
        Hp.text = Current_HP + " " + HP;
    }
}
