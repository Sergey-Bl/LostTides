using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private string sceneName; // Имя сцены для загрузки.

        public void SceneLoad()
        {
            SceneManager.LoadScene(sceneName); // Загружает указанную сцену.
        }
    }
}