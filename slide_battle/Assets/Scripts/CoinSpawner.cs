using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    //2���� �� ���� ���� �������� ���� ����
    [SerializeField] Vector3 centerPosition;
    [SerializeField] float radius;
    [SerializeField] float yOffset;
    [SerializeField] int feverTimeCoinCount;
    [SerializeField] float feverTimeCoinSpawnTimeInterval;
    [SerializeField] float defaultCoinSpawnTimeInterval;
    [SerializeField] GameObject feverText;
    List<GameObject> coinList;

    private void Awake()
    {
        coinList = new List<GameObject>();
    }

    public void DestroyAndClearCoinList()
    {
        foreach (GameObject coin in coinList)
        {
            Destroy(coin);
        }
       
        coinList.Clear();
    }

    public void SpawnCoin()
    {
        GameObject newCoin = Instantiate(Resources.Load<GameObject>("Prefabs/Coin"));
        newCoin.transform.position = GetRandomPosition();
        coinList.Add(newCoin);
    }
    public void TriggerFeverTime(float probability)
    {
        float randomNumber= Random.Range(0,100);
        Debug.Log(randomNumber);
        Debug.Log(probability);
        if (randomNumber < probability)
        {
            Debug.Log("fever!");
            SoundMgr.GetInstance().Bgm.clip = SoundMgr.GetInstance().feverBgm;
            SoundMgr.GetInstance().Bgm.Play();
            feverText.SetActive(true);   
            StartCoroutine("SpawnFeverCoin");
        }
    }

    public void EndFevertime() {
        SoundMgr.GetInstance().Bgm.clip = SoundMgr.GetInstance().defaultBgm;
        SoundMgr.GetInstance().Bgm.Play();
        feverText.SetActive(false);
        StopCoroutine("SpawnFeverCoin");
    }
    public void TriggerDefaultCoinSpawn()
    {
        StartCoroutine("SpawnCoinDefault");
    }
    public void StopEveryCoinSpawn()
    {
        StopAllCoroutines();
    }
    IEnumerator SpawnCoinDefault()
    {

        while(Observers.GetInstance().panelHandler.GetCurrentPanelStatus() == ENUM_PANEL_STATUS.IN_GAME){
            SpawnCoin();
            yield return new WaitForSeconds(defaultCoinSpawnTimeInterval);
        }
    }

    IEnumerator SpawnFeverCoin()
    {
        int count = 0;
        while (count <= feverTimeCoinCount) {
            SpawnCoin();
            count++;
            if (count >= feverTimeCoinCount) {
                EndFevertime();
            }
            yield return new WaitForSeconds(feverTimeCoinSpawnTimeInterval);
        }
    }
    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3();

        float xpos = Random.Range(-1*radius,radius);
        float zpos = Random.Range(-1*Mathf.Sqrt((radius * radius) - (xpos * xpos)), Mathf.Sqrt((radius*radius)-(xpos*xpos)));

        randomPosition = new Vector3(xpos+centerPosition.x,yOffset+centerPosition.y,zpos+centerPosition.z);

        return randomPosition;
    }
}
