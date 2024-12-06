using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMono<Player>
{
    public float speed;
    public List<GameObject> energyList;

    public PlayerAnimate playerAnimate;
    private PlayerMove playerMove;
    private PlayerCollider playerCollider;

    protected override void Awake()
    {
        base.Awake();
        energyList = new();
        playerMove = new PlayerMove(Instance, speed);
        playerAnimate = new PlayerAnimate(Instance);
        playerCollider = new PlayerCollider(Instance);
    }

    void Start()
    {
        playerAnimate.Appear();
    }

    void Update()
    {
        playerMove.Move();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playerCollider.OnEnter(col);
    }

    private void OnMouseUp()
    {
        playerAnimate.Disappear();
    }
}
