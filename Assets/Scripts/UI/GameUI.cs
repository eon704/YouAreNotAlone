using Interfaces;
using Managers;
using UnityEngine;

namespace UI {
  public class GameUI : MonoBehaviour {
    public static GameUI Instance;

    [SerializeField] private Transform healthBarsParent;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject lossPanel;

    private RectTransform rectTransform;

    #region Unity Callbacks

    private void Awake() {
      if (Instance == null) {
        Instance = this;
      } else {
        Debug.LogWarning($"Duplicate instance of the Singleton class: {this.name}");
        Destroy(this.gameObject);
      }

      this.rectTransform = this.GetComponent<RectTransform>();
    }

    private void Update() {
      if (Input.GetKeyDown(KeyCode.Escape)) {
        this.pausePanel.SetActive(!this.pausePanel.activeSelf);
      }
    }
    #endregion

    public void Initialize(GameManager gameManager) {
      gameManager.OnLevelComplete += this.OnPlayerVictory;
      gameManager.OnLevelFailed += this.OnPlayerLoss;
    }

    public void InstantiateNewHealthBar(IDamageable target, Transform targetTransform) {
      GameObject healthBarObject = Instantiate(this.healthBarPrefab, this.healthBarsParent);
      HealthBar healthBar = healthBarObject.GetComponent<HealthBar>();
      healthBar.SetHealthBarData(target, targetTransform, this.rectTransform, target.MaxHealth);
    }

    public void ClosePauseMenu() {
      print("Closing menu");
      this.pausePanel.SetActive(false);
    }

    public void QuitToMainMenu() {
      print("Quitting to menu");
      LevelManager.LoadScene("MainMenu");
    }

    public void QuitToDesktop() {
      print("Quitting");
      LevelManager.Exit();
    }

    private void OnPlayerLoss() {
      this.lossPanel.SetActive(true);
    }

    private void OnPlayerVictory() {
      this.winPanel.SetActive(true);
    }
  }
}
