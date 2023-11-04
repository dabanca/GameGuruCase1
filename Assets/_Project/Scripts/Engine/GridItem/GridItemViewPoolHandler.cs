using System.Threading.Tasks;

namespace _Project.Scripts.Engine.GridItem{

public class GridItemViewPoolHandler
{
    public static GridItemViewPoolHandler Instance { get; private set; }

    public GridItemViewPoolHandler()
    {
        Instance = this;
    }

    public async Task InitTileViewPool()
    {
        await GridItemViewPool.Instance.InitializePool();
    }

    public void ReleaseTileViewPool()
    {
        GridItemViewPool.Instance.Release();
    }
}
}