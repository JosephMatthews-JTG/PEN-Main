using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class RagePage : MonoBehaviour
{
    public PersistentMainScript game;
    public SaveData data;
    public Achievements ach;
    public UpgradesPage ups;
    public StatsPage stats;

    public Text RageMultiText;
    public Text RageText;
    public Text RageGainText;

    //Upgrades
    public int CurrentUp;

    public Text RDoubleCostText;
    public Text ACDownText;
    public Text RGFormulaText;
    public Text SUResetText;
    public Text RACChangeText;

    public GameObject RDouble;
    public GameObject ACCostDown;
    public GameObject RGFormula;
    public GameObject SUReset;
    public GameObject RACChange;

    //Cutscene
    public GameObject Persistent;
    public GameObject RageFlash;
    public GameObject RagePopup;


    void Start()
    {
        RageMultiText.text = "x" + Methods.NotationMethodBD(game.data.RageMulti, y: "F2");
        RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";
        RageGainText.text = "Gain " + Methods.NotationMethodBD(game.data.RageGained, y: "F0") + " Rage (x" + Methods.NotationMethod(game.data.RDouble, y: "F0") + ")";

        //Upgrades
        CurrentUp = 1;
        RDoubleCostText.text = "Cost: " + Methods.NotationMethod(game.data.RDoubleCost, y: "F0") + " RAGE";

        !ACDownUnlocked ? ACDownText.text = "Cost: 15 RAGE" : ACDownText.text = "UNLOCKED!";
        !RGFormulaUnlocked ? RGFormulaText.text = "Cost: 100 RAGE" : RGFormulaText.text = "UNLOCKED!";
        !SUResetUnlocked ? SUResetText.text = "Cost: 5e6 RAGE" : SUResetText.text = "UNLOCKED!";
        !RACChangeUnlocked ? RACChangeText.text = "Cost: 1e15 RAGE" : RACChangeText.text = "UNLOCKED!";
    }

    void Update()
    {
        RageGainText.text = "Gain " + Methods.NotationMethodBD(game.data.RageGained, y: "F0") + " Rage (x" + Methods.NotationMethod(game.data.RDouble, y: "F0") + ")";
        
        if (game.data.RGFormulaUnlocked == true)
        {
            game.data.RageGained = Floor(600 * Sqrt(game.data.Annoyance / 1e30));
        }
        else
           game.data.RageGained = Floor(390 * Sqrt(game.data.Annoyance / 1e30));
    }

    public void RageReset()
    {
        game.data.Annoyance = 0;
        game.data.CPS = 0;
        //UpsPage
        game.data.StudCost = 20;
        game.data.StudIncrease = 2;
        game.data.ClassCost = 500;
        game.data.ClassIncrease = 100;
        game.data.FLCost = 1e6;
        game.data.FLIncrease = 210000;
        ups.StudCostText.text = $"Cost: {Methods.NotationMethod(game.data.StudCost, y: F0)} Annoyance";
        ups.StudIncreaseText.text = $"Gain: {Methods.NotationMethod(game.data.StudIncrease, y: F2)} CPS";
        ups.ClassCostText.text = $"Cost: {Methods.NotationMethod(game.data.ClassCost, y: F0)} Annoyance";
        ups.ClassIncreaseText.text = $"Gain: {Methods.NotationMethod(game.data.ClassIncrease, y: F2)} CPS";
        ups.FLCostText.text = $"Cost: {Methods.NotationMethod(game.data.FLCost, y: F0)} Annoyance";
        ups.FLIncreaseText.text = $"Gain: {Methods.NotationMethod(game.data.FLIncrease, y: F2)} CPS";
        //Final Tier
        game.data.BTCost = 1e15;
        game.data.BTIncrease = 3e14;
        game.data.BTIncreaseMulti = 1.07;
        game.data.TotalBT = 0;
        game.data.BTContribution = 0;
        ups.BTCostText.text = "Cost: " + Methods.NotationMethod(game.data.BTCost, y: "F0") + " Annoyance";
        ups.BTIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BTIncrease, y: "F2") + " CPS";
        //Upgrades
        if (game.data.SUResetUnlocked == false)
        {
            game.data.BTIncreaseMulti = 1.07;
            game.data.BTRequriement = 50;
            game.data.NewBTMulti = 1.09;
            ups.BTRequirmentText.text = "Banish the Principal\n(requires at least " + Methods.NotationMethod(game.data.BPRequriement, y: "F0") + " BaT)";
            ups.BTMultiText.text = "BaT Increase Multi\n" + Methods.NotationMethod(game.data.BTIncreaseMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewBTMulti, y: "F2");
        }

        //Rage
        game.data.Raged++;
        game.data.Rage += (game.data.RageGained * game.data.RDouble);
        game.data.RageMulti = (game.data.RageMulti *= 0.02) + 1;
        game.data.RageGained = 0;

        RageMultiText.text = "x" + Methods.NotationMethodBD(game.data.RageMulti, y: "F2");
        RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";
        RageGainText.text = "Gain " + Methods.NotationMethodBD(game.data.RageGained, y: "F0") + " Rage (x" + Methods.NotationMethod(game.data.RDouble, y: "F0") + ")";

        //Achs
        if (game.data.AngryUnlocked == false)
        {
            ach.UnlockAchievement("A7");
        }

        //Stats
        stats.TotalBTsText.text = "You've Bansished 0 Teachers";

        //Persistent
        game.MoreTabsButton.SetActive(true);
        game.RageTextContainer.SetActive(true);

        StartCoroutine(DoRageCutsceen());
    }

    IEnumerator DoRageCutsceen()
    {
        Persistent.SetActive(false);
        game.RageScreen.SetActive(false);
        RageFlash.SetActive(true);
        yield return new WaitForSeconds(1);
        RagePopup.SetActive(true);
        yield return new WaitForSeconds(5);
        RagePopup.SetActive(false);
        RageFlash.SetActive(false);
        Persistent.SetActive(true);
        game.RageScreen.SetActive(true);
    }

    public void BuyUpgrade(string upgradeID)
    {
        switch (upgradeID)
        {
            case "RUP1":
                if (game.data.Rage >= game.data.RDoubleCost)
                {
                    game.data.RDouble *= 2;
                    game.data.Rage -= game.data.RDoubleCost;
                    game.data.RDoubleCost *= 10;
                    RDoubleCostText.text = "Cost: " + Methods.NotationMethod(game.data.RDoubleCost, y: "F0") + " RAGE";
                    RageGainText.text = "Gain " + Methods.NotationMethodBD(game.data.RageGained, y: "F0") + " Rage (x" + Methods.NotationMethod(game.data.RDouble, y: "F0") + ")";
                    RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";
                }
                break;
            case "RUP2":
                if (game.data.Rage >= 15)
                {
                    game.data.Rage -= 15;
                    game.data.ACDownUnlocked = true;
                    ACDownText.text = "UNLOCKED!";
                    RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";
                }
                break;
            case "RUP3":
                if (game.data.Rage >= 100)
                {
                    game.data.Rage -= 100;
                    game.data.RGFormulaUnlocked = true;
                    RGFormulaText.text = "UNLOCKED!";
                    RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";
                }
                break;
            case "RUP4":
                if (game.data.Rage >= 5e6)
                {
                    game.data.Rage -= 5e6;
                    game.data.SUResetUnlocked = true;
                    SUResetText.text = "UNLOCKED!";
                    RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";
                }
                break;
            case "RUP5":
                if (game.data.Rage >= 1e15)
                {
                    game.data.Rage -= 1e15;
                    game.data.RACChangeUnlocked = true;
                    RACChangeText.text = "UNLOCKED!";
                    RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";

                    game.data.CPS -= game.data.BPContribution;
                    game.data.TotalBP = 0;
                    game.data.BPCost2 = 5.9e26;
                    game.data.BPIncrease = 1e30;
                    game.data.BPContribution = 0;


                    ups.BPCostText.text = "Cost: " + Methods.NotationMethodBD(game.data.BPCost2, y: "F0") + " Annoyance";
                    ups.BPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BPIncrease, y: "F2") + " CPS";
                }
                break;
        }
    }

    public void NextUp()
    {
        if (CurrentUp == 4)
        {
            RACChange.SetActive(true);
            SUReset.SetActive(false);
            CurrentUp = 5;
        }
        if (CurrentUp == 3)
        {
            SUReset.SetActive(true);
            RGFormula.SetActive(false);
            CurrentUp = 4;
        }
        if (CurrentUp == 2)
        {
            ACCostDown.SetActive(false);
            RGFormula.SetActive(true);
            CurrentUp = 3;
        }
        if (CurrentUp == 1)
        {
            RDouble.SetActive(false);
            ACCostDown.SetActive(true);
            CurrentUp = 2;
        }
    }

    public void PrevUp()
    {
        if (CurrentUp == 2)
        {
            ACCostDown.SetActive(false);
            RDouble.SetActive(true);
            CurrentUp = 1;
        }

        if (CurrentUp == 3)
        {
            RGFormula.SetActive(false);
            ACCostDown.SetActive(true);
            CurrentUp = 2;
        }

        if (CurrentUp == 4)
        {
            SUReset.SetActive(false);
            RGFormula.SetActive(true);
            CurrentUp = 3;
        }

        if (CurrentUp == 5)
        {
            RACChange.SetActive(false);
            SUReset.SetActive(true);
            CurrentUp = 4;
        }
    }
}
