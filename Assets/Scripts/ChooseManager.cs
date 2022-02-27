using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseManager : MonoBehaviour
{
    [SerializeField] TextMeshPro leftText, rightText;
    [SerializeField] GameObject leftMoney, rightMoney;
    [SerializeField] Animator rich, poor;
    [SerializeField] private AudioClip clip;
    GameManager gm;
    float funcLeft, funcRight;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        RandomizeChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RandomizeChange(){
        //for left
        switch(Random.Range(0, 2)){
            case 0:
            funcLeft = Random.Range(5, 96);
            leftText.text = funcLeft.ToString() + "%";
                break;
            case 1:
            funcLeft = Random.Range(1, 4);
            leftText.text = funcLeft.ToString() + "X";
                break;
        }
        //for right
        switch(Random.Range(0, 2)){
            case 0:
            funcRight = Random.Range(5, 96); 
            rightText.text = funcRight.ToString() + "%";
                break;
            case 1:
            funcRight = Random.Range(1, 4);
            rightText.text = funcRight.ToString() + "X";
                break;
        }
    }
    public void Triggered(bool isRight){
        if(isRight){
            FindObjectOfType<GameManager>().MoneyChange(funcRight);
            Debug.Log("Chose right side");}
        else {
            FindObjectOfType<GameManager>().MoneyChange(funcLeft);
            Debug.Log("Chose left side");}
        FinalEffect();
    }
    private void FinalEffect(){
        FindObjectOfType<AudioSource>().PlayOneShot(clip);
        leftMoney.SetActive(false);
        rightMoney.SetActive(true);
        rich.SetTrigger("npc");
        poor.SetTrigger("npc");
        leftText.gameObject.SetActive(false);
        rightText.gameObject.SetActive(false);
    }

    private void SendData(float function){
        gm.MoneyChange(function);
    }
}
