using UnityEngine;

public class PlayerCollider
{
    private Player player;

    public PlayerCollider(Player player)
    {
        this.player = player;
    }

    public void OnEnter(Collider2D col)
    {
        if (col.tag.Equals("Energy")) OnEnergy(col);
    }

    private void OnEnergy(Collider2D col)
    {
        Energy energy = col.GetComponent<Energy>();
        if (energy.contain) return;
        player.energyList.Add(energy.gameObject);
        AddChild(energy.transform);
    }

    private void AddChild(Transform child)
    {
        player.playerAnimate.ChangeShape(1);
        child.SetParent(player.gameObject.transform, false);
    }
}