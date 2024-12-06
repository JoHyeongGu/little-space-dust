using UnityEngine;
using UnityEngine.AI;

public class PlayerMove
{
    private Rigidbody2D rigid;
    private NavMeshAgent agent;
    private float speed;

    public PlayerMove(Player player, float speed = 0)
    {

        this.speed = speed;
        rigid = player.GetComponent<Rigidbody2D>();
        agent = player.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void Move()
    {
        Vector2 move = JoyStickController.Instance.Move * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + move);
    }
}
