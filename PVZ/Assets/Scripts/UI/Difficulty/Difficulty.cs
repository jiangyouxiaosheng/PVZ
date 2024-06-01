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
        this.startSun.text = "��ʼ����ֵΪ" + startSun;
        sun = startSun;
        this.startTime.text = "��ƺ�Ͽ�ʼ���ֽ�ʬ��ʱ��Ϊ" + startTime;
        waitTime = startTime;
        ///��ʬѪ��
        if(startZombieHp > 0)
        {
            this.startZombieHp.text = "��ʬѪ������" + startZombieHp;
        }
        else if(startZombieHp ==0)
        {
            this.startZombieHp.gameObject.SetActive(false);
        }
        else
        {
            this.startZombieHp.text = "��ʬѪ���½�" + -startZombieHp;
        }
        zombieHp = startZombieHp;
        ///��ʬ������
        if(startZombieAttack > 0)
        {
            this.startZombieAttack.text = "��ʬ����������" + startZombieAttack;
        }
        else if(startZombieAttack == 0)
        {
            this.startZombieAttack.gameObject.SetActive(false);
        }
        else
        {
            this.startZombieAttack.text = "��ʬ�������½�" + -startZombieAttack;
        }
        zombieAttack = startZombieAttack;
        ///��ʬ�ƶ��ٶ�
        if(startZombieMove > 0)
        {
            this.startZombieMove.text = "��ʬ�ƶ��ٶ������ٷ�֮" + (int)(startZombieMove/0.5f*100);
        }
        else if( startZombieMove == 0)
        {
            this.startZombieMove.gameObject.SetActive(false);
        }
        else
        {
            this.startZombieMove.text = "��ʬ�ƶ��ٶȼ��ٰٷ�֮" + (int)(-startZombieMove/0.5f * 100);
        }
        zombieMove = startZombieMove;
        ///ֲ�﹥����
        if(plantAttack > 0)
        {
            this.startPlantAttack.text = "ֲ�﹥��������" + plantAttack;
        }
        else if( plantAttack == 0)
        {
            this.startPlantAttack.gameObject.SetActive(false);
        }
        else
        {
            this.startPlantAttack.text = "ֲ�﹥�����½�" + -plantAttack;
        }
        this.plantAttack = plantAttack;

        ///ֲ��CD
        if (plantCD > 0)
        {
            this.startPlantCD.text = "ֲ����ȴʱ������"+ plantCD;
        }
        else if(plantCD == 0)
        {
            this.startPlantCD.gameObject.SetActive(false);
        }
        else
        {
            this.startPlantCD.text = "ֲ����ȴʱ���½�" + -plantCD;
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
