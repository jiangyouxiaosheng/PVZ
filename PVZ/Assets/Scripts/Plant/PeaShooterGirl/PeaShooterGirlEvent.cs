using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterGirlEvent : MonoBehaviour
{
    private PeaShooterGirl _peaShooterGirl=>GetComponentInParent<PeaShooterGirl>();


    public void Shoot()
    {
        _peaShooterGirl.Shoot();
    }
}
