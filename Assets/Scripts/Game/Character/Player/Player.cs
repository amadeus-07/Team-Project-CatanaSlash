using VContainer;

public class Player : Character
{

    protected override void OnDamage(int delta)
    {
    }

    protected override void OnDead()
    {
        gameObject.SetActive(false);
    }
}