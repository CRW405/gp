using UnityEngine;

public class GameManager : Singleton<GameManager> {
  private bool _isGameActive;
  private float _gameTime; 

  public override void Awake() {
    base.Awake(); // must call base Awake logic due to virtual
  }

  void Start() {
    InitializeGame();
  }

  private void InitializeGame() {
    Debug.Log("[GameManager] init...");
    _isGameActive = false;
    _gameTime = 0f;
  }

  public void StartGame(){
    Debug.Log("[GameManager] Game Start");
    _isGameActive = true;
  }

  public void PauseGame() {
    Debug.Log("[GameManager] Game Pause");
    _isGameActive = false;
    Time.timeScale = 0f;
  }

  public void ResumeGame() {
    Debug.Log("[GameManager] Game Resume");
    _isGameActive = true;
    Time.timeScale = 1f;
  }

  void Update() {
    if (_isGameActive) {
      _gameTime += Time.deltaTime;
    }
  }
}
