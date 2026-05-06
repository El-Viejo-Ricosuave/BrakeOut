using UnityEngine;
using UnityEngine.UI;

public class SettingUIAdapter : MonoBehaviour
{
    public Options options_SO;
    public Slider sliderSpeed;
    public Slider sliderPlayer;

    void Start()
    {
        if (options_SO != null)
        {
            if (sliderSpeed != null)
            {
                sliderSpeed.value = options_SO.AmmoSpeed;
            }

            if (sliderPlayer != null)
            {
                sliderPlayer.value = options_SO.PlayerSpeed;
            }
        }
    }
}