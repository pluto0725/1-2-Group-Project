using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMgr : MonoBehaviour
{
    // ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    public void OnButtonClick()
    {
        // "Game"�̶�� �̸��� ������ ��ȯ
        SceneManager.LoadScene("Game");
    }

    public GameObject SettingsPanel; // ���� â�� ��Ÿ���� UI �г�
    public GameObject SettingsClose; // ���� â�� �ݴ� ��ư

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnSettingsButtonClick()
    {
        SettingsPanel.SetActive(true); // ���� â�� Ȱ��ȭ�Ͽ� ���̰� ����ϴ�.
        SettingsClose.SetActive(true);
    }

    // ���� â���� �ݱ� ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnCloseSettingsButtonClick()
    {
        SettingsPanel.SetActive(false); // ���� â�� ��Ȱ��ȭ�Ͽ� ����ϴ�.
        SettingsClose.SetActive(false);
    }



}
