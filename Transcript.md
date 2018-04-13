- select camera
- set background to black
- Add Layers:
	- Layer8: Player
	- Layer9: PlayerBullet
	- Layer10: Enemy
- Go to edit -> ProjectSettings -> Physics2D and change the collision matrix
	- Default layer should collide with Player and PlayerBullet 
	- Player layer should collide with Enemy
	- PlayerBullet layer should collide with Enemy
- import Sprites
- add spaceinvaders_player to scene
- set Layer to Player for player
- add boxCollider2D to player
- add rigidbody2d to player
- set gravity scale to 0 on rigidbody2D
- set constraints freeze rotation Z on rigidbody2D
- set constraints freeze position Y on rigidbody2D
- add Component to spaceinvaders_player PlayerMovement script
```
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
```
- add Component to spaceinvaders_player PlayerShoot script
```
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public float cooldown = 0.5f;
    public GameObject bullet;

    float currentCooldown = 0;
	void Update () {
        if(Input.GetButton("Jump") && currentCooldown <= 0) {
            currentCooldown = cooldown;
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
        currentCooldown -= Time.deltaTime;
    }
}
```
- add fullblock to the scene
- change fullblock scale to X=5 Y=5
- add boxCollider2D to fullblock
- set boxCollider2D to trigger in fullblock
- add Ridigbody2D to fullblock
- set gravity scale to 0 on rigidbody2D
- set constraints freeze rotation Z on rigidbody2D
- set constraints freeze position X on rigidbody2D
- Add Component to fullblock BulletMovement script
```
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float speed = 10;

    void Start() {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, speed);
    }
}
```
- Add Component to fullblock CleanObjectAfterTime script
```
using System.Collections;
using UnityEngine;

public class CleanObjectAfterTime : MonoBehaviour {
    public float time = 2;

    void Start () {
        StartCoroutine(CleanSelf());
    }

    IEnumerator CleanSelf()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
```
- set Layer to PlayerBullet for fullblock
- drag fullblock from Hierarchy to Project
- remove fullblock from Hierarchy
- add fullblock to players PlayerShoot script
- add EmptyGame object and rename it to CollisionLeft
- add boxCollider2D to CollisionLeft
- set Scale y=100
- set position x=-9.4 y=0
- add EmptyGame object and rename it to CollisionRight
- add boxCollider2D to CollisionLeft
- set Scale y=100
- set position x=9.4 y=0
- add EmptyGame object and rename it to Invasion
- add Rigidbody2D to Invasion
- set gravity scale to 0 on rigidbody2D
- set constraints freeze rotation Z on rigidbody2D
- add Component to Invasion InvasionMovement script
```
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
```
- drop enemy_1_1 to Invasion
- set Layer to Enemy for enemy_1_1
- Change enemy_1_1 scale to X=5 Y=5
- add boxCollider2D to enemy_1_1
- add Component to fullblock KillEnemy script
```
using UnityEngine;

public class KillEnemy : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
}
```
- add Component to player RestartOnCollision script
```
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnCollision : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Scene loadedLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(loadedLevel.buildIndex);
        }
    }
}
```
- add EmptyGame object and rename it to Ground
- add boxCollider2D to Ground
- set Scale x=100
- set position x=0 y=-5.6
- add Component to ground RestartOnCollision script