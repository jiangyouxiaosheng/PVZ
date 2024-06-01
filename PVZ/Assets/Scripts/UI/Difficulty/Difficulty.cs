using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    //public int startSun;
    //public int startZombieHp;
    //public int startZombieAttack;
    //public int startZombieMove;
    //public int startPlantAttack;
    public Text startSun;
    private int sun;
    public Text startTime;
    private float waitTime;
    public Text startZombieHp;
    private int zombieHp; 
    public Text startZombieAttack;
    private int zombieAttack;
    public Text startZombieMove;
    private float zombieMove;
    public Text startPlantAttack;
    private int plantAttack;
    public Text startPlantCD;
    private float plantCD;
    public PlantDataList_SO plantDataList_SO;


    private void Start()
    {
        
    }
  
    public void Infomation(int startSun,float startTime,int startZombieHp,int startZombieAttack,float startZombieMove,int plantAttack,float plantCD)
    {
        this.startSun.text = "初始阳光值为" + startSun;
        sun = startSun;
        this.startTime.text = "草坪上开始出现僵尸得时间为" + startTime;
        waitTime = startTime;
        ///僵尸血量
        if(startZombieHp > 0)
        {
            this.startZombieHp.text = "僵尸血量上升" + startZombieHp;
        }
        else if(startZombieHp ==0)
        {
            this.startZombieHp.gameObject.SetActive(false);
        }
        else
        {
            this.startZombieHp.text = "僵尸血量下降" + -startZombieHp;
        }
        zombieHp = startZombieHp;
        ///僵尸攻击力
        if(startZombieAttack > 0)
        {
            this.startZombieAttack.text = "僵尸攻击力上升" + startZombieAttack;
        }
        else if(startZombieAttack == 0)
        {
            this.startZombieAttack.gameObject.SetActive(false);
        }
        else
        {
            this.startZombieAttack.text = "僵尸攻击力下降" + -startZombieAttack;
        }
        zombieAttack = startZombieAttack;
        ///僵尸移动速度
        if(startZombieMove > 0)
        {
            this.startZombieMove.text = "僵尸移动速度上升百分之" + (int)(startZombieMove/0.5f*100);
        }
        else if( startZombieMove == 0)
        {
            this.startZombieMove.gameObject.SetActive(false);
        }
        else
        {
            this.startZombieMove.text = "僵尸移动速度减少百分之" + (int)(-startZombieMove/0.5f * 100);
        }
        zombieMove = startZombieMove;
        ///植物攻击力
        if(plantAttack > 0)
        {
            this.startPlantAttack.text = "植物攻击力上升" + plantAttack;
        }
        else if( plantAttack == 0)
        {
            this.startPlantAttack.gameObject.SetActive(false);
        }
        else
        {
            this.startPlantAttack.text = "植物攻击力下降" + -plantAttack;
        }
        this.plantAttack = plantAttack;

        ///植物CD
        if (plantCD > 0)
        {
            this.startPlantCD.text = "植物冷却时间增加"+ plantCD;
        }
        else if(plantCD == 0)
        {
            this.startPlantCD.gameObject.SetActive(false);
        }
        else
        {
            this.startPlantCD.text = "植物冷却时间下降" + -plantCD;
        }
        this.plantCD = plantCD;

    }

 
    public void ChlickStart()
    {
        SunManager.Instance.SunSet(sun);

        ZombieManager.Instance.zombieStartTime = waitTime;
        EventHandler.GameEventTime(waitTime);

        ZombieManager.Instance.ZombieData_SO.zombieHp += zombieHp;

        ZombieManager.Instance.ZombieData_SO.zombieAttack += zombieAttack;

        ZombieManager.Instance.ZombieData_SO.zombieMoveSpeed += zombieMove;

       plantDataList_SO.PlantAttackAdd(this.plantAttack);

       plantDataList_SO.PlantCDAdd(this.plantCD);

        EventHandler.GameStartCameraMove();
        EventHandler.DiffficultyChooseEnd();
    }
}
