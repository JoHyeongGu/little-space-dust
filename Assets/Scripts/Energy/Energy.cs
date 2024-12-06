using UnityEngine;

public class Energy : MonoBehaviour
{
    public bool contain = false;
    private EnergyAnimate energyAnimate;

    void Awake()
    {
        energyAnimate = new EnergyAnimate(this);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
            OnTriggerWithPlayer(col);
    }

    private void OnTriggerWithPlayer(Collider2D col)
    {
        if (contain) return;
        energyAnimate.OnMerge(col.transform.position);
        transform.localPosition = new(0.18f, 0f, 0f);
        contain = true;
    }
}
