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
