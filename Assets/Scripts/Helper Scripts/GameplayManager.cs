using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayManager : MonoBehaviour{

    public static GameplayManager instance;

    [SerializeField]
    private Text countDownText;

    public int countdownTimer = 60;

    [SerializeField]
    private Text scoreText;

    private int scoreCount;

    [SerializeField]
    private Image ScoreFullUI;

    void Start(){
        DisplayScore(0);
        countDownText.text = countdownTimer.ToString();
        StartCoroutine("Counterdown");

    }

    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    IEnumerator Counterdown(){
        yield return new WaitForSeconds(1f);
        countdownTimer--;
        countDownText.text = countdownTimer.ToString();
        if(countdownTimer <= 10){
            SoundManager.instance.TimeRunningOut(true);
        }
        StartCoroutine("Counterdown");

        if(countdownTimer <= 0){
            StopCoroutine("Counterdown");
            SoundManager.instance.GameEnd();
            SoundManager.instance.TimeRunningOut(false);
            StartCoroutine(RestartGame());
        }
    }

    public void DisplayScore(int score){
       if(scoreText == null){
        return;
       }
       scoreCount += score;
       scoreText.text = "$ " + scoreCount;

       ScoreFullUI.fillAmount = (float)scoreCount / 100f;

       if(scoreCount >= 100){
           StopCoroutine("Counterdown");
              SoundManager.instance.GameEnd();
              StartCoroutine(RestartGame());
       }
    }

    IEnumerator RestartGame(){
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    

}
