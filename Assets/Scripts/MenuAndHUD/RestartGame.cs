using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.IO;

namespace CrossyMine
{
    public class RestartGame : MonoBehaviour
    {
        public void Restart()
        {
            RestartStatic();
        }
        public static void RestartStatic()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
