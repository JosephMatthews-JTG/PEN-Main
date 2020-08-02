using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using TMPro;

public class UpgradesPage : MonoBehaviour
{
    public PersistentMainScript game;
    public SaveData data;
    public Achievements ach;
    public StatsPage stats;

    public Text StudCostText;
    public Text StudIncreaseText;
    public Text ClassCostText;
    public Text ClassIncreaseText;
    public Text FLCostText;
    public Text FLIncreaseText;
    //Final Tier
    public Text BTCostText;
    public Text BTIncreaseText;
    //Rage
    public Text BPCostText;
    public Text BPIncreaseText;
    public Text FPCostText;
    public Text FPIncreaseText;
    //Upgrades
    public Text BTRequirmentText;
    public Text BTMultiText;
    //RageUps
    public Text BPRequirmentText;
    public Text BPMultiText;
    public Text FPRequirmentText;
    public Text FPMultiText;
    void Start()
    {
        StudCostText.text = "Cost: " + Methods.NotationMethod(game.data.StudCost, y: "F0") + " Annoyance";
        StudIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.StudIncrease, y: "F2") + " CPS";
        ClassCostText.text = "Cost: " + Methods.NotationMethod(game.data.ClassCost, y: "F0") + " Annoyance";
        ClassIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.ClassIncrease, y: "F2") + " CPS";
        FLCostText.text = "Cost: " + Methods.NotationMethod(game.data.FLCost, y: "F0") + " Annoyance";
        FLIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.FLIncrease, y: "F2") + " CPS";
        //Final Tier
        BTCostText.text = "Cost: " + Methods.NotationMethod(game.data.BTCost, y: "F0") + " Annoyance";
        BTIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BTIncrease, y: "F2") + " CPS";
        //Rage
        BPCostText.text = "Cost: " + Methods.NotationMethod(game.data.BPCost, y: "F0") + " RAGE";
        BPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BPIncrease, y: "F2") + " CPS";
        FPCostText.text = "Cost: " + Methods.NotationMethod(game.data.FPCost, y: "F0") + " RAGE";
        FPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.FPIncrease, y: "F2") + " CPS";
        //Upgrades
        BTRequirmentText.text = "Cost: Reset Banish a Teacher\n(requires at least " + Methods.NotationMethod(game.data.BTRequriement, y: "F0") + " BaT)";
        BTMultiText.text = "BaT Increase Multi\n" + Methods.NotationMethod(game.data.BTIncreaseMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewBTMulti, y: "F2");
        //RageUps
        BPRequirmentText.text = "Cost: Reset Break ALL Pencils\n(requires at least " + Methods.NotationMethod(game.data.BPRequriement, y: "F0") + " BAP)";
        BPMultiText.text = "BAP Cost Multi\n" + Methods.NotationMethod(game.data.BPCostMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewBPMulti, y: "F2");
        FPRequirmentText.text = "Cost: Reset Force Pens\n(requires at least " + Methods.NotationMethod(game.data.FPRequriement, y: "F0") + " FP)";
        FPMultiText.text = "FP Cost Multi\n" + Methods.NotationMethod(game.data.FPCostMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewFPMulti, y: "F2");
    }

    void Update()
    {

    }

    public void BuyUpgrade(string upgradeID)
    {
        switch (upgradeID)
        {
            case "UP1":
                if (game.data.Annoyance >= game.data.StudCost)
                {
                    game.data.CPS += game.data.StudIncrease;
                    game.data.StudIncrease *= 1.07;
                    game.data.Annoyance -= game.data.StudCost;

                    if (game.data.ACDownUnlocked == true)
                    {
                        game.data.StudCost *= 1.07;
                    }
                    else
                        game.data.StudCost *= 1.08;

                    StudCostText.text = "Cost: " + Methods.NotationMethod(game.data.StudCost, y: "F0") + " Annoyance";
                    StudIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.StudIncrease, y: "F2") + " CPS";

                    if (game.data.AutoUnlocked == false)
                    {
                        ach.UnlockAchievement("A4");
                    }
                }
                break;
            case "UP2":
                if (game.data.Annoyance >= game.data.ClassCost)
                {
                    game.data.CPS += game.data.ClassIncrease;
                    game.data.ClassIncrease *= 1.05;
                    game.data.Annoyance -= game.data.ClassCost;

                    if (game.data.ACDownUnlocked == true)
                    {
                        game.data.ClassCost *= 1.07;
                    }
                    else
                        game.data.ClassCost *= 1.08;

                    ClassCostText.text = "Cost: " + Methods.NotationMethod(game.data.ClassCost, y: "F0") + " Annoyance";
                    ClassIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.ClassIncrease, y: "F2") + " CPS";

                    if (game.data.LegalUnlocked == false)
                    {
                        ach.UnlockAchievement("A5");
                    }
                }
                break;
            case "UP3":
                if (game.data.Annoyance >= game.data.FLCost)
                {
                    game.data.CPS += game.data.FLIncrease;
                    game.data.FLIncrease *= 1.05;
                    game.data.Annoyance -= game.data.FLCost;

                    if (game.data.ACDownUnlocked == true)
                    {
                        game.data.FLCost *= 1.07;
                    }
                    else
                        game.data.FLCost *= 1.08;

                    FLCostText.text = "Cost: " + Methods.NotationMethod(game.data.FLCost, y: "F0") + " Annoyance";
                    FLIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.FLIncrease, y: "F2") + " CPS";
                }
                break;
            //Final Tier
            case "UP4":
                if (game.data.Annoyance >= game.data.BTCost)
                {
                    game.data.TotalBT++;
                    game.data.CPS += game.data.BTIncrease;
                    game.data.BTContribution += game.data.BTIncrease;
                    game.data.BTIncrease *= game.data.BTIncreaseMulti;
                    game.data.Annoyance -= game.data.BTCost;

                    if (game.data.ACDownUnlocked == true)
                    {
                        game.data.BTCost *= 1.07;
                    }
                    else
                        game.data.BTCost *= 1.08;

                    game.data.TotalBT++;

                    BTCostText.text = "Cost: " + Methods.NotationMethod(game.data.BTCost, y: "F0") + " Annoyance";
                    BTIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BTIncrease, y: "F2") + " CPS";
                }
                break;
            //Rage
            case "UP5":
                if (game.data.RACChangeUnlocked == false)
                {
                    if (game.data.Rage >= game.data.BPCost)
                    {
                        game.data.TotalBP++;
                        game.data.CPS += game.data.BPIncrease;
                        game.data.BPContribution += game.data.BPIncrease;
                        game.data.BPIncrease *= 1.07;
                        game.data.Rage -= game.data.BPCost;
                        game.data.BPCost *= game.data.BPCostMulti;

                        BPCostText.text = "Cost: " + Methods.NotationMethod(game.data.BPCost, y: "F0") + " RAGE";
                        BPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BPIncrease, y: "F2") + " CPS";
                    }
                }

                if (game.data.RACChangeUnlocked == true)
                {
                    if (game.data.Annoyance >= game.data.BPCost2)
                    {
                        game.data.TotalBP++;
                        game.data.CPS += game.data.BPIncrease;
                        game.data.BPContribution += game.data.BPIncrease;
                        game.data.BPIncrease *= 1.07;
                        game.data.Annoyance -= game.data.BPCost2;
                        game.data.BPCost *= game.data.BPCostMulti;

                        BPCostText.text = "Cost: " + Methods.NotationMethodBD(game.data.BPCost2, y: "F0") + " Annoyance";
                        BPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BPIncrease, y: "F2") + " CPS";
                    }
                }
                break;
            case "UP6":
                if (game.data.Rage >= game.data.FPCost)
                {
                    game.data.TotalFP++;
                    game.data.CPS += game.data.FPIncrease;
                    game.data.FPContribution += game.data.FPIncrease;
                    game.data.FPIncrease *= 1.07;
                    game.data.Rage -= game.data.FPCost;
                    game.data.FPCost *= game.data.FPCostMulti;

                    FPCostText.text = "Cost: " + Methods.NotationMethod(game.data.FPCost, y: "F0") + " RAGE";
                    FPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.FPIncrease, y: "F2") + " CPS";
                }
                break;
            //Upgrades
            case "UP4UP":
                if (game.data.TotalBT >= game.data.BTRequriement)
                {
                    game.data.Annoyance = 0;
                    game.data.BTCost = 1e15;
                    game.data.BTIncrease = 3e14;
                    game.data.TotalBT = 0;
                    game.data.CPS -= game.data.BTContribution;
                    game.data.BTContribution = 0;
                    game.data.BTIncreaseMulti += 0.02;
                    game.data.BTRequriement *= 5;
                    game.data.NewBTMulti += 0.02;
                    BTCostText.text = "Cost: " + Methods.NotationMethod(game.data.BTCost, y: "F0") + " Annoyance";
                    BTIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BTIncrease, y: "F2") + " CPS";
                    BTRequirmentText.text = "Cost: Reset Banish a Teacher\n(requires at least " + Methods.NotationMethod(game.data.BTRequriement, y: "F0") + " BaT)";
                    BTMultiText.text = "BaT Increase Multi\n" + Methods.NotationMethod(game.data.BTIncreaseMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewBTMulti, y: "F2");
                    stats.TotalBTsText.text = "You've Bansished 0 Teachers";
                }
                break;
            //RageUps
            case "UP5UP":
                if (game.data.TotalBP >= game.data.BPRequriement)
                {
                    game.data.Annoyance = 0;
                    game.data.BPCost = 10;
                    game.data.BPIncrease = 1e30;
                    game.data.TotalBP = 0;
                    game.data.CPS -= game.data.BPContribution;
                    game.data.BPContribution = 0;
                    game.data.BPCostMulti -= 0.01;
                    game.data.BPRequriement *= 5;
                    game.data.NewBPMulti -= 0.01;
                    BPCostText.text = "Cost: " + Methods.NotationMethod(game.data.BPCost, y: "F0") + " RAGE";
                    BPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BPIncrease, y: "F2") + " CPS";
                    BPRequirmentText.text = "Cost: Reset Break ALL Pencils\n(requires at least " + Methods.NotationMethod(game.data.BPRequriement, y: "F0") + " BAP)";
                    BPMultiText.text = "BAP Cost Multi\n" + Methods.NotationMethod(game.data.BPCostMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewBPMulti, y: "F2");
                    stats.TotalBPsText.text = "You've Broke 0 Pencils";
                }
                break;
            case "UP6UP":
                if (game.data.TotalFP >= game.data.FPRequriement)
                {
                    game.data.Annoyance = 0;
                    game.data.FPCost = 100;
                    game.data.FPIncrease = 1e55;
                    game.data.TotalFP = 0;
                    game.data.CPS -= game.data.FPContribution;
                    game.data.FPContribution = 0;
                    game.data.FPCostMulti -= 0.01;
                    game.data.FPRequriement *= 5;
                    game.data.NewFPMulti -= 0.01;
                    FPCostText.text = "Cost: " + Methods.NotationMethod(game.data.FPCost, y: "F0") + " RAGE";
                    FPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.FPIncrease, y: "F2") + " CPS";
                    FPRequirmentText.text = "Cost: Reset Force Pens\n(requires at least " + Methods.NotationMethod(game.data.FPRequriement, y: "F0") + " FP)";
                    FPMultiText.text = "FP Cost Multi\n" + Methods.NotationMethod(game.data.FPCostMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewFPMulti, y: "F2");
                    stats.TotalFPsText.text = "You've Made 0 Pens";
                }
                break;
        }
    }
}
