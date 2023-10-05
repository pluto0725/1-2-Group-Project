using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource bgmAudioSource;

    private void Start()
    {
        // ������� AudioSource ������Ʈ ��������
        bgmAudioSource = GetComponent<AudioSource>();
    }

    // ��������� ����ϴ� �Լ�
    public void PlayBackgroundMusic()
    {
        bgmAudioSource.Play();
    }

    // ��������� ���ߴ� �Լ�
    public void StopBackgroundMusic()
    {
        bgmAudioSource.Stop();
    }
}
