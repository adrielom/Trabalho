using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public float health, maxhealth, timer;
    public Image healthBar;
    public GameObject shot, exitPoint, player;

	// Use this for initialization
	void Start () {
        maxhealth = health;
        timer = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (health <= 0) {
            Destroy (gameObject);
        }
        transform.LookAt (2 * transform.position - player.transform.position);

        if (this.transform.rotation.y > 80) {
            transform.rotation = Quaternion.Euler (transform.rotation.x, Random.Range(5, 30), transform.rotation.z);
        }
        if (timer <= 0) {
            EnemyShoots ();

        }
    }


    void EnemyShoots () {
        Instantiate (shot, exitPoint.transform.position, Quaternion.identity);
        timer = Random.Range (3, 7);
    }

    public void Damage () {
        health -= Random.Range (1, 10);
        healthBar.fillAmount = health / maxhealth;
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Bullet") {
            Damage ();
        }
        if (other.gameObject.tag == "Enemy") {
            Destroy (this.gameObject);
        }
    }
}
