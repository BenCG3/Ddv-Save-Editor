using System.Runtime.InteropServices;
using System.Text;

namespace ddv_edit
{
	public class IniFile
	{
		private string filePath;

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		public IniFile(string filePath)
		{
			this.filePath = filePath;
		}

		public string Read(string section, string key)
		{
			StringBuilder sb = new StringBuilder(255);
			GetPrivateProfileString(section, key, "", sb, 255, filePath);
			return sb.ToString();
		}

		public void Write(string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, filePath);
		}
	}
}
