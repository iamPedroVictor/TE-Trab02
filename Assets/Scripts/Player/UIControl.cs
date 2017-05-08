using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class UIControl{
    [UnityEngine.SerializeField]
    private int indexUI;
    [UnityEngine.SerializeField]
    private Slider healthBarSlider;
    [UnityEngine.SerializeField]
    private bool isEnable;

    public void Enable(int index, float lifeMax)
    {
        indexUI = index - 1;
        healthBarSlider = UIManager.instance.healthBars[indexUI];
        isEnable = true;
        healthBarSlider.maxValue = lifeMax;
        
    }

    public void UpdateBar(float life)
    {
        UnityEngine.Debug.Log("Update Life " + indexUI + " to " + life);
        healthBarSlider.value = life;
    }

}
