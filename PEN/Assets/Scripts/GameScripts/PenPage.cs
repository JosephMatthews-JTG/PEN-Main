using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class PenPage : MonoBehaviour
{
    public PersistentMainScript game;
    public SaveData data;
    public Achievements ach;


    void Start()
    {
    }

    void Update()
    {
    }

    public void Click()
    {
        game.data.Annoyance += 1;
        game.data.TotalAnnoyance += 1;

        if (!game.data.UnoUnlocked)
        {
            ach.UnlockAchievement("A1");
        }

        if (!game.data.UpgradesPageUnlocked)
        {
            if (game.data.Annoyance >= 20)
            {
                game.UnlockUPs.SetActive(true);
            }
        }
    }

    public void UnlockUpsPage()
    {
        if (game.data.Annoyance >= 20)
        {
            game.UnlockUPs.SetActive(false);
            game.data.Annoyance -= 20;
            game.OtherTabs.SetActive(true);
            game.data.UpgradesPageUnlocked = true;
            ach.UnlockAchievement("A3");
        }
    }
}
