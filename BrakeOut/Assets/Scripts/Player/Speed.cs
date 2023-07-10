using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public Options options;
    Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider> ();
        slider.onValueChanged.AddListener(delegate { ControlChanges(); });
    }

    public void ControlChanges() 
    {
        options.ChangeSpeed((int)(slider.value));
    }
   
}
