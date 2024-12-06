using UnityEngine;

public class EnergyAnimate
{
    private Energy energy;
    private Animator ani;
    private enum State
    {
        IDLE = 0,
        LEFT = 0,
    }

    public EnergyAnimate(Energy energy)
    {
        this.energy = energy;
        ani = energy.GetComponent<Animator>();
    }

    public void OnMerge(Vector3 pos)
    {
        Vector3 relPos = pos - energy.transform.position;
        Debug.Log(relPos);
        if (relPos.x < 0)
        {
            ani.SetInteger("State", 1);
        }
    }
}
