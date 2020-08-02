using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using TMPro;

public class Achievements : MonoBehaviour
{ 
    public PersistentMainScript game;
    public SaveData data;
    public StatsPage stats;

    public GameObject Uno;
    public GameObject UnoL;
    public GameObject UnoP;
    public GameObject Big;
    public GameObject BigL;
    public GameObject BigP;
    public GameObject New;
    public GameObject NewL;
    public GameObject NewP;
    public GameObject Auto;
    public GameObject AutoL;
    public GameObject AutoP;
    public GameObject Legal;
    public GameObject LegalL;
    public GameObject LegalP;
    //Row2
    public GameObject Science;
    public GameObject ScienceL;
    public GameObject ScienceP;
    public GameObject Angry;
    public GameObject AngryL;
    public GameObject AngryP;

    //Instructions
    public GameObject InstructPopup;

    //Popups
    public GameObject UnlockSFX;
    public GameObject AutoPop;
    public GameObject LegalPop;
    public GameObject SciencePop;
    public GameObject AngryPop;


    void Start()
    {
        InstructPopup.SetActive(false);
        UnlockSFX.SetActive(false);
    }

    void Update()
    {
        UnlockAchievement("A2");
        UnlockAchievement("A6");
    }

    public void OpenAchs()
    {
        if (game.data.UnoUnlocked == true)
        {
            Uno.SetActive(true);
            UnoL.SetActive(false);
        }
        else
            UnoL.SetActive(true);

        if (game.data.BigUnlocked == true)
        {
            Big.SetActive(true);
            BigL.SetActive(false);
        }
        else
            BigL.SetActive(true);

        if (game.data.NewUnlocked == true)
        {
            New.SetActive(true);
            NewL.SetActive(false);
        }
        else
            NewL.SetActive(true);

        if (game.data.AutoUnlocked == true)
        {
            Auto.SetActive(true);
            AutoL.SetActive(false);
        }
        else
            AutoL.SetActive(true);

        if (game.data.LegalUnlocked == true)
        {
            Legal.SetActive(true);
            LegalL.SetActive(false);
        }
        else
            LegalL.SetActive(true);

        //Row2
        if (game.data.ScienceUnlocked == true)
        {
            Science.SetActive(true);
            ScienceL.SetActive(false);
        }
        else
            ScienceL.SetActive(true);

        if (game.data.AngryUnlocked == true)
        {
            Angry.SetActive(true);
            AngryL.SetActive(false);
        }
        else
            AngryL.SetActive(true);
    }

    public void UnlockAchievement(string AID)
    {
        switch (AID)
        {
            case "A1":
                {
                    game.data.UnoUnlocked = true;
                    game.data.TotalAchievements++;
                    StartCoroutine(DoAchPopup("A1"));
                }
                break;
            case "A2":
                {
                    if (game.data.BigUnlocked == false & game.data.Annoyance >= 10)
                    {
                        game.data.BigUnlocked = true;
                        game.data.TotalAchievements++;
                        StartCoroutine(DoAchPopup("A2"));
                    }
                }
                break;
            case "A3":
                {
                    game.data.NewUnlocked = true;
                    game.data.TotalAchievements++;
                    StartCoroutine(DoAchPopup("A3"));
                }
                break;
            case "A4":
                {
                    game.data.AutoUnlocked = true;
                    game.data.TotalAchievements++;
                    StartCoroutine(DoAchPopup("A4"));
                }
                break;
            case "A5":
                {
                    game.data.LegalUnlocked = true;
                    game.data.TotalAchievements++;
                    StartCoroutine(DoAchPopup("A5"));
                }
                break;

            //Tier2
            case "A6":
                {
                    if (game.data.ScienceUnlocked == false & game.data.Annoyance >= 1e6)
                    {
                        game.data.ScienceUnlocked = true;
                        game.data.TotalAchievements++;
                        StartCoroutine(DoAchPopup("A6"));
                    }
                }
                break;
            case "A7":
                {
                    game.data.AngryUnlocked = true;
                    game.data.TotalAchievements++;
                    StartCoroutine(DoAchPopup("A7"));
                }
                break;
        }
    }

    IEnumerator DoAchPopup(string AID)
    {
        switch (AID)
        {
            case "A1":
                StartCoroutine(DoSFX());
                UnoP.SetActive(true);
                yield return new WaitForSeconds(5);
                UnoP.SetActive(false);
                break;
            case "A2":
                StartCoroutine(DoSFX());
                BigP.SetActive(true);
                yield return new WaitForSeconds(5);
                BigP.SetActive(false);
                break;
            case "A3":
                StartCoroutine(DoSFX());
                NewP.SetActive(true);
                yield return new WaitForSeconds(5);
                NewP.SetActive(false);
                break;
            case "A4":
                StartCoroutine(DoSFX());
                AutoP.SetActive(true);
                yield return new WaitForSeconds(5);
                AutoP.SetActive(false);
                break;
            case "A5":
                StartCoroutine(DoSFX());
                LegalP.SetActive(true);
                yield return new WaitForSeconds(5);
                LegalP.SetActive(false);
                break;
            //Row2
            case "A6":
                StartCoroutine(DoSFX());
                ScienceP.SetActive(true);
                yield return new WaitForSeconds(5);
                ScienceP.SetActive(false);
                break;
            case "A7":
                StartCoroutine(DoSFX());
                AngryP.SetActive(true);
                yield return new WaitForSeconds(5);
                AngryP.SetActive(false);
                break;
        }
    }

    public void OpenInstructPopup()
    {
        InstructPopup.SetActive(true);
    }

    public void CloseInstructPopup()
    {
        InstructPopup.SetActive(false);
    }

    public void OpenPopup(string PID)
    {
        switch (PID)
        {
            case "P4":
                AutoPop.SetActive(true);
                break;
            case "P5":
                LegalPop.SetActive(true);
                break;
            case "P6":
                SciencePop.SetActive(true);
                break;
            case "P7":
                AngryPop.SetActive(true);
                break;
        }
    }

    public void ClosePopup(string PID)
    {
        switch (PID)
        {
            case "P4":
                AutoPop.SetActive(false);
                break;
            case "P5":
                LegalPop.SetActive(false);
                break;
            case "P6":
                SciencePop.SetActive(false);
                break;
            case "P7":
                AngryPop.SetActive(false);
                break;
        }
    }

    IEnumerator DoSFX()
    {
        stats.Music.SetActive(false);
        UnlockSFX.SetActive(true);
        yield return new WaitForSeconds(2);
        UnlockSFX.SetActive(false);
        stats.Music.SetActive(true);
    }
}
