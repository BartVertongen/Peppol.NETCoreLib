
using System;
using VertSoft.SBDH;


namespace VertSoft.SBDHWrapper
{
	class Program
	{
		/// <summary>
		/// Will create a Standard Business Document xml from an XML Business Document.
		/// It will also generate the SBDH from the given document.
		/// </summary>
		/// <param name="args">Business Document XML file name</param>
		static void Main(string[] args)
		{
			if (args.Length != 1)
			{ 
				ShowUsage();
				Program.WaitForESCAPE();
			}
			else
			{				
				try
				{
					SBDWrapper objWrapper = new SBDWrapper(args[0]);
					objWrapper.WrapIt();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					Program.WaitForESCAPE();
				}
			}			
		}


		private static void WaitForESCAPE()
		{
			Console.WriteLine("\n\nPress ESC to Escape");
			do
			{
				while (!Console.KeyAvailable)
				{
					//Do something but in this case nothing
				}
			} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
		}


		private static void ShowUsage()
		{
			Console.WriteLine("SDBHWrapper written by Bart Vertongen 2020.\n");
			Console.WriteLine("This program has only one argument, the filename of an UBL business document.");
			Console.WriteLine("It will generate a Standard Business Document file.");
			Console.WriteLine("The file name will be the original with '_sbd' appended and the same extension.");
		}
	}
}
