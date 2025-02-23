using UnityEngine;

public class SoundManager : MonoBehaviour{

    public static SoundManager instance;

    [SerializeField]
    private AudioSource hookGrab_Gold_FX, hookGrab_Stone_FX, playerLaugh_FX, pullSoundFX, ropeStretchFX, timeRunningout_FX, gameEnd_FX;

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    public void HookGrab_Gold(){
        hookGrab_Gold_FX.Play();
    }
    public void HookGrab_Stone(){
        hookGrab_Stone_FX.Play();
    }
    public void PlayerLaugh(){
        playerLaugh_FX.Play();
    }


    public void RopeStretch(bool playFX){
        // ropeStretchFX.Play();
        if(playFX){
            if(!ropeStretchFX.isPlaying){
            ropeStretchFX.Play();
            }
        }else{

            if(ropeStretchFX.isPlaying){
                ropeStretchFX.Stop();
            }

        }
    }

    public void PullSound(bool playFX){
        if(playFX){
            if(!pullSoundFX.isPlaying){
                pullSoundFX.Play();
            }
        }else {
            if(pullSoundFX.isPlaying){
                pullSoundFX.Stop();
            }
        }

        // pullSoundFX.Play();
    }

     public void TimeRunningOut(bool playFX){
        // ropeStretchFX.Play();
        if(playFX){
            if(!timeRunningout_FX.isPlaying){
            timeRunningout_FX.Play();
            }
        }else{

            if(timeRunningout_FX.isPlaying){
                timeRunningout_FX.Stop();
            }

        }
    }

    public void GameEnd(){
        gameEnd_FX.Play();
    }

}
