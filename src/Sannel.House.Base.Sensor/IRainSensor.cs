using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Base.Sensor
{
	public interface IRainSensor : ISensor
	{
		/// <summary>
		/// Gets the rain per hour in millimeters per hour
		/// </summary>
		/// <returns></returns>
		double GetRainPerHour();
	}
}
