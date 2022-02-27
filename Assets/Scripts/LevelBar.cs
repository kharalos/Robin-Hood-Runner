using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class LevelBar : MonoBehaviour
{
    Slider levelSlider;
    TextMeshProUGUI title;
    private Dictionary<int, string> levels = new Dictionary<int, string>();
    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        levelSlider = GetComponentInChildren<Slider>();
        title = GetComponentInChildren<TextMeshProUGUI>();
        currentLevel = 0;
        levels = new Dictionary<int, string>();
        levels.Add(0, "Noob");
        levels.Add(1, "Veteran");
        levels.Add(2, "Ranger");
        levels.Add(3, "Pro");
        levels.Add(4, "Hero");
        levels.Add(5, "Liberator");
        levels.Add(6, "Chosen One");
        levels.Add(7, "Ascended");
        levels.Add(8, "Immortal");
        levels.Add(9, "Godlike");
        levelSlider.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Level Treshholds: 10|Noob, 20|Veteran, 30|Pro, 40|Hero, 50|Liberator, 60|Chosen One 
    public void UpdateLevelBar(float xp){
        levelSlider.DOValue(xp, 0.2f, false);
        currentLevel = ((int)Mathf.Floor(xp / 10));
        title.text = levels[currentLevel];
    }
    private void LateUpdate() {
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
}
