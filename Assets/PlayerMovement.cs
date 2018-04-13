using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 10;
    Rigidbody2D rigid;

	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        rigid.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0);
	}
}
