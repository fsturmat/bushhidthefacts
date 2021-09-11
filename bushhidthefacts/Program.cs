/*
 * Created by SharpDevelop.
 * User: fsturmat
 * Date: 11.09.2021
 * Time: 16:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;
using System.IO;

namespace bushhidthefacts
{
	class Program
	{
		// Import IsTextUnicode() into this neat little project
		[DllImport("Advapi32",SetLastError=false)]
		static extern bool IsTextUnicode(byte[] buf, int len, ref IsTextUnicodeFlags opt);
		[Flags]
    	enum IsTextUnicodeFlags:int
    	{
        	IS_TEXT_UNICODE_ASCII16           = 0x0001,
        	IS_TEXT_UNICODE_REVERSE_ASCII16       = 0x0010,

        	IS_TEXT_UNICODE_STATISTICS       = 0x0002,
        	IS_TEXT_UNICODE_REVERSE_STATISTICS   = 0x0020,

        	IS_TEXT_UNICODE_CONTROLS         = 0x0004,
        	IS_TEXT_UNICODE_REVERSE_CONTROLS     = 0x0040,

        	IS_TEXT_UNICODE_SIGNATURE        = 0x0008,
        	IS_TEXT_UNICODE_REVERSE_SIGNATURE     =0x0080,

        	IS_TEXT_UNICODE_ILLEGAL_CHARS    = 0x0100,
        	IS_TEXT_UNICODE_ODD_LENGTH       = 0x0200,
        	IS_TEXT_UNICODE_DBCS_LEADBYTE    = ~0,	// That's how the developers of notepad.exe did it
        	IS_TEXT_UNICODE_NULL_BYTES       = 0x1000,

        	IS_TEXT_UNICODE_UNICODE_MASK    =  0x000F,
        	IS_TEXT_UNICODE_REVERSE_MASK    =  0x00F0,
        	IS_TEXT_UNICODE_NOT_UNICODE_MASK    =  0x0F00,
        	IS_TEXT_UNICODE_NOT_ASCII_MASK      =  0xF000
    	}

		
		public static void Main(string[] args)
		{	
			// Create a new text file containing "bush hid the facts" in plain ASCII
			File.WriteAllText("test.txt", "bush hid the facts");
			
			// Read that particular file into a byte array
			byte[] buffer = File.ReadAllBytes("test.txt");
			
			// This will cause IsTextUnicode() to utilize the exact same detection mechanism as notepad.exe did
			IsTextUnicodeFlags test = new IsTextUnicodeFlags();
			test = IsTextUnicodeFlags.IS_TEXT_UNICODE_DBCS_LEADBYTE;
			
			// This will call the function, obviously.
			bool result = IsTextUnicode(buffer, buffer.Length, ref test);
			
			if(result)
				Console.WriteLine("IsTextUnicode assumes that the test file is encoded in Unicode.\r\nThis means that your Windows OS is behaving as expected.");
			else
				Console.WriteLine("IsTextUnicode assumes that the test file is NOT encoded in Unicode.\r\nThis means that your Windows OS must have been patched or something.");
			
			Console.Write("\r\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}