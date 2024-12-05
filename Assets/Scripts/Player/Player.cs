using UnityEngine;

public class Player : SingletonMono<Player>
{
    public float speed;

    private PlayerMove playerMove;

    protected override void Awake()
    {
        base.Awake();
        playerMove = new PlayerMove(gameObject, speed);
    }

    void Update()
    {
        playerMove.Move();
    }
}
