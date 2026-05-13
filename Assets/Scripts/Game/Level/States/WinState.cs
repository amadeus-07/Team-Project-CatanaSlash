using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : State
{
    
    public WinState()
    {
        
    }

    protected override void OnEnter()
    {
        NextLevel();
    }


    private void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = ++index % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextIndex);
    }
}