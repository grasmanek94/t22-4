using System;
using System.Windows.Forms;
namespace Communication
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			TrainDrukteForm win = new TrainDrukteForm();
			try
			{	
				win.Show();
				Application.Run();
			}
			catch (Exception ex)
			{
				if (win._arduino != null)
				{
					try
					{
						win._arduino.Disconnect();
					}
					catch(System.IO.IOException ioex)
					{
						MessageBox.Show(ioex.Message);
					}
				}
				throw ex;
			}
		}
	}
}
