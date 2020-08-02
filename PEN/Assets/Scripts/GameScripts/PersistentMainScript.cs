using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class PersistentMainScript : MonoBehaviour
{
    public PersistentMainScript game;
    public SaveData data;
    public Achievements ach;
    public StatsPage stats;

    public int SaveTimer;

    //Navigation
    //Screens
    public GameObject PenScreen;
    public GameObject UpgradesScreen;
    public GameObject AchievementsScreen;
    public GameObject StatsScreen;
    public GameObject RageScreen;
    //PG Buttons
    public GameObject PenPageButton;
    public GameObject UnlockUPs;
    public GameObject OtherTabs;
    public GameObject MoreTabsButton;
    public GameObject BackButton;
    public GameObject MoreTabs;

    //Annoyance
    public Text AnnoyanceText;
    public Text CPSText;

    //RageTexts
    public GameObject RageTextContainer;
    //The Rage Texts are handled in RagePage.cs

    //RagePage
    public GameObject Locked;
    public GameObject Unlocked;

    //UpsPage
    public GameObject BPLocked;
    public GameObject BPUnlocked;
    public GameObject FPLocked;
    public GameObject FPUnlocked;
    public GameObject BPUPLocked;
    public GameObject BPUPUnlocked;
    public GameObject FPUPLocked;
    public GameObject FPUPUnlocked;
    void Start()
    {
        Application.targetFrameRate = 60;
        SaveSystem.LoadPlayer(ref data);
        SaveTimer = 0;

        if (data.NewSave == true)
        {
            stats.FullReset();
            data.NewSave = false;
        }

        if (game.data.Raged >= 1)
        {
            RageTextContainer.SetActive(true);
        }
        else
            RageTextContainer.SetActive(false);

        //Navigation
        //Screens
        PenScreen.SetActive(true);
        UpgradesScreen.SetActive(false);
        AchievementsScreen.SetActive(false);
        StatsScreen.SetActive(false);
        RageScreen.SetActive(false);
        //PG Buttons
        BackButton.SetActive(false);
        MoreTabs.SetActive(false);
        PenPageButton.SetActive(true);
        if (game.data.UpgradesPageUnlocked == true)
        {
            OtherTabs.SetActive(true);
            UnlockUPs.SetActive(false);
        }
        if (game.data.UpgradesPageUnlocked == false)
        {
            OtherTabs.SetActive(false);
        }
        if (game.data.Raged >= 1)
        {
            MoreTabsButton.SetActive(true);
        }
        else
            MoreTabsButton.SetActive(false);
    }

    void Update()
    {

        SaveTimer++;
        if (SaveTimer >= 30)
        {
            SaveSystem.SavePlayer(data);
        }

        //Annoyance
        AnnoyanceText.text = "There is " + Methods.NotationMethodBD(data.Annoyance, y: "F2") + " Annoyance";
        CPSText.text = Methods.NotationMethodBD((data.CPS * data.RageMulti), y: "F2") + " Pen Clicks every second";

        data.Annoyance += (data.CPS * data.RageMulti) * Time.deltaTime;
        data.TotalAnnoyance += (data.CPS * data.RageMulti) * Time.deltaTime;
    }

    //Naviagtion
    public void GoPenPage()
    {
        PenScreen.SetActive(true);
        UpgradesScreen.SetActive(false);
        AchievementsScreen.SetActive(false);
        StatsScreen.SetActive(false);
        RageScreen.SetActive(false);
    }
    public void GoUpPage()
    {
        PenScreen.SetActive(false);
        UpgradesScreen.SetActive(true);
        AchievementsScreen.SetActive(false);
        StatsScreen.SetActive(false);
        RageScreen.SetActive(false);

        if (data.Raged >= 1)
        {
            BPUnlocked.SetActive(true);
            BPLocked.SetActive(false);
            FPUnlocked.SetActive(true);
            FPLocked.SetActive(false);
            BPUnlocked.SetActive(true);
            BPUPLocked.SetActive(false);
            FPUnlocked.SetActive(true);
            FPUPLocked.SetActive(false);
        }
        if (data.Raged == 0)
        {
            BPLocked.SetActive(true);
            FPLocked.SetActive(true);
            BPUPLocked.SetActive(true);
            FPUPLocked.SetActive(true);
        }
    }

    public void GoAchPage()
    {
        PenScreen.SetActive(false);
        UpgradesScreen.SetActive(false);
        AchievementsScreen.SetActive(true);
        ach.OpenAchs();
        StatsScreen.SetActive(false);
        RageScreen.SetActive(false);
    }

    public void GoStatsPage()
    {
        PenScreen.SetActive(false);
        UpgradesScreen.SetActive(false);
        AchievementsScreen.SetActive(false);
        StatsScreen.SetActive(true);
        RageScreen.SetActive(false);
    }

    public void GoRagePage()
    {
        PenScreen.SetActive(false);
        UpgradesScreen.SetActive(false);
        AchievementsScreen.SetActive(false);
        StatsScreen.SetActive(false);
        RageScreen.SetActive(true);

        if (data.Raged == 0)
        {
            if (game.data.Annoyance >= 1e25)
            {
                Locked.SetActive(false);
                Unlocked.SetActive(true);
            }

            if (game.data.Annoyance < 1e25)
            {
                Locked.SetActive(true);
                Unlocked.SetActive(false);
            }
        }
        else
        {
            Locked.SetActive(false);
            Unlocked.SetActive(true);
        }
    }

    public void GoMoreTabs()
    {
        PenPageButton.SetActive(false);
        OtherTabs.SetActive(false);
        MoreTabsButton.SetActive(false);
        MoreTabs.SetActive(true);
        BackButton.SetActive(true);
    }
    public void GoBack()
    {
        PenPageButton.SetActive(true);
        OtherTabs.SetActive(true);
        MoreTabsButton.SetActive(true);
        MoreTabs.SetActive(false);
        BackButton.SetActive(false);
    }
}
