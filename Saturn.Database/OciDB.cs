# https://learn.microsoft.com/en-us/dotnet/aspire/database/oracle-entity-framework-integration?tabs=dotnet-cli
var oracle = builder.AddOracle("oracle, password")
                    .WithLifetime(ContainerLifetime.Persistent);
                    .WithDataVolume() 
                    .WithDataBindMount(source: @"C:\Oracle\Data"); 
var oracledb = oracle.AddDatabase("oracledb");
builder.AddProject<Projects.Aspire_#>()
       .WithReference(oracledb);
       .WaitFor(oracledb);