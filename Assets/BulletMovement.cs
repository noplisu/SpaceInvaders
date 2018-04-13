using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float speed = 10;

    void Start()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, speed);
    }
}
