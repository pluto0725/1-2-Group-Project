using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMgr : MonoBehaviour
{
    // 버튼 클릭 이벤트 핸들러
    public void OnButtonClick()
    {
        // "Game"이라는 이름의 씬으로 전환
        SceneManager.LoadScene("Game");
    }

    public GameObject SettingsPanel; // 설정 창을 나타내는 UI 패널
    public GameObject SettingsClose; // 설정 창을 닫는 버튼

    // 설정 버튼 클릭 시 호출되는 함수
    public void OnSettingsButtonClick()
    {
        SettingsPanel.SetActive(true); // 설정 창을 활성화하여 보이게 만듭니다.
        SettingsClose.SetActive(true);
    }

    // 설정 창에서 닫기 버튼 클릭 시 호출되는 함수
    public void OnCloseSettingsButtonClick()
    {
        SettingsPanel.SetActive(false); // 설정 창을 비활성화하여 숨깁니다.
        SettingsClose.SetActive(false);
    }



}
