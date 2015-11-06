using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    public GameObject target;

	// Update is called once per frame
	void Update () {
        Vector3 correction = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
        transform.position = correction;
	}
}
