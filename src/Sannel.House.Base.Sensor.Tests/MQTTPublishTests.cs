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
using Sannel.House.Base.MQTT.Interfaces;
using Sannel.House.Base.Sensor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sannel.House.Base.Sensor.Tests
{
	public class MQTTPublishTests
	{
		private Random random = new Random();

#if NETCOREAPP2_1
		[Fact]
		public async Task PublishMacAddressNullTests()
		{
			var mqtt = new Mock<IMqttClientPublishService>();
			var sensor = new Mock<ITemperatureSensor>();
			Assert.Throws<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReading(null, null, 0));
			Assert.Throws<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReading(mqtt.Object, null, 0));

			Assert.Throws<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReading(null, null, null, 0));
			Assert.Throws<ArgumentNullException>("topic", () => MQTTExtensions.PublishSensorReading(mqtt.Object, null, null, 0));
			Assert.Throws<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReading(mqtt.Object, Guid.NewGuid().ToString(), null, 0));

			await Assert.ThrowsAsync<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReadingAsync(null, null, 0));
			await Assert.ThrowsAsync<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, null, 0));

			await Assert.ThrowsAsync<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReadingAsync(null, null, null, 0));
			await Assert.ThrowsAsync<ArgumentNullException>("topic", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, null, null, 0));
			await Assert.ThrowsAsync<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, Guid.NewGuid().ToString(), null, 0));
		}

		[Fact]
		public async Task PublishUuidNullTests()
		{
			var mqtt = new Mock<IMqttClientPublishService>();
			var sensor = new Mock<ITemperatureSensor>();

			Assert.Throws<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReading(null, null, Guid.Empty));
			Assert.Throws<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReading(mqtt.Object, null, Guid.Empty));

			Assert.Throws<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReading(null, null, null, Guid.Empty));
			Assert.Throws<ArgumentNullException>("topic", () => MQTTExtensions.PublishSensorReading(mqtt.Object, null, null, Guid.Empty));
			Assert.Throws<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReading(mqtt.Object, Guid.NewGuid().ToString(), null, Guid.Empty));

			await Assert.ThrowsAsync<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReadingAsync(null, null, Guid.Empty));
			await Assert.ThrowsAsync<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, null, Guid.Empty));

			await Assert.ThrowsAsync<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReadingAsync(null, null, null, Guid.Empty));
			await Assert.ThrowsAsync<ArgumentNullException>("topic", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, null, null, Guid.Empty));
			await Assert.ThrowsAsync<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, Guid.NewGuid().ToString(), null, Guid.Empty));
		}

		[Fact]
		public async Task PublishManufactureNullTests()
		{
			var mqtt = new Mock<IMqttClientPublishService>();
			var sensor = new Mock<ITemperatureSensor>();

			Assert.Throws<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReading(null, null, "a", "b"));
			Assert.Throws<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReading(mqtt.Object, null, "a", "b"));
			Assert.Throws<ArgumentNullException>("manufacture", () => MQTTExtensions.PublishSensorReading(mqtt.Object, sensor.Object, null, "b"));
			Assert.Throws<ArgumentNullException>("manufactureId", () => MQTTExtensions.PublishSensorReading(mqtt.Object, sensor.Object, "a", null));

			Assert.Throws<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReading(null, null, null, "a", "b"));
			Assert.Throws<ArgumentNullException>("topic", () => MQTTExtensions.PublishSensorReading(mqtt.Object, null, null, "a", "b"));
			Assert.Throws<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReading(mqtt.Object, Guid.NewGuid().ToString(), null, "a", "b"));
			Assert.Throws<ArgumentNullException>("manufacture", () => MQTTExtensions.PublishSensorReading(mqtt.Object, Guid.NewGuid().ToString(), sensor.Object, null, "b"));
			Assert.Throws<ArgumentNullException>("manufactureId", () => MQTTExtensions.PublishSensorReading(mqtt.Object, Guid.NewGuid().ToString(), sensor.Object, "a", null));

			await Assert.ThrowsAsync<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReadingAsync(null, null, "a", "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, null, "a", "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("manufacture", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, sensor.Object, null, "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("manufactureId", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, sensor.Object, "a", null));

			await Assert.ThrowsAsync<ArgumentNullException>("mqtt", () => MQTTExtensions.PublishSensorReadingAsync(null, null, null, "a", "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("topic", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, null, null, "a", "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("sensor", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, Guid.NewGuid().ToString(), null, "a", "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("manufacture", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, Guid.NewGuid().ToString(), sensor.Object, null, "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("manufactureId", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, Guid.NewGuid().ToString(), sensor.Object, "a", null));
		}
#else 

		[Fact]
		public async Task PublishManufactureEmptyTests()
		{
			var mqtt = new Mock<IMqttClientPublishService>();
			var sensor = new Mock<ITemperatureSensor>();
			await Assert.ThrowsAsync<ArgumentNullException>("manufacture", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, Guid.NewGuid().ToString(), sensor.Object, string.Empty, "b"));
			await Assert.ThrowsAsync<ArgumentNullException>("manufactureId", () => MQTTExtensions.PublishSensorReadingAsync(mqtt.Object, Guid.NewGuid().ToString(), sensor.Object, "a", string.Empty));
		}
#endif

		[Fact]
		public void PublishMacAddressTest()
		{
			var value = random.NextDouble();
			var macAddress = (long)Math.Truncate(random.NextDouble() * int.MaxValue);
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.Publish(It.IsAny<object>()))
				.Callback((object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(macAddress, reading.MacAddress);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			mqtt.Object.PublishSensorReading(sensor.Object, macAddress);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public void PublishMacAddressTopicTest()
		{
			var value = random.NextDouble();
			var topic = Guid.NewGuid().ToString();
			var macAddress = (long)Math.Truncate(random.NextDouble() * int.MaxValue);
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.Publish(It.IsAny<string>(), It.IsAny<object>()))
				.Callback((string publishTopic, object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(topic, publishTopic);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(macAddress, reading.MacAddress);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			mqtt.Object.PublishSensorReading(topic, sensor.Object, macAddress);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public async Task PublishMacAddressTestAsync()
		{
			var value = random.NextDouble();
			var macAddress = (long)Math.Truncate(random.NextDouble() * int.MaxValue);
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.PublishAsync(It.IsAny<Object>()))
				.Callback((object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(macAddress, reading.MacAddress);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			await mqtt.Object.PublishSensorReadingAsync(sensor.Object, macAddress);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public async Task PublishMacAddressTopicTestAsync()
		{
			var value = random.NextDouble();
			var topic = Guid.NewGuid().ToString();
			var macAddress = (long)Math.Truncate(random.NextDouble() * int.MaxValue);
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.PublishAsync(It.IsAny<string>(), It.IsAny<object>()))
				.Callback((string publishTopic, object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(topic, publishTopic);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(macAddress, reading.MacAddress);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			await mqtt.Object.PublishSensorReadingAsync(topic, sensor.Object, macAddress);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public void PublishUuidTest()
		{
			var value = random.NextDouble();
			var uuid = Guid.NewGuid();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.Publish(It.IsAny<Object>()))
				.Callback((object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(uuid, reading.Uuid);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			mqtt.Object.PublishSensorReading(sensor.Object, uuid);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public void PublishUuidTopicTest()
		{
			var value = random.NextDouble();
			var topic = Guid.NewGuid().ToString();
			var uuid = Guid.NewGuid();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.Publish(It.IsAny<string>(), It.IsAny<object>()))
				.Callback((string publishTopic, object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(topic, publishTopic);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(uuid, reading.Uuid);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			mqtt.Object.PublishSensorReading(topic, sensor.Object, uuid);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public async Task PublishUuidTestAsync()
		{
			var value = random.NextDouble();
			var uuid = Guid.NewGuid();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.PublishAsync(It.IsAny<Object>()))
				.Callback((object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(uuid, reading.Uuid);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			await mqtt.Object.PublishSensorReadingAsync(sensor.Object, uuid);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public async Task PublishUuidTopicTestAsync()
		{
			var value = random.NextDouble();
			var topic = Guid.NewGuid().ToString();
			var uuid = Guid.NewGuid();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.PublishAsync(It.IsAny<string>(), It.IsAny<object>()))
				.Callback((string publishTopic, object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(topic, publishTopic);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(uuid, reading.Uuid);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			await mqtt.Object.PublishSensorReadingAsync(topic, sensor.Object, uuid);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public void PublishManufactureTest()
		{
			var value = random.NextDouble();
			var manufacture = Guid.NewGuid().ToString();
			var manufactureId = Guid.NewGuid().ToString();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.Publish(It.IsAny<Object>()))
				.Callback((object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(manufacture, reading.Manufacture);
					Assert.Equal(manufactureId, reading.ManufactureId);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			mqtt.Object.PublishSensorReading(sensor.Object, manufacture, manufactureId);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public void PublishManufactureTopicTest()
		{
			var value = random.NextDouble();
			var topic = Guid.NewGuid().ToString();
			var manufacture = Guid.NewGuid().ToString();
			var manufactureId = Guid.NewGuid().ToString();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.Publish(It.IsAny<string>(), It.IsAny<object>()))
				.Callback((string publishTopic, object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(topic, publishTopic);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(manufacture, reading.Manufacture);
					Assert.Equal(manufactureId, reading.ManufactureId);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			mqtt.Object.PublishSensorReading(topic, sensor.Object, manufacture, manufactureId);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public async Task PublishManufactureTestAsync()
		{
			var value = random.NextDouble();
			var manufacture = Guid.NewGuid().ToString();
			var manufactureId = Guid.NewGuid().ToString();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.PublishAsync(It.IsAny<Object>()))
				.Callback((object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(manufacture, reading.Manufacture);
					Assert.Equal(manufactureId, reading.ManufactureId);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			await mqtt.Object.PublishSensorReadingAsync(sensor.Object, manufacture, manufactureId);
			Assert.Equal(1, publishCalled);
		}

		[Fact]
		public async Task PublishManufactureTopicTestAsync()
		{
			var value = random.NextDouble();
			var topic = Guid.NewGuid().ToString();
			var manufacture = Guid.NewGuid().ToString();
			var manufactureId = Guid.NewGuid().ToString();
			var publishCalled = 0;

			var sensor = new Mock<ITemperatureSensor>();
			sensor.Setup(i => i.GetTemperatureCelsius())
				.Returns(value);

			var mqtt = new Mock<IMqttClientPublishService>();
			mqtt.Setup(i => i.PublishAsync(It.IsAny<string>(), It.IsAny<object>()))
				.Callback((string publishTopic, object obj) =>
				{
					publishCalled++;
					var reading = Assert.IsAssignableFrom<FieldReading>(obj);
					Assert.Equal(topic, publishTopic);
					Assert.Equal(SensorTypes.Temperature, reading.SensorType);
					Assert.Equal(manufacture, reading.Manufacture);
					Assert.Equal(manufactureId, reading.ManufactureId);
					Assert.Single(reading.Values);
					Assert.Equal(value, reading.Values[nameof(SensorTypes.Temperature)]);
				});

			await mqtt.Object.PublishSensorReadingAsync(topic, sensor.Object, manufacture, manufactureId);
			Assert.Equal(1, publishCalled);
		}
	}
}
