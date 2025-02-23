using UnityEngine;

public class ItemScripts : MonoBehaviour{

    public float hook_Speed;
    public int scoreValue;

    void OnDisable(){
        // transform.position = new Vector3(0, 0, 0);
        GameplayManager.instance.DisplayScore(scoreValue);
    }
    
}
