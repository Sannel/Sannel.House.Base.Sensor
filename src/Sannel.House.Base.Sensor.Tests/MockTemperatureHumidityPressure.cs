/* Copyright 2020-2020 Sannel Software, L.L.C.

Licensed under the Apache License, Version 2.0 (the ""License"");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an ""AS IS"" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Sannel.House.Base.Sensor.Tests
{
	public class MockTemperatureHumidityPressure : ITemperatureSensor, IHumiditySensor, IPressureSensor
	{
		public void Dispose()
		{
		}
		public double Pressure;

		/// <summary>
		/// Gets the pressure.
		/// </summary>
		/// <returns></returns>
		public double GetPressure()
			=> Pressure;

		public double RelativeHumidity;
		/// <summary>
		/// Gets the relative humidity.
		/// </summary>
		/// <returns></returns>
		public double GetRelativeHumidity()
			=> RelativeHumidity;


		public double Temperature;
		/// <summary>
		/// Gets the temperature Celsius.
		/// </summary>
		/// <returns></returns>
		public double GetTemperatureCelsius()
			=> Temperature;
	}
}
