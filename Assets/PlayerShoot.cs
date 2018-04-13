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
