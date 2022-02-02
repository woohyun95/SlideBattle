using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutArea : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        switch (other.gameObject.tag) {
            case "Player":
                LifeManager.GetInstance().KillPlayer();
                break;
            case "Enemy":
                DataSaver.GetInstance().AddScore(10);
                StageManager.GetInstance().AddCurrentStageScore(10);
                InGameUI.GetInstance().UpdateScoreUI();
                if (StageManager.GetInstance().IsStageCleared()) {
                    StageManager.GetInstance().StageClear();
                }
                Destroy(other.gameObject,1);
                break;
        }
    }
}
