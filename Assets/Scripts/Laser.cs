using UnityEngine;
using System.Collections;

public enum oponents {player, enemy, };

public class Laser : MonoBehaviour {

    public oponents op;
    public GameObject player;
    public GameObject target;
    public float speed;
    public float lifetime = 2;

	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) {
            Destroy (this.gameObject);
        }
        if (gameObject.tag == "Bullet") {
            gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * speed * Time.deltaTime, ForceMode.Impulse);

        }
        else {
            gameObject.GetComponent<Rigidbody> ().AddForce (-transform.forward * speed * Time.deltaTime, ForceMode.Impulse);

        }

        float delta = Vector3.Distance (this.gameObject.transform.position, player.transform.position);
        if (delta >= 1000f && gameObject.tag == "Bullet") {
            Destroy (this.gameObject);
        }
        else if (delta <= 10f && gameObject.tag == "EnemyBullet") {
            Destroy (this.gameObject);
        }
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Player") {
            Destroy (this.gameObject);
        }
        else if (other.gameObject.tag == "Enemy") {
            Destroy (this.gameObject);
        }
    }
}
