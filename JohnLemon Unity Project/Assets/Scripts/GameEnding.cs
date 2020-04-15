using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float FadeDuration = 1f;
    public float DisplayImageDuration = 1f;
    public GameObject Player;
    bool IsPlayerAtExit;
    bool IsPlayerCaught;
    public CanvasGroup ExitBagroundImageCanvasGroup;
    public AudioSource ExitAudio;
    public AudioSource CaughtAudio;
    bool HasAudioPlayed;
    public CanvasGroup CaughtBagroundImageCanvasGroup;
    float Timer;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        IsPlayerCaught = true;
    }

    void Update()
    {
        if(IsPlayerAtExit)
        {
            EndLevel(ExitBagroundImageCanvasGroup, false, ExitAudio);
        }
        else if(IsPlayerCaught)
        {
            EndLevel(CaughtBagroundImageCanvasGroup, true, CaughtAudio);
        }
    }

    void EndLevel(CanvasGroup ImageCanvasGroup, bool DoRestart, AudioSource AS)
    {
        if (!HasAudioPlayed)
        {
            AS.Play();
            HasAudioPlayed = true;
        }
        Timer += Time.deltaTime;
        ImageCanvasGroup.alpha = Timer / FadeDuration;
        
        if(Timer > FadeDuration + DisplayImageDuration)
        {
            if(DoRestart)
            {
                SceneManager.LoadScene("MainScene");
            }
            else
            {
                Application.Quit();
            }
        }
    }


}
