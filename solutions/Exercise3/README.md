# Integrating REST services into GraphQL

1. Head over to the `Program.cs` and chain in `.AddJsonSupport()`.

```csharp
builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddAssetTypes()
    .AddGlobalObjectIdentification()
    .AddFiltering()
    .AddSorting()
    .AddJsonSupport()
    .RegisterDbContext<AssetContext>(DbContextKind.Pooled);
```

2. Create a new file `Schema.graphql` and add the following GraphQL SDL snippet:

```graphql
type AssetPriceChange {
    percentageChange: Float! @fromJson
}
```

3. Head over to the `Program.cs` and chain in `.AddDocumentFromFile("./Schema.graphql")`.

```csharp
builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddAssetTypes()
    .AddDocumentFromFile("./Schema.graphql")
    .AddGlobalObjectIdentification()
    .AddFiltering()
    .AddSorting()
    .AddJsonSupport()
    .RegisterDbContext<AssetContext>(DbContextKind.Pooled);
```

4. Now open `Types/Assets/AssetPriceNode.cs` and add the following resolver to it:

```csharp
[GraphQLType("AssetPriceChange")]
public async Task<JsonElement> GetChangeAsync(
    ChangeSpan span,
    [Parent] AssetPrice parent,
    AssetPriceChangeDataLoader assetPriceBySymbol,
    CancellationToken cancellationToken)
    => await assetPriceBySymbol.LoadAsync(new KeyAndSpan(parent.Symbol!, span), cancellationToken);
```