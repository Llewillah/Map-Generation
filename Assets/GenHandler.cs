using UnityEngine;

public class GenHandler : MonoBehaviour
{
    int curGen;
    public Grid grid;
    public DrunkenWalk dW;
    public ModifiedDrunkenWalk mDW;
    public CellularAutomota cA;
    public BinarySpacePartitioning bSP;
    public RandomisedDepthFirstSearch rDFS;
    public GameObject buttons;
    public GameObject bspButtons;

    private void Start()
    {
        dW.SetUp(grid);
        mDW.SetUp(grid);
        cA.SetUp(grid);
        bSP.SetUp(grid);
        rDFS.SetUp(grid);
    }

    public void StartGen() 
    {
        grid.ResetGrid();

        if (curGen == 0)
        {
            dW.TakeStep();
        }
        else if (curGen == 1)
        {
            mDW.DoGen();
        }
        else if (curGen == 2)
        {
            cA.StartGen();
        }
        else if (curGen == 3)
        {
            bSP.StartGen();
        }
        else if (curGen == 4) 
        {
            rDFS.StartGen();
        }
    }

    public void ChooseGen(int gen) 
    {
        grid.ResetGrid();
        curGen = gen;
        if (gen == 3)
        {
            bspButtons.SetActive(true);
        }
        else
        {
            bspButtons.SetActive(false);
        }
    }

    public void ShowMenu() 
    {
        buttons.SetActive(!buttons.activeSelf);
    }
}
