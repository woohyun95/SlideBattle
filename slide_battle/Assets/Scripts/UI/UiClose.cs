using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiClose : MonoBehaviour
{
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject ClearPanel;
    [SerializeField] GameObject FailtPanel;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject FadeEffect;


    //���� �г�
    public void ACtiveStartPanel()
    {
        StartPanel.SetActive(true);
    }
    public void closeStartPanel()
    {
        StartPanel.SetActive(false);
    }

    //Ʃ�丮�� �г�
    public void ACtiveTutorial()
    {
        TutorialPanel.SetActive(true);
    }
    public void CloseTutorial()
    {
        TutorialPanel.SetActive(false);
    }

    //���� �г�
    public void ACtiveSetting()
    {
        SettingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }

    //Ŭ���� �г�
    public void ACtiveClear()
    {
        ClearPanel.SetActive(true);
    }
    public void CloseClear()
    {
        FadeEffect.SetActive(true);
        StartCoroutine("FadeWait");

    }

    //���� �г�
    public void ACtiveFail()
    {
        FailtPanel.SetActive(true);
    }
    public void CloseFail()
    {
        FailtPanel.SetActive(false);
    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(0.8f);
        ClearPanel.SetActive(false);
        StartPanel.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        FadeEffect.SetActive(false);
    }
}