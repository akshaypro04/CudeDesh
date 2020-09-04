
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] Slider SfxSlider;
    [SerializeField] Slider MusicSlider;

    float saveSfxVol;
    float saveMusicVol;


    void Start()
    {
        Volume();
    }


    public void Volume()
    {
        saveSfxVol = GameManager.instances.getSfxVol();
        saveMusicVol = GameManager.instances.getMusicVol();

        SfxSlider.maxValue = 0.3f;
        MusicSlider.maxValue = 0.5f;

        SfxSlider.value = saveSfxVol;
        MusicSlider.value = saveMusicVol;

        UpdateSfxVol();
        UpdateMusicVol();
    }

    public void UpdateSfxVol()
    {
        foreach (Sound s in GameManager.instances.audioManager.sounds)
        {
            s.audioSource.volume = SfxSlider.value;
            GameManager.instances.SetSfxVol(SfxSlider.value);
        }
    }

    public void UpdateMusicVol()
    {
        foreach (Music m in GameManager.instances.audioManager.Musics)
        {
            m.audioSource.volume = MusicSlider.value;
            GameManager.instances.SetMusicVol(MusicSlider.value);
        }
    }

}
