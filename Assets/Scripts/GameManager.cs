using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager _uiManager;
    [SerializeField] private LevelBar levelBar;
    private float money;
    public float Money => money;
    private float xp;
    public float GetXp(){
        return xp;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        money = 0;
        xp = 0;
        _uiManager = GetComponentInChildren<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GameInitializer(){
        money = 0;
    }
    public void RunStarted(){
        _uiManager.HideStartHUD();
    }
    public void CollectedMoney(){
        money += 10;
        xp++;
        _uiManager.UpdateUI(money);
        levelBar.UpdateLevelBar(xp);
    }
    public void MoneyChange(float function){
        if(function < 5)
            money *= function;
        else
            money *= (function/100);
        money = (int)money;
        if(money < 0) money = 0;
        _uiManager.UpdateUI(money);
        xp += 5;
        levelBar.UpdateLevelBar(xp);
    }
    public void Finish(){
        FindObjectOfType<CharacterBehaviour>().StopRun();
    }

    public void GameOver(int multiplier){
        _uiManager.EndMenu(money * multiplier);
    }
}
