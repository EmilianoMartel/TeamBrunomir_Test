using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEditor;
using UnityEngine.SceneManagement;

public class FirstSceneScript : MonoBehaviour
{
    public DialogManager DialogManager;
    public Character CharacterEmotion;

    private DialogData Answer;
    private DataManager dataManager;
    private const string OPTION_A = "A";
    private const string OPTION_B = "B";
    private const string OPTION_C = "C";
    private const string SECOND_SCENE_NAME = "SecondScene";


    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        
        List<DialogData> dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/my name is Li.", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/ Let's start this test!", "Li"));

        dialogTexts.Add(new DialogData("The idea is to create something very simple, make me react to the text and animate me in a few different ways.", "Li"));

        dialogTexts.Add(new DialogData("/emote:Sad/Remember that you can change my sprite or background if you choose so,/emote:Normal/ you can even go 3D if you're more experienced with that!", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/Anyways... Let's move on!", "Li"));

        dialogTexts.Add(new DialogData("Create a branching option where you have to choose between /emote:Happy/ 3 possible answers to give me.", "Li"));

        dialogTexts.Add(new DialogData("Once you create the options and pick one of them I'll say: ", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/ Yo choose option A!/emote:Normal/", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/ Or...", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/ Yo choose option B!/emote:Normal/", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/Or...", "Li"));

        dialogTexts.Add(new DialogData("/emote:Happy/ Yo choose option C!/emote:Normal/ /sound:haha./", "Li"));

        dialogTexts.Add(new DialogData("After this, you'll send me to the SecondScene!/emote:Happy/", "Li"));

        dialogTexts.Add(new DialogData("Where you'll have to create a VERY simple mini game and make me react to it.", "Li"));

        Answer = new DialogData("Well... it�s time, choose a option", "Li");
        Answer.SelectList.Add(OPTION_A, "Option A");
        Answer.SelectList.Add(OPTION_B, "Option B");
        Answer.SelectList.Add(OPTION_C, "Option C");
        Answer.Callback += Check;
        dialogTexts.Add(Answer);
        DialogManager.Show(dialogTexts);
    }

    private void Check()
    {
        if (DialogManager.Result.Equals(OPTION_A))
        {
            List<DialogData> dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("You choose A."));
            DialogManager.Show(dialogTexts);
            dataManager.choise.Add(OPTION_A);
        }
        else if (DialogManager.Result.Equals(OPTION_B))
        {
            List<DialogData> dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("You choose B."));
            DialogManager.Show(dialogTexts);
            dataManager.choise.Add(OPTION_B);        }
        else if (DialogManager.Result.Equals(OPTION_C))
        {
            List<DialogData> dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("You choose C."));
            DialogManager.Show(dialogTexts);
            dataManager.choise.Add(OPTION_C);
        }

        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SECOND_SCENE_NAME);
    }

    private void OnDisable()
    {
        Answer.Callback -= Check;
    }
}
