using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : State
{
    private LabelPresenter _labelPresenter;
    private AudioPlayer _audioPlayer;
    
    public WinState(LabelPresenter labelPresenter, AudioPlayer audioPlayer)
    {
        _labelPresenter = labelPresenter;
        _audioPlayer = audioPlayer;
    }

    protected override void OnEnter()
    {
        _audioPlayer.Music.Stop();
        _labelPresenter.PlayWin(NextLevel);
    }


    private void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = ++index % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextIndex);
    }
}