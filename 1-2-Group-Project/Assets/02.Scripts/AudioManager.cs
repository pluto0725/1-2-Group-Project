using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource bgmAudioSource;

    private void Start()
    {
        // 배경음악 AudioSource 컴포넌트 가져오기
        bgmAudioSource = GetComponent<AudioSource>();
    }

    // 배경음악을 재생하는 함수
    public void PlayBackgroundMusic()
    {
        bgmAudioSource.Play();
    }

    // 배경음악을 멈추는 함수
    public void StopBackgroundMusic()
    {
        bgmAudioSource.Stop();
    }
}
