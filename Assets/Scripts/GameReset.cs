using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{

    void Update()
    {
        if (Input.GetButtonDown("Restart"))
		{
			Debug.ClearDeveloperConsole();
			Time.timeScale = 1;

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }
}
