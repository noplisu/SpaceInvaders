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
