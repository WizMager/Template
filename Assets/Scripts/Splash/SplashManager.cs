using UnityEngine;
using UnityEngine.SceneManagement;

namespace Splash
{
    public class SplashManager : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("Game");
        }
    }
}