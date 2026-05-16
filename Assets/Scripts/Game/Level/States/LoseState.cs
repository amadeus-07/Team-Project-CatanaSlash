using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : State
{
    private LabelPresenter _labelPresenter;
    
    public LoseState(LabelPresenter labelPresenter)
    {
        _labelPresenter = labelPresenter;

    }

    protected override void OnEnter()
    {
        _labelPresenter.PlayLose(ReloadLevel);
        
    }

    private void ReloadLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}