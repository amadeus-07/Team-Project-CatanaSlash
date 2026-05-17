using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [field: SerializeField] public AudioSource Swing { get; private set; }
    [field: SerializeField] public AudioSource Cut { get; private set; }
    [field: SerializeField] public AudioSource Damage { get; private set; }
    [field: SerializeField] public AudioSource Death { get; private set; }
    [field: SerializeField] public AudioSource Music {get; private set;}

    public void DoSwing() => Swing.Play();

}
