# Page reference here
var cosmos = builder.AddCosmosDb("cosmosdb, password")
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithDataVolume()
                    .WithDataBindMount(source: @"C:\CosmosDB\Data");     
var cosmosdb = cosmos.AddDatabase("cosmosdb");
builder.AddProject<Projects.Saturn_Database>()
       .WithReference(cosmosdb)
       .WaitFor(cosmosdb);