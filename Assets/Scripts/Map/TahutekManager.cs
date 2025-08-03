using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TahutekManager : MonoBehaviour
{
    public static TahutekManager instance;

    public GameObject tahuTekPickupObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetTahuTekPickup()
    {
        if (tahuTekPickupObject != null)
        {
            tahuTekPickupObject.SetActive(true);
        }
    }
}
