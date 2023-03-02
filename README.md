# Kepler CRUD
## You can Perform Crud Operation Using This Library Automaticly

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://instagram.com/bug__developer)



- This is Helpful For Do Crud Operation Automaticlly 
- Give A Like To This Repo If you Found Something Helpful
- ✨[RNG](https://github.com/rajguptaH)✨
## Requirments
- .net 3.1 or newest 
-  Column Is Required IsDeleted Below Example Of A Table 
 ```sql
 CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

```
## Setup 
- Go On Nuget Install This Package or Using Command Line 
```cmd
$ dotnet add package Rng.KeplerCrud --version 3.2.1
```
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

        //You Have To Create A Object of IDbConnection First Like This With Your Connection String 
	using IDbConnection con = _connectionBuilder.connectionProp;
	//then Just Call methods And Perform CRUD 
	var listOfObject = con.GetAll(true);
	//Thats It 
```

Thats It 
## Questions 
- Q1 Why we You need this 
- Ans. This Is Light Weight and Fast To Perform CRUD And Using This you Don't need to write Much Code 
- Q2 What is columnBase Bool Parameter 
- Ans. If You Pass True in that then it will Only Use those Columns Where you have used KeplerColumn Attribute And Other Columns Will Be Ignored
- Q3 What is List of ConditionPair or condition 
- Ans. If you create a object like below and pass this object then it will filter out whatever condition you want
	```c#
	var conditions = new List<ConditionPair>();
	conditions.Add(new ConditionPair{ Where = "Id",Operator = "=", Value = "2"};
	```
## Methods 

```c#
/* use IdbConnection Object Before Using Methods Use Attributes In that models */
                        /* =============== GetAll(List<ConditionPair> conditions, bool columnBase) ================*/
 con.GetAll<Model>( List<ConditionPair> conditions, bool columnBase)
 //This Method Will Return All Records Based On Condtions 
                        /* =============== GetAll<T>(bool columnBase) ================
 con.GetAll<Model>( bool columnBase)
 //This Method Will Return All Records
                        /* =============== Get<T>(List<ConditionPair> conditions, bool columnBase ) ================*/
 con.Get<Model>(List<ConditionPair> conditions, bool columnBase )
 //This Method Will Return Record Based On Condtions 
                                        /* =============== Insert<T>(T model) ================*/
 con.Insert<Model>(T model)
 //This Method Will Insert The Record 
                                        /* =============== Update<T>(T model) ================*/
 con.Update<Model>(T model)
 //This Method Will Update The Record 
                                       /*  =============== Delete<T>(string pvalue) ================*/
 con.Delete<Model>(string pvalue)
 //This Method Will Delete Record
```
## Thanks 
```sql
Thanks❤  Myself Raj Narayan Gupta
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

