using UnityEngine;

public class GenHandler : MonoBehaviour
{
    public Grid grid;
    public DrunkenWalk dW;
    public ModifiedDrunkenWalk mDW;

    bool gen = false;

    private void Start()
    {
        dW.SetUp(grid);
        mDW.SetUp(grid);
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
        mDW.DoGen();
    }
}
