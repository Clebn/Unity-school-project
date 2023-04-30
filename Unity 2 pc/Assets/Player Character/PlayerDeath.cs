using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private void Update()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        if(transform.position.y < -5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
