using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager _uiManager;
    private float money;
    public float Money => money;
    // Start is called before the first frame update
    void Start()
    {

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
        money++;
        _uiManager.UpdateUI(money);
    }
}
