using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompletion : MonoBehaviour
{
    private List<PuzzleCube> CubeList;

    public GameObject correctScreen;
    public GameObject incorrectScreen;

    private enum CorrectState { None, Correct, Incorrect  };
    private CorrectState correctState;

    private void Start()
    {
        correctState = CorrectState.None;
        CubeList = new List<PuzzleCube>(FindObjectsOfType<PuzzleCube>());
    }

    public void CheckForCompletion()
    {
        int totalCubes = CubeList.Count;
        int correctCubes = 0;

        foreach (PuzzleCube cube in CubeList)
        {
            if (cube.IsCorrectColor)
            {
                correctCubes++;
            }    
        }

        if (correctCubes == totalCubes)
        {
            if (correctState == CorrectState.Correct)
                return;

            correctState = CorrectState.Correct;

            VictoryScreen();
        }
        else
        {
            if (correctState == CorrectState.Incorrect)
                return;

            correctState = CorrectState.Incorrect;

            IncorrectScreen();
        }
    }

    private void VictoryScreen()
    {   
        if (incorrectScreen.activeSelf)
            incorrectScreen.SetActive(false);

        correctScreen.SetActive(true);
    }

    private void IncorrectScreen()
    {
        if (correctScreen.activeSelf)
            correctScreen.SetActive(false);

        incorrectScreen.SetActive(true);
    }
}
