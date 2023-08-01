using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioService : MonoBehaviour
{

    #region Game Spesific
    public AudioClip dropSound;
    #endregion
    public AudioSource[] bgMusic;

    #region UI Fields
    public AudioClip normalBtnSound;
    public AudioClip playBtnSound;
    public AudioClip SelectBtnSound;
    public AudioClip okBtnSound;
    public AudioClip uiClick;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip popUpOpen;
    public AudioClip popUpClose;
    public AudioSource uiSoundPlayer;
    public AudioSource alarmSound;
    public AudioClip sliderSound;
    public AudioClip enemiesStatusSound;
    public AudioClip levelNumberSound;
    public AudioClip buttonsSoundAtLevelPopup;

    #endregion

    private void Start()
    {
        foreach (AudioSource source in bgMusic)
        {
            source.ignoreListenerPause = true;
            source.ignoreListenerVolume = true;
        }
    }

    public void InitializeSounds()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!bgMusic[0].isPlaying)
                bgMusic[0].Play();

            bgMusic[1].Stop();
        }
        else
        {
            //if(!bgMusic[1].isPlaying)
            //	bgMusic[1].Play();

            bgMusic[0].Stop();
            Debug.Log("Uncomment Gameplay sounds from here");
        }
        //SetMusicVolume(Services.UserSettings.GetMusic());
        //SetSoundVolume(Services.UserSettings.GetSound());
    }

    public void SetMusicVolume(float value)
    {
        foreach (AudioSource source in bgMusic)
        {
            source.volume = value;
        }
        //Services.UserSettings.SetMusic(value);
    }

    public void SetSoundVolume(float value)
    {
        AudioListener.volume = value;
        //Services.UserSettings.SetSounds(value);

    }




    #region Sound FX Methods

    public void PlaySound(AudioClip clip)
    {
        uiSoundPlayer.PlayOneShot(clip);
    }

    public void PlayNormalBtnSound()
    {
        uiSoundPlayer.PlayOneShot(normalBtnSound);
    }
    public void PlayBtnSound()
    {
        uiSoundPlayer.PlayOneShot(playBtnSound);
    }
    public void PlaySelectBtnSound()
    {
        uiSoundPlayer.PlayOneShot(SelectBtnSound);
    }

    public void PlayOkBtnSound()
    {
        uiSoundPlayer.PlayOneShot(okBtnSound);
    }

    public void PlayWinSound()
    {
        uiSoundPlayer.PlayOneShot(winSound);
        alarmSound.Pause();
        //Invoke("StopAllSounds", 0.3f);
    }
    public void PlayItemPurchasedSound()
    {
        uiSoundPlayer.PlayOneShot(winSound);
    }
    public void StopItemPurchasedSound()
    {
        uiSoundPlayer.Pause();
    }
    public void PlayLoseSound()
    {
        uiSoundPlayer.PlayOneShot(loseSound);
        //Invoke("StopAllSounds", loseSound.length);
    }

    public void StopAllSounds()
    {
        AudioListener.volume = 0;

        foreach (var item in bgMusic)
        {
            item.Stop();
        }
    }
    public void PlayAllSounds()
    {
        AudioListener.volume = 1;

        foreach (var item in bgMusic)
        {
            bgMusic[0].Play();
        }
    }
    #endregion

}
