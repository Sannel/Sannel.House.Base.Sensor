/* Copyright 2020 Sannel Software, L.L.C.

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

namespace Sannel.House.Base.Sensor
{
	/// <summary>
	/// Sensor Types
	/// </summary>
	[Flags]
	public enum SensorTypes
	{
		/// <summary>
		/// Unknown
		/// </summary>
		Unknown = 0b0000_0000_0000_0000,
		/// <summary>
		/// Temperature
		/// </summary>
		Temperature = 0b0000_0000_0000_0001,
		/// <summary>
		/// Humidity
		/// </summary>
		Humidity = 0b0000_0000_0000_0010,
		/// <summary>
		/// Pressure
		/// </summary>
		Pressure = 0b0000_0000_0000_0100,
		/// <summary>
		/// Wind speed
		/// </summary>
		WindSpeed = 0b0000_0000_0000_1000,
		/// <summary>
		/// Wind direction
		/// </summary>
		WindDirection = 0b0000_0000_0001_0000,
		/// <summary>
		/// Soil moisture
		/// </summary>
		SoilMoisture = 0b0000_0000_0010_0000,
		/// <summary>
		/// Rain
		/// </summary>
		Rain = 0b0000_0000_0100_0000,
		/// <summary>
		/// Lux
		/// </summary>
		Lux = 0b0000_0000_1000_0000,
		/// <summary>
		/// Soil Temperature
		/// </summary>
		SoilTemperature = 0b0000_0001_0000_0000,
	}
}
