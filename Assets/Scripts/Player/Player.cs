using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float speed;

    private PlayerMove playerMove;

    void Awake()
    {
        SetSingleton();
        playerMove = new PlayerMove(gameObject, speed);
    }

    void Update()
    {
        playerMove.Move();
    }

    private void SetSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
