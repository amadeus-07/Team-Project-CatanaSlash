using VContainer;

public class Player : Character
{
    [Inject] private AudioPlayer audioPlayer;

    protected override void OnDamage(int delta)
    {
        audioPlayer.Damage.Play();
    }

    protected override void OnDead()
    {
        audioPlayer.Death.Play();
        gameObject.SetActive(false);
    }
}