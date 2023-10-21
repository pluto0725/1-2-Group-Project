using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float maxHP = 100;
    private float curHP = 100;
    float imsi;


    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = (float) curHP / (float) maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(curHP > 0)
            {
                curHP -= 10;
            }
            else
            {
                curHP = 0;
            }
            imsi = (float) curHP / (float)maxHP;
        }
    }

    void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, imsi, Time.deltaTime * 10);
    }

}
