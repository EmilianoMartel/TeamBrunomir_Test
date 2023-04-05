using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class ThirdSceneScript : MonoBehaviour
{
    public DialogManager DialogManager;
    
    private DataManager dataManager;
    private string firstChoise;
    private string secondChoise;
    private const string OPTION_A = "A";
    private const string OPTION_B = "B";
    private const string OPTION_C = "C";

    private void Awake()
    {
        dataManager = FindObjectOfType<DataManager>();
        List<DialogData> dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/emote:Happy/Here I will inform you of the results in the previous Scenes.", "Li"));

        dialogTexts.Add(new DialogData("You choose option A - B - C in the first scene.", "Li"));

        dialogTexts.Add(new DialogData("/emote:Sad/The outcome of the mini-game was/emote:Normal/ 1 - 2 - 3.", "Li"));

        dialogTexts.Add(new DialogData("So the result is of /emote:Sad/the game is A - B - C + 1 - 2 - 3.", "Li"));

        dialogTexts.Add(new DialogData("And that's basically it!/emote:Happy/", "Li"));

        dialogTexts.Add(new DialogData("I hope you had fun in this little test! ", "Li"));

        dialogTexts.Add(new DialogData("I'm looking forward to see what you're capable of!", "Li"));

        firstChoise = dataManager.choise[0];
        secondChoise = dataManager.choise[1];
        dialogTexts.Add(new DialogData("Your combination is " + firstChoise + " and " + secondChoise ,"Li"));
        DialogManager.Show(dialogTexts);
    }
}
