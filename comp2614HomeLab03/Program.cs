using System;
using System.IO;

namespace comp2614HomeLab03
{
	public class Program
	{
		public Program ()
		{
		}

		public static void Main (string[] args)
		{
			string fileName = "";
			if (args.Length > 0)
			{
				fileName = args [0];
			}

			StreamReader streamReader = null;
			try
			{
				streamReader = new StreamReader (fileName);
				processFile(streamReader);
			} 
			catch (Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
			finally
			{
				if (streamReader != null)
				{
					streamReader.Close ();
				}
			}
		}


		public static void processFile(StreamReader streamReader)
		{


			while (streamReader.Peek () > 0)
			{
				string line = streamReader.ReadLine ();
				char charData;
				string additionalInfo = "";
				string dataType = determineDataType (line, out charData);
				if (dataType == "Character")
				{
					additionalInfo = String.Format (" (ASCII value {0})", (int)charData);
				}

				Console.WriteLine("{0,-10} {1}{2}" ,line, dataType, additionalInfo);
			}

		}


		/// <summary>
		/// Determines the type of the data.
		/// </summary>
		/// <returns>The data type.</returns>
		/// <param name="data">Data.</param>
		/// 
		/// 
		//  Checks thre different data type possibilities:
		//  integer, float, and char.
		//  If all conversion attempts fail, the data is assumed to be string data.


		public static string determineDataType(String data, out char character)
		{

			bool success = IsInteger (data);
			character = '0';
			if(success)
			{
				return "Integer";
			}

			else
			{
				success = IsFloat (data);
			}

			if (success)
			{
				return "Floating Point";
			}


			else
			{
				char charData;
				success = IsChar (data, out charData);
				character = charData;
			}

			if (success)
			{
				return "Character";
			}

			else
			{
				//must be a string
				return  "Assumed to be String";
			}

		}

	
		public static bool IsInteger(String data)
		{
			int integerData;
			bool success = int.TryParse (data, out integerData);
			return success;
		}

		public static bool IsFloat(String data)
		{
			float floatData;
			bool success = float.TryParse (data, out floatData);
			return success;
		}

		public static bool IsChar(String data, out char charData)
		{
			//char charData;
			bool success = char.TryParse (data, out charData);
			return success;
		}



	}
}
//Your program should do the following:
//	 Determine the file to be read through a command line argument
//	 Display an error message to the console if no argument is supplied and exit
//	 Display an error message if the file cannot be found and exit
//		 Open the file
//		 Read each line in the file
//		 read the entire line into a string
//		 determine whether it contains: an integer, a single character, a float, or a string
//		 display the line and the result (see screenshot)
//		 keep a running total of all numeric types found
//		 Report the sum of the numeric values after you close the file




