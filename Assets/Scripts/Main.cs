using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    Vector3 startPos;
    public GameObject enemy, player;
    int counter = 0;
    public float timer, timerInstantiation; 
    public Text timerT;

	// Use this for initialization
	void Start () {
        timerInstantiation = 5;
	}
	
	// Update is called once per frame
	void Update () {

        timerT.text = timer.ToString ();
        timer -= Time.deltaTime;
        timerInstantiation -= Time.deltaTime;

        if (timer <= 0) {
            print ("Game OVer");
        }
        if (timerInstantiation <= 0) {
            DelayInstantiation ();

        }
    }

    void DelayInstantiation () {
        startPos = new Vector3 (Random.Range (50, 500), Random.Range (50, 500), Random.Range (50, 500));
        Instantiate (enemy, startPos, Quaternion.LookRotation (player.transform.forward));
        timerInstantiation = 5f;
    }

}
