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

using Moq;
using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Sannel.House.Base.Sensor.Tests
{
	public class ToReadingTests
	{
		private Random random = new Random();

		[Fact]
		public void THPTest()
		{
			var s = new MockTemperatureHumidityPressure
			{
				Pressure = random.NextDouble(),
				RelativeHumidity = random.NextDouble(),
				Temperature = random.NextDouble()
			};

			var macAddress = (long)Math.Truncate(random.NextDouble() * int.MaxValue);

			var fieldReading = s.ToFieldReading(macAddress);
			Assert.NotNull(fieldReading);
			Assert.Equal(SensorTypes.Humidity | SensorTypes.Pressure | SensorTypes.Temperature, fieldReading.SensorType);
			Assert.Equal(macAddress, fieldReading.MacAddress);
			Assert.Null(fieldReading.Uuid);
			Assert.Null(fieldReading.Manufacture);
			Assert.Null(fieldReading.ManufactureId);
			Assert.Equal(3, fieldReading.Values.Count);
			Assert.Equal(s.Pressure, fieldReading.Values[nameof(SensorTypes.Pressure)]);
			Assert.Equal(s.RelativeHumidity, fieldReading.Values[nameof(SensorTypes.Humidity)]);
			Assert.Equal(s.Temperature, fieldReading.Values[nameof(SensorTypes.Temperature)]);
		}

		[Fact]
		public void THPTest2()
		{
			var s = new MockTemperatureHumidityPressure
			{
				Pressure = random.NextDouble(),
				RelativeHumidity = random.NextDouble(),
				Temperature = random.NextDouble()
			};

			var uuid = Guid.NewGuid();

			var fieldReading = s.ToFieldReading(uuid);
			Assert.NotNull(fieldReading);
			Assert.Equal(SensorTypes.Humidity | SensorTypes.Pressure | SensorTypes.Temperature, fieldReading.SensorType);
			Assert.Equal(uuid, fieldReading.Uuid);
			Assert.Null(fieldReading.MacAddress);
			Assert.Null(fieldReading.Manufacture);
			Assert.Null(fieldReading.ManufactureId);
			Assert.Equal(3, fieldReading.Values.Count);
			Assert.Equal(s.Pressure, fieldReading.Values[nameof(SensorTypes.Pressure)]);
			Assert.Equal(s.RelativeHumidity, fieldReading.Values[nameof(SensorTypes.Humidity)]);
			Assert.Equal(s.Temperature, fieldReading.Values[nameof(SensorTypes.Temperature)]);
		}

		[Fact]
		public void THPTest3()
		{
			var s = new MockTemperatureHumidityPressure
			{
				Pressure = random.NextDouble(),
				RelativeHumidity = random.NextDouble(),
				Temperature = random.NextDouble()
			};

			var manufacture = Guid.NewGuid().ToString();
			var manufactureId = Guid.NewGuid().ToString();

			var fieldReading = s.ToFieldReading(manufacture, manufactureId);
			Assert.NotNull(fieldReading);
			Assert.Equal(SensorTypes.Humidity | SensorTypes.Pressure | SensorTypes.Temperature, fieldReading.SensorType);
			Assert.Null(fieldReading.Uuid);
			Assert.Null(fieldReading.MacAddress);
			Assert.Equal(manufacture, fieldReading.Manufacture);
			Assert.Equal(manufactureId, fieldReading.ManufactureId);
			Assert.Equal(3, fieldReading.Values.Count);
			Assert.Equal(s.Pressure, fieldReading.Values[nameof(SensorTypes.Pressure)]);
			Assert.Equal(s.RelativeHumidity, fieldReading.Values[nameof(SensorTypes.Humidity)]);
			Assert.Equal(s.Temperature, fieldReading.Values[nameof(SensorTypes.Temperature)]);
		}

		[Theory]
		[InlineData(typeof(IHumiditySensor), SensorTypes.Humidity)]
		[InlineData(typeof(ILightSensor), SensorTypes.Lux)]
		[InlineData(typeof(IPressureSensor), SensorTypes.Pressure)]
		[InlineData(typeof(IRainSensor), SensorTypes.Rain)]
		[InlineData(typeof(ISoilMoistureSensor), SensorTypes.SoilMoisture)]
		[InlineData(typeof(ISoilTemperatureSensor), SensorTypes.SoilTemperature)]
		[InlineData(typeof(IWindDirectionSensor), SensorTypes.WindDirection)]
		[InlineData(typeof(IWindSpeedSensor), SensorTypes.WindSpeed)]
		public void SensorMacAddressTest(Type type, SensorTypes sensorType)
		{
			var value = random.NextDouble();
			var t = typeof(Mock<>);
			var gtype = t.MakeGenericType(type);

			var sensor = (Mock)Activator.CreateInstance(gtype);
			sensor.DefaultValueProvider = new SensorDefaultValueProvider()
			{
				Value = value
			};

			var macAddress = (long)Math.Truncate(random.NextDouble() * int.MaxValue);

			var fieldReading = ((ISensor)sensor.Object).ToFieldReading(macAddress);
			Assert.NotNull(fieldReading);
			Assert.Equal(sensorType, fieldReading.SensorType);
			Assert.Equal(macAddress, fieldReading.MacAddress);
			Assert.Null(fieldReading.Uuid);
			Assert.Null(fieldReading.Manufacture);
			Assert.Null(fieldReading.ManufactureId);
			Assert.Single(fieldReading.Values);
			Assert.Equal(value, fieldReading.Values[sensorType.ToString()]);
		}

		[Theory]
		[InlineData(typeof(IHumiditySensor), SensorTypes.Humidity)]
		[InlineData(typeof(ILightSensor), SensorTypes.Lux)]
		[InlineData(typeof(IPressureSensor), SensorTypes.Pressure)]
		[InlineData(typeof(IRainSensor), SensorTypes.Rain)]
		[InlineData(typeof(ISoilMoistureSensor), SensorTypes.SoilMoisture)]
		[InlineData(typeof(ISoilTemperatureSensor), SensorTypes.SoilTemperature)]
		[InlineData(typeof(IWindDirectionSensor), SensorTypes.WindDirection)]
		[InlineData(typeof(IWindSpeedSensor), SensorTypes.WindSpeed)]
		public void SensorUuidTest(Type type, SensorTypes sensorType)
		{
			var value = random.NextDouble();
			var t = typeof(Mock<>);
			var gtype = t.MakeGenericType(type);

			var sensor = (Mock)Activator.CreateInstance(gtype);
			sensor.DefaultValueProvider = new SensorDefaultValueProvider()
			{
				Value = value
			};

			var uuid = Guid.NewGuid();

			var fieldReading = ((ISensor)sensor.Object).ToFieldReading(uuid);
			Assert.NotNull(fieldReading);
			Assert.Equal(sensorType, fieldReading.SensorType);
			Assert.Null(fieldReading.MacAddress);
			Assert.Equal(uuid, fieldReading.Uuid);
			Assert.Null(fieldReading.Manufacture);
			Assert.Null(fieldReading.ManufactureId);
			Assert.Single(fieldReading.Values);
			Assert.Equal(value, fieldReading.Values[sensorType.ToString()]);
		}

		[Theory]
		[InlineData(typeof(IHumiditySensor), SensorTypes.Humidity)]
		[InlineData(typeof(ILightSensor), SensorTypes.Lux)]
		[InlineData(typeof(IPressureSensor), SensorTypes.Pressure)]
		[InlineData(typeof(IRainSensor), SensorTypes.Rain)]
		[InlineData(typeof(ISoilMoistureSensor), SensorTypes.SoilMoisture)]
		[InlineData(typeof(ISoilTemperatureSensor), SensorTypes.SoilTemperature)]
		[InlineData(typeof(IWindDirectionSensor), SensorTypes.WindDirection)]
		[InlineData(typeof(IWindSpeedSensor), SensorTypes.WindSpeed)]
		public void SensorManufactureTest(Type type, SensorTypes sensorType)
		{
			var value = random.NextDouble();
			var t = typeof(Mock<>);
			var gtype = t.MakeGenericType(type);

			var sensor = (Mock)Activator.CreateInstance(gtype);
			sensor.DefaultValueProvider = new SensorDefaultValueProvider()
			{
				Value = value
			};

			var manufacture = Guid.NewGuid().ToString();
			var manufactureId = Guid.NewGuid().ToString();

			var fieldReading = ((ISensor)sensor.Object).ToFieldReading(manufacture, manufactureId);
			Assert.NotNull(fieldReading);
			Assert.Equal(sensorType, fieldReading.SensorType);
			Assert.Null(fieldReading.MacAddress);
			Assert.Null(fieldReading.Uuid);
			Assert.Equal(manufacture, fieldReading.Manufacture);
			Assert.Equal(manufactureId, fieldReading.ManufactureId);
			Assert.Single(fieldReading.Values);
			Assert.Equal(value, fieldReading.Values[sensorType.ToString()]);
		}

		[Fact]
		public void MacAddressNullTest()
		{
			Assert.Throws<ArgumentNullException>("sensor", () => ISensorExtensions.ToFieldReading(null, 0));
		}

		[Fact]
		public void UuidNullTest()
		{
			Assert.Throws<ArgumentNullException>("sensor", () => ISensorExtensions.ToFieldReading(null, Guid.Empty));
		}

		[Fact]
		public void ManufactureNullTest()
		{
			Assert.Throws<ArgumentNullException>("sensor", () => ISensorExtensions.ToFieldReading(null, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
		}
	}
}
