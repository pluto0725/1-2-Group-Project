using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtonMgr : MonoBehaviour
{
    // ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    public void OnButtonClick()
    {
        // "Game"�̶�� �̸��� ������ ��ȯ
        SceneManager.LoadScene("Game");
    }

    public GameObject SettingsPanel; // ���� â�� ��Ÿ���� UI �г�
    public GameObject SettingsClose; // ���� â�� �ݴ� ��ư
    public GameObject bgmSetting;
    public GameObject AudioSetting;
    public GameObject SettingButton;


    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnSettingsButtonClick()
    {
        SettingsPanel.SetActive(true); // ���� â�� Ȱ��ȭ�Ͽ� ���̰� ����ϴ�.
        SettingsClose.SetActive(true);
        bgmSetting.SetActive(true);
        AudioSetting.SetActive(true);
        SettingButton.SetActive(false);
    }

    // ���� â���� �ݱ� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnCloseSettingsButtonClick()
    {
        SettingsPanel.SetActive(false); // ���� â�� ��Ȱ��ȭ�Ͽ� ����ϴ�.
        SettingsClose.SetActive(false);
        bgmSetting.SetActive(false);
        AudioSetting.SetActive(false);
        
        SettingButton.SetActive(true);
    }

    public AudioManager audioManager; // AudioManager ��ũ��Ʈ�� ������ ����


    // ��ư�� Ŭ���� �� ȣ��� �Լ�
    public void ToggleBackgroundMusic()
    {
        // ��������� ��� ���̸� ���߰�, ���������� ����մϴ�.
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
