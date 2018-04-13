using UnityEngine;

public class InvasionMovement : MonoBehaviour {
    public float speed = 5;
    public float step = 0.2f;

    int direction = 1;
    Rigidbody2D rigid;
    float timer = 0;

	void Start () {
		rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(direction * speed, 0);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Default") && timer <= 0)
        {
            direction *= -1;
            rigid.velocity = new Vector2(direction * speed, 0);
            rigid.MovePosition(new Vector2(transform.position.x, transform.position.y - step));
            timer = 1;
        }
    }
}
