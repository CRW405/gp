using UnityEngine;
using UnityEngine.SceneManagement;

public class TestGameManager : MonoBehaviour {
  void Start() {
    Debug.Log("[TestGameManager] Testing Game Manager...");

      GameManager.Instance.StartGame();
  }
  
  void Update() {
    if (Input.GetKeyDown(KeyCode.P)) {
      GameManager.Instance.PauseGame();
    }

    if (Input.GetKeyDown(KeyCode.R)) {
      GameManager.Instance.ResumeGame();
    }

    // Load next scene
    if (Input.GetKeyDown(KeyCode.N)) {
      int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
      if (nextScene >= SceneManager.sceneCountInBuildSettings) {
        nextScene = 0; // Loop back to first scene
      }
      SceneManager.LoadScene(nextScene);
    }
  }
}
