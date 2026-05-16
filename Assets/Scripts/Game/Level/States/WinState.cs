using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : State
{
    private LabelPresenter _labelPresenter;
    
    public WinState(LabelPresenter labelPresenter)
    {
        _labelPresenter = labelPresenter;
    }

    protected override void OnEnter()
    {
        _labelPresenter.PlayWin(NextLevel);
    }


    private void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = ++index % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextIndex);
    }
}