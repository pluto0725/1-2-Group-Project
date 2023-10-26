using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtonMgr : MonoBehaviour
{
    // 버튼 클릭 이벤트 핸들러
    public void OnButtonClick()
    {
        // "Game"이라는 이름의 씬으로 전환
        SceneManager.LoadScene("Game");
    }

    public GameObject SettingsPanel; // 설정 창을 나타내는 UI 패널
    public GameObject SettingsClose; // 설정 창을 닫는 버튼
    public GameObject bgmSetting;
    public GameObject AudioSetting;
    public GameObject SettingButton;


    // 설정 버튼 클릭 시 호출되는 함수
    public void OnSettingsButtonClick()
    {
        SettingsPanel.SetActive(true); // 설정 창을 활성화하여 보이게 만듭니다.
        SettingsClose.SetActive(true);
        bgmSetting.SetActive(true);
        AudioSetting.SetActive(true);
        SettingButton.SetActive(false);
    }

    // 설정 창에서 닫기 버튼 클릭 시 호출되는 함수
    public void OnCloseSettingsButtonClick()
    {
        SettingsPanel.SetActive(false); // 설정 창을 비활성화하여 숨깁니다.
        SettingsClose.SetActive(false);
        bgmSetting.SetActive(false);
        AudioSetting.SetActive(false);
        
        SettingButton.SetActive(true);
    }

    public AudioManager audioManager; // AudioManager 스크립트를 연결할 변수


    // 버튼을 클릭할 때 호출될 함수
    public void ToggleBackgroundMusic()
    {
        // 배경음악이 재생 중이면 멈추고, 멈춰있으면 재생합니다.
        if (audioManager.GetComponent<AudioSource>().isPlaying)
        {
            audioManager.StopBackgroundMusic();
        }
        else
        {
            audioManager.PlayBackgroundMusic();
        }
    }


    public void GoBossRoom()
    {
        SceneManager.LoadScene("Boss_stage_1");
    }


}
