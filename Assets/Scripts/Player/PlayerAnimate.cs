using UnityEngine;

public class PlayerAnimate
{
    private Player player;
    private Animator ani;
    private enum State
    {
        IDLE = 0,
        RIGHT = 1,
    }

    public PlayerAnimate(Player player)
    {
        this.player = player;
        ani = player.GetComponent<Animator>();
    }

    public void Appear()
    {
        ani.SetTrigger("Appear");
    }

    public void Disappear()
    {
        ani.SetTrigger("Disappear");
    }

    public void ChangeShape(int state)
    {
        if (state == (int)State.RIGHT)
        {
            ani.SetInteger("State", state);
        }
    }

}
