using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;

[Serializable]
public class SaveData
{
    //Persistent
    public BigDouble TotalAnnoyance;
    public BigDouble Annoyance;
    public BigDouble CPS;

    public bool UpgradesPageUnlocked;
    public bool NewSave;

    //UpsPage
    public double StudCost;
    public double StudIncrease;
    public double ClassCost;
    public double ClassIncrease;
    public double FLCost;
    public double FLIncrease;
    //Final Tier
    public double BTCost;
    public double BTIncrease;
    public double BTIncreaseMulti;
    public double TotalBT;
    public double BTContribution;
    //Rage
    public double TotalBP;
    public double BPCost;
    public BigDouble BPCost2;
    public double BPCostMulti;
    public double BPIncrease;
    public double BPContribution;
    public double TotalFP;
    public double FPCost;
    public double FPCostMulti;
    public double FPIncrease;
    public double FPContribution;
    //Upgrades
    public double BTRequriement;
    public double NewBTMulti;
    //RageUps
    public double BPRequriement;
    public double NewBPMulti;
    public double FPRequriement;
    public double NewFPMulti;

    //RagePage
    public double Raged;
    public BigDouble Rage;
    public BigDouble RageMulti;
    public BigDouble RageGained;
    //Upgrades
    public double RDoubleCost;
    public float RDouble;

    public bool ACDownUnlocked;
    public bool RGFormulaUnlocked;
    public bool SUResetUnlocked;
    public bool RACChangeUnlocked;

    //Achievements;
    public int TotalAchievements;
    public bool UnoUnlocked;
    public bool BigUnlocked;
    public bool NewUnlocked;
    public bool AutoUnlocked;
    public bool LegalUnlocked;
    //Row Two
    public bool ScienceUnlocked;
    public bool AngryUnlocked;

    public SaveData()
    {
        UpgradesPageUnlocked = false;
        NewSave = true;

        TotalAnnoyance = 0;
        Annoyance = 0;
        CPS = 0;
        //UpsPage
        StudCost = 20;
        StudIncrease = 2;
        ClassCost = 500;
        ClassIncrease = 100;
        FLCost = 1e6;
        FLIncrease = 210000;
        //Final Tier
        BTCost = 1e15;
        BTIncrease = 3e14;
        BTIncreaseMulti = 1.07;
        TotalBT = 0;
        BTContribution = 0;
        //Rage
        TotalBP = 0;
        BPCost = 10;
        BPCost2 = 5.9e26;
        BPCostMulti = 1.09;
        BPIncrease = 1e30;
        BPContribution = 0;
        TotalFP = 0;
        FPCost = 100;
        FPCostMulti = 1.09;
        FPIncrease = 1e55;
        FPContribution = 0;
        //Upgrades
        BTRequriement = 50;
        NewBTMulti = 1.09;
        //RageUps
        BPRequriement = 50;
        NewBPMulti = 1.08;
        FPRequriement = 50;
        NewFPMulti = 1.08;

        //RagePage
        Raged = 0;
        Rage = 0;
        RageMulti = 1.00;
        RageGained = 0;
        //Upgrades
        RDoubleCost = 1;
        RDouble = 1;
        ACDownUnlocked = false;
        RGFormulaUnlocked = false;
        SUResetUnlocked = false;
        RACChangeUnlocked = false;

        //Achievements;
        TotalAchievements = 0;
        UnoUnlocked = false;
        BigUnlocked = false;
        NewUnlocked = false;
        AutoUnlocked = false;
        LegalUnlocked = false;
        ScienceUnlocked = false;
        AngryUnlocked = false;
    }
}
