using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class SecondSceneScript : MonoBehaviour
{
    List<DialogData> dialogTexts = new List<DialogData>();
    public DialogManager DialogManager;
    public MiniGame miniGame;
    public Data data;

    private DialogData DialogShort;
    private DialogData Answer;
    private const string OPTION_A = "A";
    private const string OPTION_B = "B";
    private const string OPTION_C = "C";
    private const string OPTION_YES = "Yes";
    private const string OPTION_NO = "No";
    private const string THEIR_SCENE_NAME = "ThierScene";

    private void Awake()
    {
        miniGame.gameObject.SetActive(false);

        dialogTexts.Add(new DialogData("Here you can create any mini-game you can think of and make me react to it/emote:Happy/", "Li"));

        dialogTexts.Add(new DialogData("I doesn't have to be complex nor long, just some short and simple stuff./emote:Sad/", "Li"));        

        dialogTexts.Add(new DialogData("Use my sprite, leave me on a side of the screen/emote:Happy/, make a few animations/emote:Normal/", "Li"));

        dialogTexts.Add(new DialogData("And depending the actions of the mini-game change mi animation state, move me or do whatever crazy stuff you can think of!", "Li"));

        dialogTexts.Add(new DialogData("After the player finishes the game, make me say something and move to the ThirdScene.", "Li"));

        //dialogTexts.Add(new DialogData("When you are ready play space bar and we play pong /emote:Happy/", "Li"));

        Answer = new DialogData("Are you ready?", "Li");
        Answer.SelectList.Add(OPTION_YES, "Yes");
        Answer.SelectList.Add(OPTION_NO, "No");
        Answer.Callback += Check;

        dialogTexts.Add(Answer);

        DialogManager.Show(dialogTexts);
    }

    private void Update()
    {
        
    }
    private void Check()
    {
        if (DialogManager.Result.Equals(OPTION_YES))
        {
            DialogShort = new DialogData("Lets go, you play with w and s or UpArrow and DownArrow", "Li");
            DialogManager.Show(DialogShort);
            miniGame.gameObject.SetActive(true);
        }
        if (DialogManager.Result.Equals(OPTION_NO)) //revisar
        {                 
            List<DialogData> answerText = new List<DialogData>();
            DialogData reAnswer;
            answerText.Add(new DialogData("But... why? /emote:Sad/", "Li"));
            reAnswer = new DialogData("Okey, i waiting...", "Li");
            reAnswer.SelectList.Add(OPTION_YES, "Yes");
            reAnswer.SelectList.Add(OPTION_NO, "No");
            reAnswer.Callback += Check;
    
            answerText.Add(reAnswer);
    
            DialogManager.Show(answerText);
        }
    }

    private void OnDisable()
    {
        Answer.Callback -= Check;
    }

    public void EndScene(string winner)
    {
        miniGame.gameObject.SetActive(false);
        List<DialogData> endText = new List<DialogData>();
        if (winner.Equals("player"))
        {
            endText.Add(new DialogData("You win", "Li"));
        }
        if (winner.Equals("ia"))
        {
            endText.Add(new DialogData("I win", "Li"));
        }
        DialogData endChoice;
        endChoice = new DialogData("What are you think?","Li");
        endChoice.SelectList.Add(OPTION_A, "Well played");
        endChoice.SelectList.Add(OPTION_B, "Easy match");
        endChoice.SelectList.Add(OPTION_C, "You are a cheeting");
        endChoice.Callback += EndCheck;

        endText.Add(endChoice);
        DialogManager.Show(endText);
    }

    private void EndCheck()
    {

    }

    public void MiniGame(string point)
    {
        if (point.Equals("PlayerScore"))
        {
            DialogData emote = new DialogData("You are very lucky/emote:Sad/", "Li");
            DialogManager.Show(emote);
        }
        if (point.Equals("IaScore"))
        {
            DialogData emote = new DialogData("Easy for me/emote:Happy/", "Li");
            DialogManager.Show(emote);
        }
    }
}
