# Kepler CRUD
## You can Perform Crud Operation Using This Library Automaticly

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://instagram.com/bug__developer)



- This is Helpful For Do Crud Operation Automaticlly 
- Give A Like To This Repo If you Found Something Helpful
- ✨[RNG](https://github.com/rajguptaH)✨
## Requirments
- .net 6.0 or newest 
- Currently It Is Supporting For .net 6.0 or later And Working On this To Work With older versions also
- Two Columns Is Required Id And IsDeleted Below Example Of A Table 
 ```sql
 CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
  /****** Column: IsDeleted  This Is Used For Soft Delete Because I Have Implemented A Condition In Query ******/
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[UiPageType] ADD  CONSTRAINT [DF_UiPageType_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
```
## Setup 
- Go On Nuget Install This Package
- Then Just Add Connection String In Your AppSettings.json Ex is Given Below
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "Value": "Server=localhost;Database=WFON; User ID=sa;Password=admin;"
  },
  "AllowedHosts": "*"
}
```
- Then Go To Project Startup.cs File Just Add These Lines
```c#
//First Of all Just Include This Namespace
using KeplerCrud.Connection;
/* This KeplerConnection Will Automaticlly read your 
appsettings.json file And Take Connection String */
builder.Services.AddSingleton<IKeplerConnection, KeplerConnection>();
```
- And Then Add KeplerTable and KeplerColumn In Your Model Like This
```c#
//Don't Forget To Include KeplerCrud.Utility Namespace 
 using KeplerCrud.Utility;

namespace WebApp.Models
{
    [KeplerTable("UiPageType")]
    public class UserDTO
    {
        [KeplerColumn("Id")]
        public int Id { get; set; }
        [KeplerColumn] // If You Don't Use This Attribute Here and put colunmBase Fetch Then You Won't Get This Column Value Or You Can't Save This
        public string Name { get; set; }
    }
}
```
- And Where You Want To Call Db To Perform Crud Just Use Like This 
```c#
//namespace for KeplerRepository
using KeplerCrud.Repostiory
private readonly IKeplerRepository<YourModel> _keplerRepository;

        public Constructor(IKeplerRepository<UserDTO> keplerRepository)
        {
            _keplerRepository = keplerRepository;
        }
```
- before using this _keplerRepository. Methods You have to register this model In Startup with This IKeplerRepostory
```c#
builder.Services.AddScoped<IKeplerRepository<YourModel>, KeplerRepository<YourModel>>();
```
Thats It 
## Questions 
- Q1 Why we You need this 
- Ans. This Is Light Weight and Fast To Perform CRUD And Using This you Don't need to write Much Code 
- Q2 What is columnBase Bool Parameter 
- Ans. If You Pass True in that then it will Only Use those Columns Where you have used KeplerColumn Attribute And Other Columns Will Be Ignored
## Thanks 
```c#
Thanks Myself Raj Narayan Gupta
```
- I would Like To collaborate With Other Developers💛
- Mail : Rajkumar00999.rk@gmail.com
-  [Follow Us On Instagram]( https://instagram.com/raj__rr)
- [![GitHub rajguptaH](https://img.shields.io/github/followers/rajguptaH?label=follow&style=social)](https://github.com/rajguptaH)

## License

MIT

**Free Software, Hell Yeah!**
-
![visitors](https://visitor-badge.glitch.me/badge?page_id=rajguptaH.rajguptaH)
## Mail Me Or Give a messege In Instagram If You Have Any Suggestion / Questions / Issues or Feel Free To Contribute

