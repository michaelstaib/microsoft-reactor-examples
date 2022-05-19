namespace Demo.Types;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Asset> GetAssets(AssetContext context)
        => context.Assets;
}