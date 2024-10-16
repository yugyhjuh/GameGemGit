using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToEnd : MonoBehaviour
{

    private bool miniplayerIsClose = false;

    void Update()
    {
        if(miniplayerIsClose == true)
        {
            SceneManager.LoadSceneAsync(1);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            miniplayerIsClose = true;
        }
    }
}
