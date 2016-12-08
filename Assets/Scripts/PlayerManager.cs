using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour {

    public PlayerManager instance = null;
    public float rotationSpeed;
    RaycastHit ray;
    public GameObject target, shot, leftBeam, rightBeam;
    public Image targetHud, hud;
    public Text healthT;
    Animator anim;
    bool clicked = false;
    public float health, hor, vert;

    void Awake () {
        if (instance == null) {
            instance = this;
        }
    }

    void FixedUpdate () {
        anim = gameObject.GetComponent<Animator> ();
        Raycast ();
 
        if (clicked) {
            Shooting ();
        }

        healthT.text = health.ToString ();
    }

    public void ClickedOff () {
        clicked = false;
        anim.SetBool ("shot", false);

    }

    public void Shooting () {
        clicked = true;
        anim.SetBool ("shot", true);
    }

    public void LeftShot () {
        Vector3 p = leftBeam.transform.position;
        Instantiate (shot, p, Quaternion.LookRotation(transform.forward));
    }
    public void RightShot  () {
        Vector3 p = rightBeam.transform.position;
        Instantiate (shot, p, Quaternion.LookRotation (transform.forward));

    }


    public void Raycast () {
        Debug.DrawLine (gameObject.transform.position, target.transform.position);

        if (Physics.Linecast (gameObject.transform.position, target.transform.position)) {
            targetHud.color = Color.red;
        }
        else {
            targetHud.color = Color.white;
        }
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "EnemyBullet") {
            health -= Random.Range (0, 2);
            StartCoroutine (DelayChangeColour ());
        }
    }

    IEnumerator DelayChangeColour () {
        hud.color = Color.red;
        yield return new WaitForSeconds (.5f);
        hud.color = Color.white;
    }
}
