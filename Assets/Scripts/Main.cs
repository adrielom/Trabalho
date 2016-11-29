using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    Vector3 startPos;
    public GameObject enemy, player;
    int counter = 0;
    public float timer;
    public Text timerT;

	// Use this for initialization
	void Start () {
        startPos = new Vector3 (Random.Range (50, 1000), Random.Range (50, 1000), Random.Range (50, 1000));
	}
	
	// Update is called once per frame
	void Update () {

        timerT.text = timer.ToString ();
        timer -= Time.deltaTime;
        if (timer <= 0) {
            print ("GAme OVer");
        }

        if (counter < 10) {
            StartCoroutine (DelayInstantiation ());
        }
        else {
            StartCoroutine (DelayCounter ());
        }
    }

    IEnumerator DelayInstantiation () {
        yield return new WaitForSeconds (Random.Range (0, 120));
        Instantiate (enemy, startPos, Quaternion.LookRotation (player.transform.forward));
        counter++;
    }

    IEnumerator DelayCounter () {
        yield return new WaitForSeconds (Random.Range (20, 60));
        counter = 0;
    }
}
