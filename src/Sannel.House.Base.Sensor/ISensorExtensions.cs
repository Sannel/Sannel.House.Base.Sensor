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
using System.Linq;
using System.Text;

namespace Sannel.House.Base.Sensor
{
	public static class ISensorExtensions
	{
		private static void addSensorType(FieldReading reading, SensorTypes sensorTypes)
		{
			if((reading.SensorType & sensorTypes) != sensorTypes)
			{
				reading.SensorType |= sensorTypes;
			}
		}

		private static void addValues(ISensor sensor, FieldReading reading)
		{
			var interfaces = sensor.GetType().GetInterfaces().Where(i => typeof(ISensor).IsAssignableFrom(i));

			foreach(var @interface in interfaces)
			{
				if(@interface == typeof(IHumiditySensor))
				{
					addSensorType(reading, SensorTypes.Humidity);

					var humidity = (IHumiditySensor)sensor;
					reading.Values[nameof(SensorTypes.Humidity)] = humidity.GetRelativeHumidity();
				}
				else if(@interface == typeof(ILightSensor))
				{
					addSensorType(reading, SensorTypes.Lux);

					var lux = (ILightSensor)sensor;
					reading.Values[nameof(SensorTypes.Lux)] = lux.GetLuxLevel();
				}
				else if(@interface == typeof(IPressureSensor))
				{
					addSensorType(reading, SensorTypes.Pressure);

					var pressure = (IPressureSensor)sensor;
					reading.Values[nameof(SensorTypes.Pressure)] = pressure.GetPressure();
				}
				else if(@interface == typeof(ITemperatureSensor))
				{
					addSensorType(reading, SensorTypes.Temperature);

					var temperature = (ITemperatureSensor)sensor;
					reading.Values[nameof(SensorTypes.Temperature)] = temperature.GetTemperatureCelsius();
				}
				else if(@interface == typeof(IWindSpeedSensor))
				{
					addSensorType(reading, SensorTypes.WindSpeed);

					var windSpeed = (IWindSpeedSensor)sensor;
					reading.Values[nameof(SensorTypes.WindSpeed)] = windSpeed.GetWindSpeedKph();
				}
				else if(@interface == typeof(IWindDirectionSensor))
				{
					addSensorType(reading, SensorTypes.WindDirection);

					var windDirection = (IWindDirectionSensor)sensor;
					reading.Values[nameof(SensorTypes.WindDirection)] = windDirection.GetWindDirection();
				}
				else if(@interface == typeof(ISoilMoistureSensor))
				{
					addSensorType(reading, SensorTypes.SoilMoisture);

					var soilMoisture = (ISoilMoistureSensor)sensor;
					reading.Values[nameof(SensorTypes.SoilMoisture)] = soilMoisture.GetSoilMoisture();
				}
				else if(@interface == typeof(IRainSensor))
				{
					addSensorType(reading, SensorTypes.Rain);

					var rain = (IRainSensor)sensor;
					reading.Values[nameof(SensorTypes.Rain)] = rain.GetRainPerHour();
				}
				else if(@interface == typeof(ISoilTemperatureSensor))
				{
					addSensorType(reading, SensorTypes.SoilTemperature);

					var soilTemperature = (ISoilTemperatureSensor)sensor;
					reading.Values[nameof(SensorTypes.SoilTemperature)] = soilTemperature.GetSoilTemperatureCelsius();
				}
			}
		}

		/// <summary>
		/// Converts an ISensor to fieldreading so it can be sent someplace else
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="macAddress">The mac address.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">sensor</exception>
		public static FieldReading ToFieldReading(this ISensor sensor, long macAddress)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			var reading = new FieldReading
			{
				MacAddress = macAddress
			};

			addValues(sensor, reading);

			return reading;
		}

		/// <summary>
		/// Converts an ISensor to fieldreading so it can be sent someplace else
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="uuid">The UUID.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">sensor</exception>
		public static FieldReading ToFieldReading(this ISensor sensor, Guid uuid)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif
			var reading = new FieldReading
			{
				Uuid = uuid
			};

			addValues(sensor, reading);

			return reading;
		}

		/// <summary>
		/// Converts an ISensor to fieldreading so it can be sent someplace else
		/// </summary>
		/// <param name="sensor">The sensor.</param>
		/// <param name="manufacture">The manufacture.</param>
		/// <param name="manufactureId">The manufacture identifier.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">sensor</exception>
		public static FieldReading ToFieldReading(this ISensor sensor, string manufacture, string manufactureId)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			var reading = new FieldReading
			{
				Manufacture = manufacture,
				ManufactureId = manufactureId
			};

			addValues(sensor, reading);

			return reading;
		}
	}
}
