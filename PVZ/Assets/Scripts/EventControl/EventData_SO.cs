using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EventData_SO", menuName = "Event/EventData")]
public class EventData_SO : ScriptableObject
{
    public string eventTitle;
    public string eventText;
    public Sprite eventImage;
}
