using UnityEngine;
using UnityEngine.AI;

public class Dust : MonoBehaviour
{
    public float speed;
    public FloatingJoystick joystick;

    private static Dust instace;
    private Rigidbody2D rigid;
    private NavMeshAgent agent;

    public static Dust Instance
    {
        get { return instace; }
    }

    void Awake()
    {
        if (instace == null) instace = this;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveVec = new Vector2(joystick.Horizontal, joystick.Vertical) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }
}
