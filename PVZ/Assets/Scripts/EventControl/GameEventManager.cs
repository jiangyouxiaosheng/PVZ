using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameEventManager : MonoBehaviour
{
    public Transform plants;
    public GameObject eventPanl;
    public Image eventIamge;
    public Text eventTextTile;
    public Text eventText;

    public List<EventData_SO> imageList = new List<EventData_SO>();
    public PlantDataList_SO plantDataList_SO;
    public float eventChangeTime;
    private float currenteventChangeTime;
    private int eventNum;
    private int eventChangedNum;

    int maxEventNum = 36;

    public ZombieData_SO zombieData_SO;

    private void Awake()
    {
       currenteventChangeTime = eventChangeTime;
    }

    private void Start()
    {
        eventNum = 0;
        eventChangedNum = 0;
    }

    private void Update()
    {

        switch (eventNum)
        {
            case 7:
                eventChangedNum = 3;
                break;
            case 5:
                ZombieManager.Instance.normalZombieTime -= 0.5f;
                ZombieManager.Instance.zombiesCurrentLastTime += 1f;
                break;
            default:
                break;
        }
        currenteventChangeTime -= Time.deltaTime;
        if (currenteventChangeTime <= 0)
        {
            eventPanl.SetActive(true);
            Time.timeScale = 0;

            switch (eventChangedNum)
            {
                case 0:
                    GameStart();
                    eventChangeTime = 30;
                    eventChangedNum = 1;
                    break;
                case 1:
                    News();
                    eventChangeTime = 20;
                    eventChangedNum = 2;
                    break;
                case 2:
                    ZombieIsComingStart();
                    eventChangeTime = Random.Range(20, 30);
                    eventChangedNum = Random.Range(21, maxEventNum);
                    break;
                case 3:
                    JustLife();
                    break;
                case 21:
                    KillAllZombie();
                    break;
                case 22:
                    AddZombie();
                    break;
                case 23:
                    ZombieMoveAdd();
                    break;
                case 24:
                    ZombieMoveDown();
                    break;
                case 25:
                    ZombieAttackDown();
                    break;
                case 26:
                    ZombieAttackUp();
                    break;
                case 27:
                    NiceDay();
                    break;
                case 28:
                    PlantAttackUp();
                    break;
                case 29:
                    ZombieIsComingTimeAdd();
                    break;
                case 30:
                    NormalEvent();
                    break;
                case 31:
                    LostFreeSun();
                    break;
                    case 32:
                    ZombieHpUp();
                    break;
                case 33:
                    NormalEvent2();
                    break;
                case 34:
                    NormalEvent3();
                    break;
                case 35:
                    FuckingLife();
                    break;

                default:
                    EventChang();
                    break;
            }
            currenteventChangeTime = eventChangeTime;
        }


    }
    void EventChang()
    {
        eventChangeTime = Random.Range(20, 30);
        eventChangedNum = Random.Range(21, maxEventNum);
    }
    void EventImage(int num)
    {
        eventIamge.sprite = imageList[num].eventImage;
        eventTextTile.text = imageList[num].eventTitle;
        eventText.text = imageList[num].eventText;
        eventNum++;
    }
    void GameStart()
    {
        EventImage(0);
        ZombieManager.Instance.zombieStart = true;
    }
    void News()
    {
        EventImage(1);
    }

    void ZombieIsComingStart()
    {
        EventImage(2);
    }
    void KillAllZombie()
    {
        EventImage(3);
        ZombieManager.Instance.AllZombieDamage();
    }

    void AddZombie()
    {
        EventImage(4);
        EventChang();
        ZombieManager.Instance.isZombiesComing = true;
        ZombieManager.Instance.zombiesCurrentLastTime += 5;
    }
    void ZombieMoveAdd()
    {
        EventImage(5);
        EventChang();
        ZombieManager.Instance.ZombieData_SO.zombieMoveSpeed += 0.1f;
    }

    void ZombieMoveDown()
    {
        EventImage(6);
        EventChang();
        ZombieManager.Instance.ZombieData_SO.zombieMoveSpeed -= 0.1f;
    }
    void ZombieAttackDown()
    {
        EventImage(7);
        EventChang();
        ZombieManager.Instance.ZombieData_SO.zombieAttack += 3;
    }
    void ZombieAttackUp()
    {
        EventImage(8);
        EventChang();
        ZombieManager.Instance.ZombieData_SO.zombieAttack -= 3;
    }
    void NiceDay()
    {
        EventImage(9);
        EventChang();
        SunManager.Instance.SunAdd(Random.Range(100, 500));
    }
    void PlantAttackUp()
    {
        EventImage(10);
        EventChang();
        plantDataList_SO.PlantAttackAdd(Random.Range(1,5));
    }
    void ZombieIsComingTimeAdd()
    {
        EventImage(11);
        EventChang();
        ZombieManager.Instance.zombiesCurrentLastTime += 5f;
    }
   void NormalEvent()
    {
        EventImage(12);
        EventChang();
    }
    void JustLife()
    {
        EventImage(13);
        EventChang();
        ZombieManager.Instance.zombiesCurrentLastTime += 5f;
        ZombieManager.Instance.normalZombieTime -= 1f;
        SunManager.Instance.createSunTime += 0.5f;
    }

    void LostFreeSun()
    {
        EventImage(14);
        EventChang();
        SunManager.Instance.dayIsDay = false;
        StartCoroutine(WaitFreeSun());
    }
    void ZombieHpUp()
    {
        EventImage(15);
        EventChang();
        zombieData_SO.zombieHp += 50;
        ZombieManager.Instance.zombiesCurrentLastTime -= 2f;
    }
    void NormalEvent2()
    {
        EventImage(16);
        EventChang();
    }
    void NormalEvent3()
    {
        EventImage(17);
        EventChang();
    }
    void FuckingLife()
    {
        EventImage(18);
        EventChang();
        SunManager.Instance.SunDown(Random.Range(50, 200));
    }

    public void CloseWindow()
    {
        Time.timeScale = 1;
        eventPanl.SetActive(false);
    }
    IEnumerator WaitFreeSun()
    {
        yield return new WaitForSeconds(30f);
        SunManager.Instance.dayIsDay = true;
    }
}
