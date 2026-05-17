using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : State
{
    private LabelPresenter _labelPresenter;
    private AudioPlayer _audioPlayer;
    
    public LoseState(LabelPresenter labelPresenter, AudioPlayer audioPlayer)
    {
        _labelPresenter = labelPresenter;
        _audioPlayer = audioPlayer;

    }

    protected override void OnEnter()
    {
        _audioPlayer.Music.Stop();
        _labelPresenter.PlayLose(ReloadLevel);
        
    }

    private void ReloadLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}