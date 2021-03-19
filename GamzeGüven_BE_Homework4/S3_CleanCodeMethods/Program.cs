using System;
using System.Collections.Generic;
using System.Linq;

namespace S3_CleanCodeMethods
{
	class Program
	{
		// CLEAN CODE PRINCIPLES

		/*
			KISS: Keep It Simple Stupid
			DRY: Don't Repeat Yourself
			YAGNI: You Aren't Gonna Need It
			Composition over inheritance
			Favor readability
			Practice consistency
		*/

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");


			#region Boolean Karşılaştırmalar
			// Sadelik ve okunabilirlik ön planda olmalı

			bool fill = true;

			//Dirty
			if(fill == true)
			{

			}

			//Clean
			if(fill)
			{

			}


			//Dirty
			int myGrade = 90;
			bool successGradeIsAA;

			if( myGrade > 80)
			{
				successGradeIsAA = true;
			}
			else
			{
				successGradeIsAA = false;
			}

			//Clean 
			successGradeIsAA = myGrade > 80;

			#endregion Boolean Karşılaştırmalar

			#region PozitifOl
			//Koşul cümlelerinde negatif koşul kullanmak kodu okuyanlar için genellikle kafa karışıklığı yaratmaktadır.
			//Bu sebeple pozitif ifadelere yönelmek çok daha iyi olacaktır.

			bool hasNotError = true;
			bool hasError = true;
			//Dirty

			if (!hasNotError)
			{

			}

			//Clean
			if (hasError)
			{

			}

			#endregion PozitifOl

			#region TernaryIF

			//Dirty

			int x = 5, y = 10;
			string result;

			if (x > y)
			{
				result = "x is greater than y";
			}
			else if (x < y)
			{
				result = "y is greater than x";
			}
			else
			{
				result = "x is equal to y";
			}

			//Clean
			result = x > y ? "x is greater than y" : x < y ? "y is greater than x" : "x is equal to y";

			#endregion TernaryIF

			#region StronglyType
			//const veya enum kullanmak çok daha mantıklı

			const string employeeType = "Manager";

			//Dirty

			if (employeeType == "Manager")

				//Clean
				//if (employeeType1 == employeeType)

				#endregion StronglyType

			#region Anlamsız İfadeler

			//Dirty
			if (age >= 18)
			{

			}

			//Clean
			int legalVotingAge = 18;

			if (age >= legalVotingAge)
			{

			}

			#endregion Anlamsız İfadeler

			#region Karmaşıkları Yok Et

			//Dirty

			var tariffEndDate = DateTime.Now.AddDays(30);
			var tariffStartDate = DateTime.Now;
			
			if (DateTime.Now <= tariffEndDate && DateTime.Now >= tariffStartDate)
			{

			}

			//Clean
			var isTariffContinue = DateTime.Now <= tariffEndDate && DateTime.Now >= tariffStartDate;

			if (isTariffContinue)
			{

			}

			#endregion Karmaşıkları Yok Et

			#region Doğru Aracı Kullan

			//Dirty

			List<User> matchingUsers = new List<User>();

			foreach (var user in users)
			{
				if (user.IsActive &&
					user.AccountBalanceStatus == user.Status)
				{
					matchingUsers.Add(user); 
				}
			}

			//Clean

			matchingUsers = users.Where(u => u.AccountBalance < mininmumAccountBalance && u.Status == u.IsActive);

			#endregion Doğru Aracı Kullan

			#region Parametreler

			//Dirty
			private void SaveUser(User user, bool emailUser)
			{
				if (emailUser)
				{
					
				}
			}


			//Clean
			private void SaveUser(User user)
			{
				//kaydedilecek user
			}
	
			private void EmailUser()
			{
				//mail atılacak user
			}

			#endregion Parametreler

			#region Tekrarlamayı Azalt

			bool a = true;
			bool b = true;
			bool c = true;
			if (a)
			{
				if (b)
				{
					if (c)
					{

					}
				}
			}

			//Okunabilirlik azaldı, kod kompleks hale geldi

			#endregion Tekrarlamayı Azalt


			#region Classları Küçük Tut
			//Dirty

			Student student = new Student();

			student.Name = "Gamze";
			student.Surname = "Güven";
			student.Age = "22";
			student.Title = "Ceng Student";

			//Clean
			Student student = new Student
			{
				Name = "Gamze",
				Surname = "Güven",
				Age = "22",
				Title = "Ceng Student"
			};

			#endregion Classları Küçük Tut


			Console.ReadKey();
		}
	}
}
