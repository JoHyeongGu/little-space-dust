using UnityEngine;
using UnityEngine.AI;

public class PlayerMove
{
    private Rigidbody2D rigid;
    private NavMeshAgent agent;
    private float speed;

    public PlayerMove(GameObject gameObject, float speed)
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        this.speed = speed;
    }

    public void Move()
    {
        Vector2 move = JoyStickController.Instance.Move * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + move);
    }
}
