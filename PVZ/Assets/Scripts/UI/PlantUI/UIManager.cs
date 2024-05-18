using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI sunCountText;




    private void Update()
    {
        sunCountText.text = SunManager.Instance.SunCount().ToString();
    }


}
