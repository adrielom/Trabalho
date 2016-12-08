using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public float health, maxhealth;
    public Image healthBar;
    public GameObject shot, exitPoint, player;

	// Use this for initialization
	void Start () {
        maxhealth = health;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Destroy (gameObject);
        }
        transform.LookAt (2 * transform.position - player.transform.position);

        if (this.transform.rotation.y > 80) {
            transform.rotation = Quaternion.Euler (transform.rotation.x, Random.Range(5, 30), transform.rotation.z);
        }
        StartCoroutine (DelayInstantiation ());
	}


    IEnumerator DelayInstantiation () {
        yield return new WaitForSeconds (Random.Range(10, 120));
        Instantiate (shot, exitPoint.transform.position, Quaternion.identity);
    }

    public void Damage () {
        health -= Random.Range (1, 3);
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
