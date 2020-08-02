using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using UnityEngine.UI;

public class StatsPage : MonoBehaviour
{
    public PersistentMainScript game;
    public SaveData data;
    public UpgradesPage ups;
    public RagePage rage;

    public Text TotalAnnoyanceText;
    public Text RagedText;
    public Text TotalBTsText;
    public Text TotalBPsText;
    public Text TotalFPsText;
    public Text TotalAchsText;

    public GameObject Music;
    public bool MusicToggle;

    void Start()
    {
        TotalAnnoyanceText.text = "You've Annoyed " + Methods.NotationMethodBD(game.data.TotalAnnoyance, y: "F0") + " Total People";
        RagedText.text = "You've RAGED " + Methods.NotationMethod(game.data.Raged, y: "F0") + " Times";
        TotalBTsText.text = "You've Bansished " + Methods.NotationMethod(game.data.TotalBT, y: "F0") + " Teachers";
        TotalBPsText.text = "You've Broke " + Methods.NotationMethod(game.data.TotalBP, y: "F0") + " Pencils";
        TotalFPsText.text = "You've Made " + Methods.NotationMethod(game.data.TotalFP, y: "F0") + " Pens";
        TotalAchsText.text = "You've gained a total of " + game.data.TotalAchievements.ToString("F2") + " Pointless Achievements";

        Music.SetActive(true);
        MusicToggle = true;
    }

    void Update()
    {
        TotalAnnoyanceText.text = "You've Annoyed " + Methods.NotationMethodBD(game.data.TotalAnnoyance, y: "F0") + " Total People";
        RagedText.text = "You've RAGED " + Methods.NotationMethod(game.data.Raged, y: "F0") + " Times";
        TotalBTsText.text = "You've Bansished " + Methods.NotationMethod(game.data.TotalBT, y: "F0") + " Teachers";
        TotalBPsText.text = "You've Broke " + Methods.NotationMethod(game.data.TotalBP, y: "F0") + " Pencils";
        TotalFPsText.text = "You've Made " + Methods.NotationMethod(game.data.TotalFP, y: "F0") + " Pens";
        TotalAchsText.text = "You've gained a total of " + game.data.TotalAchievements.ToString("F2") + " Pointless Achievements";
    }

    public void FullReset()
    {
        game.data = new SaveData();

        game.PenScreen.SetActive(true);
        game.UpgradesScreen.SetActive(false);
        game.AchievementsScreen.SetActive(false);
        game.StatsScreen.SetActive(false);
        game.RageScreen.SetActive(false);

        game.OtherTabs.SetActive(false);
        game.MoreTabs.SetActive(false);
        game.MoreTabsButton.SetActive(false);

        //Upgrades
        ups.StudCostText.text = "Cost: " + Methods.NotationMethod(game.data.StudCost, y: "F0") + " Annoyance";
        ups.StudIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.StudIncrease, y: "F2") + " CPS";
        ups.ClassCostText.text = "Cost: " + Methods.NotationMethod(game.data.ClassCost, y: "F0") + " Annoyance";
        ups.ClassIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.ClassIncrease, y: "F2") + " CPS";
        ups.FLCostText.text = "Cost: " + Methods.NotationMethod(game.data.FLCost, y: "F0") + " Annoyance";
        ups.FLIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.FLIncrease, y: "F2") + " CPS";
        //Final Tier
        ups.BTCostText.text = "Cost: " + Methods.NotationMethod(game.data.BTCost, y: "F0") + " Annoyance";
        ups.BTIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BTIncrease, y: "F2") + " CPS";
        //Rage
        ups.BPCostText.text = "Cost: " + Methods.NotationMethod(game.data.BPCost, y: "F0") + " RAGE";
        ups.BPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.BPIncrease, y: "F2") + " CPS";
        ups.FPCostText.text = "Cost: " + Methods.NotationMethod(game.data.FPCost, y: "F0") + " RAGE";
        ups.FPIncreaseText.text = "Gain: " + Methods.NotationMethod(game.data.FPIncrease, y: "F2") + " CPS";
        //Upgrades
        ups.BTRequirmentText.text = "Cost: Reset Banish a Teacher\n(requires at least " + Methods.NotationMethod(game.data.BTRequriement, y: "F0") + " BaT)";
        ups.BTMultiText.text = "BaT Increase Multi\n" + Methods.NotationMethod(game.data.BTIncreaseMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewBTMulti, y: "F2");
        //RageUps
        ups.BPRequirmentText.text = "Cost: Reset Break ALL Pencils\n(requires at least " + Methods.NotationMethod(game.data.BPRequriement, y: "F0") + " BAP)";
        ups.BPMultiText.text = "BAP Cost Multi\n" + Methods.NotationMethod(game.data.BPCostMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewBPMulti, y: "F2");
        ups.FPRequirmentText.text = "Cost: Reset Force Pens\n(requires at least " + Methods.NotationMethod(game.data.FPRequriement, y: "F0") + " FP)";
        ups.FPMultiText.text = "FP Cost Multi\n" + Methods.NotationMethod(game.data.FPCostMulti, y: "F2") + " -> " + Methods.NotationMethod(game.data.NewFPMulti, y: "F2");

        //Rage
        rage.RageMultiText.text = "x" + Methods.NotationMethodBD(game.data.RageMulti, y: "F2");
        rage.RageText.text = "You've built up " + Methods.NotationMethodBD(game.data.Rage, y: "F0") + " Rage";
        rage.RageGainText.text = "Gain " + Methods.NotationMethodBD(game.data.RageGained, y: "F0") + " Rage (x" + Methods.NotationMethod(game.data.RDouble, y: "F0") + ")";

        //Upgrades
        rage.CurrentUp = 1;
        rage.RDoubleCostText.text = "Cost: " + Methods.NotationMethod(game.data.RDoubleCost, y: "F0") + " RAGE";
        rage.ACDownText.text = "Cost: 15 RAGE";
        rage.RGFormulaText.text = "Cost: 100 RAGE";
        rage.RACChangeText.text = "Cost: 5e6 RAGE";
    }

    public void DevButton()
    {
        game.data.Annoyance = 1e308;
    }

    public void ToggleMusic()
    {
        if (MusicToggle == true)
        {
            Music.SetActive(false);
            MusicToggle = false;
        }
        else
        {
            if (MusicToggle == false)
            Music.SetActive(true);
            MusicToggle = true;
        }
    }
}
