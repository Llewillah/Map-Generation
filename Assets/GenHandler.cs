using UnityEngine;

public class GenHandler : MonoBehaviour
{
    public Grid grid;
    public DrunkenWalk dW;
    public ModifiedDrunkenWalk mDW;
    public CellularAutomota cA;
    public BinarySpacePartitioning bSP;

    bool gen = false;

    private void Start()
    {
        dW.SetUp(grid);
        mDW.SetUp(grid);
        cA.SetUp(grid);
        bSP.SetUp(grid);
    }

    private void Update()
    {
        if (gen)
        {
            
        }
    }

    public void StartGen() 
    {
        grid.ResetGrid();
        //dW.TakeStep();
        //mDW.DoGen();
        //cA.StartGen();
        bSP.StartGen();
    }
}
