using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    public void GameCaller () {
        SceneManager.LoadScene ("Jogo", LoadSceneMode.Single);
    }

}
