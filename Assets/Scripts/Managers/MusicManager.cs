using UnityEngine;

namespace Managers {
  public class MusicManager: MonoBehaviour {
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip lostSoulFound;

    public static MusicManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource effectsSource;

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

    public void PlayLostSoulFound() {
      this.effectsSource.Stop();
      this.effectsSource.clip = this.lostSoulFound;
      this.effectsSource.Play();
    }
  }
}
