using UnityEngine;

namespace Managers {
  public class MusicManager: MonoBehaviour {
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;

    public static MusicManager Instance;

    private AudioSource audioSource;

    private void Awake() {
      if (Instance == null) {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
      } else {
        Destroy(this.gameObject);
      }
    }

    private void Start() {
      this.audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayMenuMusic() {
      if (this.audioSource.clip == this.menuMusic) {
        return;
      }

      this.audioSource.Stop();
      this.audioSource.clip = this.menuMusic;
      this.audioSource.Play();
    }

    public void PlayGameMusic() {
      if (this.audioSource.clip == this.gameMusic) {
        return;
      }

      this.audioSource.Stop();
      this.audioSource.clip = this.gameMusic;
      this.audioSource.Play();
    }
  }
}
