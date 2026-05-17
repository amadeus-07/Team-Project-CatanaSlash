using Unity.VisualScripting;
using UnityEngine;

public class CounterAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource shot;
    [SerializeField] private AudioSource end;

    public void Shot()
    {
        shot.Play();
    }

    public void End()
    {
        end.Play();
    }
}