using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class SecondSceneScript : MonoBehaviour
{
    List<DialogData> dialogTexts = new List<DialogData>();
    public DialogManager DialogManager;
    public MiniGame miniGame;

    private DialogData DialogShort;
    private DialogData Answer;
    private const string OPTION_A = "A";
    private const string OPTION_B = "B";
    private const string OPTION_C = "C";
    private const string OPTION_YES = "Yes";
    private const string OPTION_NO = "No";

    private void Awake()
    {
        dialogTexts.Add(new DialogData("Here you can create any mini-game you can think of and make me react to it", "Li"));

        dialogTexts.Add(new DialogData("I doesn't have to be complex nor long, just some short and simple stuff.", "Li"));        

        dialogTexts.Add(new DialogData("Use my sprite, leave me on a side of the screen, make a few animations", "Li"));

        dialogTexts.Add(new DialogData("And depending the actions of the mini-game change mi animation state, move me or do whatever crazy stuff you can think of!", "Li"));

        dialogTexts.Add(new DialogData("After the player finishes the game, make me say something and move to the ThirdScene.", "Li"));

        Answer = new DialogData("Are you ready?", "Li");
        Answer.SelectList.Add(OPTION_YES, "Yes");
        Answer.SelectList.Add(OPTION_NO, "No");
        Answer.Callback += Check;

        dialogTexts.Add(Answer);

        DialogManager.Show(dialogTexts);
    }

    private void Check()
    {
        if (DialogManager.Result.Equals(OPTION_YES))
        {
            DialogShort = new DialogData("Lets go");
            DialogManager.Show(DialogShort);
        }
        if (DialogManager.Result.Equals(OPTION_NO)) //revisar
        {            
            List<DialogData> dialogTexts = new List<DialogData>();
            Answer = new DialogData("Okey, i waiting...", "Li");
            Answer.SelectList.Add(OPTION_YES, "Yes");
            Answer.SelectList.Add(OPTION_NO, "No");

            DialogManager.Show(dialogTexts);
        }
    }
    private void OnDisable()
    {
        Answer.Callback -= Check;
    }
}
