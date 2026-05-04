using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : State
{
    
    public LoseState()
    {
    }

    protected override void OnEnter()
    {
    }

    private void ReloadLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}