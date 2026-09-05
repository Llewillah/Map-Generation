using UnityEngine;

public class GenHandler : MonoBehaviour
{
    public Grid grid;
    public DrunkenWalk dW;

    bool gen = false;

    private void Start()
    {
        dW.SetUp(grid);
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
        dW.TakeStep();
    }
}
