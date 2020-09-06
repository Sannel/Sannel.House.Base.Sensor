using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Base.Sensor
{
	public interface ISoilTemperatureSensor : ISensor
	{
		/// <summary>
		/// Gets the soil temperature Celsius.
		/// </summary>
		/// <returns></returns>
		double GetSoilTemperatureCelsius();
	}
}
