# What's new in .NET CORE Platform

[https://github.com/igoravl/insiders-devtour](https://github.com/igoravl/insiders-devtour)

## Demo 01 : globaljson.json config file

Show multiple command lines available from `dotnet` CLI:

``` cmd
$ dotnet --version
3.0.100-alpha1-009701

$ dotnet --info

.NET Core SDK (reflecting any global.json):
  ...
  ...
  ...
```

Use of `dotnet new globaljson` to define the `dotnet` SDK we want to use
```cmd
$ dotnet new globaljson
```

Make 3 folders where all `dotnet` SDKs are predefined in a `globaljson.json` file
```
/EXP18
--- /CORE22
------ globaljson.json
--- /CORE30
------ globaljson.json
```

Check each folder
``` cmd
/CORE22
$ dotnet --version
2.2.100-preview3-009430

/CORE30
$ dotnet --version
3.0.100-alpha1-009701
```

## Demo 02 : Global tools

Make sure `nyancat` is not installed
``` cmd
$ dotnet tool uninstall nyancat -g
Tool 'nyancat' (version '1.0.0') was successfully uninstalled.
```

Démo

``` cmd
$ dotnet tool -g list

Package Id           Version              Commands
---------------------------------------------------------
dotnet-httprepl      2.2.0-rtm-35542      dotnet-httprepl
dotnet-outdated      2.0.0                dotnet-outdated
dotnet-script        0.26.1               dotnet-script


$ dotnet tool install nyancat -g
You can invoke the tool using the following command: nyancat
Tool 'nyancat' (version '1.0.0') was successfully installed.

$ nyancat

```

**dotnet-script**

``` cmd
$ dotnet-script
$ > var str = "Hello World";
$ > Console.WriteLine(str);
Hello World

$ mkdir Script & cd Script & dotnet-script init
Creating VS Code launch configuration file
...'C:\PROJECTS\SAMPLES\EXP18\Script\.vscode\launch.json' [Created]
Creating OmniSharp configuration file
...'C:\PROJECTS\SAMPLES\EXP18\Script\omnisharp.json' [Created]
Creating default script file 'main.csx'
Creating 'main.csx'
...'C:\PROJECTS\SAMPLES\EXP18\Script\main.csx' [Created]

$ Code .

$ dotnet-script main.csx
Hello world!
```

**dotnet-outdated**

```cmd
$ dotnet new web
$ dotnet-outdated -u

» WebApplication1                                                                    
  [.NETCoreApp,Version=v2.1]                                                         
  Dapper      1.50.4 -> 1.50.5                                                       
  MySql.Data  6.10.8 -> 8.0.13                                                       
                                                                                     
Version color legend:                                                                
<red>   : Major version update or pre-release version. Possible breaking changes.    
<yellow>: Minor version update. Backwards-compatible features added.                 
<green> : Patch version update. Backwards-compatible bug fixes.                      
                                                                                     
You can upgrade packages to the latest version by passing the -u or -u:prompt option.
```

# Demo 03 : Entity Framework

## Seed Data

From folder, add a migration, then edit data, then apply again migrations
``` cmd
$ dotnet ef migrations add dataseed
Done. To undo this action, use 'ef migrations remove'

```

Show the migration classes generated, especially in class `nnnnnn_dataseed.cs`, the two methods `Up()` and `Down()`
Apply the migration
``` cmd
$ dotnet ef database update
Applying migration '20181026135017_dataseed'.
Done.
``` 

Let's say we wants to change data in the seeding part. Change in `Customer` seed datas, **Orlando Gee** to **John Gee**.
Then, create a new migration
``` cmd
$ dotnet ef migrations add JohnOrson
Done. To undo this action, use 'ef migrations remove'

$ dotnet ef database update
Applying migration '20181026140754_John'.
Done.
```

Then see the resuls in new file created `nnnnn_John.cs`:
``` csharp
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.UpdateData(
        table: "Customer",
        keyColumn: "CustomerId",
        keyValue: 1000,
        column: "FirstName",
        value: "John");
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.UpdateData(
        table: "Customer",
        keyColumn: "CustomerId",
        keyValue: 1000,
        column: "FirstName",
        value: "Orlando");
}

```

Show migration script
``` cmd
$ dotnet migrations script
```

## Value Converters

Open solution **ValueConverter**
Show the `Employee` class and the new **enum** `EmployeeType`:
```csharp
public enum EmployeeType
{
    CEO,
    CTO,
    Sales,
    Marketing,
    Peon
}
```

Uncomment the new property in the `Employee` class

``` csharp
public partial class Employee
{
    public Employee() => this.Customer = new HashSet<Customer>();

    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Customer> Customer { get; set; }

    //public EmployeeType EmployeeType { get; set; }
}
```

Then add the conversion in the `AdventureWorksContext` class, in method `OnModelCreating`:
```csharp

entity.Property(e => e.EmployeeType)
    .HasConversion(et => et.ToString(), str => Enum.Parse<EmployeeType>(str));

```
And eventually, explains we already have such converters like `EnumToStringConverter<T>`:
``` csharp
entity.Property(e => e.EmployeeType)
    .HasConversion(new EnumToStringConverter<EmployeeType>());

```

## LazyLoading

Show code with normal behavior
``` cmd
$ dotnet run
Paul Orson (CEO)
- No customers loaded, yet.
David Kandle (Sales)
- No customers loaded, yet.
Jillian Jon (Peon)
- No customers loaded, yet.
```

Add the `Include("Customers")` behavior
``` csharp
foreach (var e in advCtx.Employees.Include("Customers"))
```
``` cmd
$ dotnet run
Paul Orson (CEO)
- John Gee from A Bike Store
- Keith Harris from Progressive Sports
David Kandle (Sales)
- Donna Carreras from Advanced Bike Components
Jillian Jon (Peon)
- Janet Gates from Modular Cycle Systems
```
Show SQL generated code
``` sql
SELECT [e.Customers].[CustomerId], [e.Customers].[CompanyName], [e.Customers].[EmailAddress], [e.Customers].[EmployeeId], [e.Customers].[FirstName], [e.Customers].[LastName], [e.Customers].[MiddleName], [e.Customers].[NameStyle], [e.Customers].[PasswordHash], [e.Customers].[PasswordSalt], [e.Customers].[Phone], [e.Customers].[SalesPerson], [e.Customers].[Suffix], [e.Customers].[Title]
FROM [Customers] AS [e.Customers]
INNER JOIN (
    SELECT [e0].[EmployeeId]
    FROM [Employees] AS [e0]
) AS [t] ON [e.Customers].[EmployeeId] = [t].[EmployeeId]
ORDER BY [t].[EmployeeId]
```


Activate lazy loading

Add reference to `Microsoft.EntityFrameworkCore.Proxies` and show the nuget references:

``` xml
<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.2.0-preview3-35497" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="2.2.0-preview3-35497" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.0-preview3-35497" />
</ItemGroup>
```

Then activate lazy loading
``` csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Demo.LazyLoading;Trusted_Connection=True;ConnectRetryCount=0")
    .UseLazyLoadingProxies();

}
```

Show error
``` cmd
Navigation property 'Addresses' on entity type 'Customer' is not virtual. UseLazyLoadingProxies requires all entity types to be public, unsealed, have virtual navigation properties ...
```

Set `Customers` property in `Employee` class as `virtual`:
``` csharp
public virtual ICollection<Customer> Customers { get; set; }
```
And show the SQL output
``` sql
exec sp_executesql N'SELECT [e].[CustomerId], [e].[CompanyName], [e].[EmailAddress], [e].[EmployeeId], [e].[FirstName], [e].[LastName], [e].[MiddleName], [e].[NameStyle], [e].[PasswordHash], [e].[PasswordSalt], [e].[Phone], [e].[SalesPerson], [e].[Suffix], [e].[Title]
FROM [Customers] AS [e]
WHERE [e].[EmployeeId] = @__get_Item_0',N'@__get_Item_0 int',@__get_Item_0=1
go
exec sp_executesql N'SELECT [e].[CustomerId], [e].[CompanyName], [e].[EmailAddress], [e].[EmployeeId], [e].[FirstName], [e].[LastName], [e].[MiddleName], [e].[NameStyle], [e].[PasswordHash], [e].[PasswordSalt], [e].[Phone], [e].[SalesPerson], [e].[Suffix], [e].[Title]
FROM [Customers] AS [e]
WHERE [e].[EmployeeId] = @__get_Item_0',N'@__get_Item_0 int',@__get_Item_0=2
go
exec sp_executesql N'SELECT [e].[CustomerId], [e].[CompanyName], [e].[EmailAddress], [e].[EmployeeId], [e].[FirstName], [e].[LastName], [e].[MiddleName], [e].[NameStyle], [e].[PasswordHash], [e].[PasswordSalt], [e].[Phone], [e].[SalesPerson], [e].[Suffix], [e].[Title]
FROM [Customers] AS [e]
WHERE [e].[EmployeeId] = @__get_Item_0',N'@__get_Item_0 int',@__get_Item_0=3
go
```

## CosmosDB

Show new nuget package
``` xml
<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.Cosmos" Version="2.2.0-preview3-35497" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="2.2.0-preview3-35497" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Proxies" Version="2.2.0-preview3-35497" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.2.0-preview3-35497" />
</ItemGroup>
```

# ASP.NET CORE

## Certificate

For demo purpose, prepare your machine without certificate
``` cmd
$ dotnet dev-certs https --clean
$ dotnet dev-certs https -c -v
```

Create a .net core 2.1 app
- Error raised because no cert

``` cmd
$ dotnet dev-certs https
```

ASP.NET application is running normally, but not trusted

``` cmd
$ dotnet dev-certs https -t
```
Everything is eventually ok

## Razor Class Library RCL

Create a new Razor web application:
- Name **RazorWebSite**.
- Add Identity for next demo

Make sure we are on **.Net Core 2.2**.Razore Class Library is available since **2.1** but for the demos, we need to stack on **2.2**.

Launch and show we have a new layer, simplified, when we are on **.Net Core 2.2**

Add a new project, called **RazorLib** and add a reference to it, in **RazorWebSite**

Add code in `RazorLib/Areas/MyFeature/Pages/Page1.cshtml`:

``` html
<body>
    <h1>Hello from RazorLib ! page</h1>
</body>
```

Make a demo with *out of the box* project, showing the page is correctly displayed.

Add the **RCL** project from `EXP18\CORE22\RAZORLIB\RazorExp18Lib\RazorExp18Lib.csproj`
Add the reference to it, in **RazoreWebsite**
Run

Override the Message:
Recreate the directory folders, in **RazoreWebSite**
```
/RazorWebSite
|-- Areas
    |-- MyFeature
        |-- Pages
            |-- Shared
                |-- _Message.cshtml
```

Edit the `_Message.cshtml` page with:
``` html
<div>Description de mon composant, depuis le projet principal</div>
```

## Identity

Show that Identity is set on this model
Show nuget package `Microsoft.AspnetCore.Identity.UI`

Override Identity Layout

From `/Areas` folde, make 
- Add 
- New scafoled item
- On left tree, select Identity
- Select the correct Layout: `/Pages/Shared/_Layout.cshtml`
- Check **Account\Login**
- Select existing Data context class.

Once generated, edit the content of the login page, and make the test again.

## Consent

Delete check consent in cookie, and remake demo

## HttpClientFactory

Add `IHttpClientFactory` as services in `/Startup.cs`
``` csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient("starwars", client =>
    {
        client.BaseAddress =new Uri("https://swapi.co/api/");
        client.DefaultRequestHeaders.Add("Accept", "application/json"); 
    });

}
```

In the Index page called `Index.cshtml` in `/Pages` folder, Inject service factory in ctor
``` csharp
public HttpClient Client { get; }

public async Task OnGet()
{
    var luke = await GetCharactersAsync("1");
}

public IndexModel(IHttpClientFactory httpClientFactory)
{
    this.Client = httpClientFactory.CreateClient("starwars");
}


public async Task<Character> GetCharactersAsync(string id)
{
    var search = $"people/{id}";

    var response = await this.Client.GetAsync(search);
    response.EnsureSuccessStatusCode();

    var characterLists = await response.Content.ReadAsAsync<Character>();

    return characterLists;
}


```
Generate class `Character`

Copy the json body from this url: [https://swapi.co/api/people/1/](https://swapi.co/api/people/1/)
And Paste (Edit -> Paste Special -> As JSON Class) in `Character` class

``` csharp
public class Character
{
    public string name { get; set; }
    public string height { get; set; }
    public string mass { get; set; }
    public string hair_color { get; set; }
    public string skin_color { get; set; }
    public string eye_color { get; set; }
    public string birth_year { get; set; }
    public string gender { get; set; }
    public string homeworld { get; set; }
    public string[] films { get; set; }
    public string[] species { get; set; }
    public string[] vehicles { get; set; }
    public string[] starships { get; set; }
    public DateTime created { get; set; }
    public DateTime edited { get; set; }
    public string url { get; set; }
}
```

Add page html code:
``` html

<h1>Starwars</h1>

<p>
    Character Id.
</p>
<div asp-validation-summary="All"></div>
<form method="POST">
    <div>Name: <input asp-for="Id" /></div>
    <input type="submit" />
</form>

<div>
    @if (Model.Character != null)
    {
        @Model.Character.name
    }
</div>
```

# .NET CORE 3

## Hello world Winforms

Create a new **Winforms** application based on `.Net Core 3.0`

``` cmd
$ dotnet new winforms
$ dotnet run
```

Show the complete sample with **linked files**

Show how to trim files during publishing for **Self Contained Deployment**:

``` cmd
$ dotnet add package Microsoft.Packaging.Tools.Trimming -v 1.1.0-preview1-26619-01
$ dotnet publish -r win-x64 -c release
$ dotnet publish -r win-x86 -c release /p:TrimUnusedDependencies=true

```
Compare both directories

## CoreRT

CoreRT is a refactored runtime of **.NET Native** which uses **RyuJIT** to create native assemblies

``` cmd
$ dotnet new console -o HelloWorld
$ dotnet new nuget 
```

Add in nuget config files, under `</clear>`:

``` xml
<add key="dotnet-core" value="https://dotnet.myget.org/F/dotnet-core/api/v3/index.json" />
<add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
```

Then go back to terminal:

``` cmd
$ dotnet add package Microsoft.DotNet.ILCompiler -v 1.0.0-alpha-* 
$ dotnet publish -r win-x64 -c Release
```