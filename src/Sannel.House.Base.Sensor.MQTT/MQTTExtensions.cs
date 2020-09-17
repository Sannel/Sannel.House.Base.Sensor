using Sannel.House.Base.MQTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

/// Publishes the sensor reading.
namespace Sannel.House.Base.Sensor
{
	public static class MQTTExtensions
	{
		/// <summary>
		/// Publishes the sensor reading to the default topic
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="macAddress">The mac address.</param>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// </exception>
		public static void PublishSensorReading(this IMqttClientPublishService mqtt, ISensor sensor, long macAddress)
		{
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}

			mqtt.Publish(sensor.ToFieldReading(macAddress));
		}

		/// <summary>
		/// Publishes the sensor reading to the default topic
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="uuid">The UUID.</param>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// </exception>
		public static void PublishSensorReading(this IMqttClientPublishService mqtt, ISensor sensor, Guid uuid)
		{
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}

			mqtt.Publish(sensor.ToFieldReading(uuid));
		}

		/// <summary>
		/// Publishes the sensor reading.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="manufacture">The manufacture.</param>
		/// <param name="manufactureId">The manufacture identifier.</param>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// </exception>
		public static void PublishSensorReading(this IMqttClientPublishService mqtt, ISensor sensor, string manufacture, string manufactureId)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			if (string.IsNullOrWhiteSpace(manufacture))
			{
				throw new ArgumentNullException(nameof(manufacture));
			}

			if (string.IsNullOrWhiteSpace(manufactureId))
			{
				throw new ArgumentNullException(nameof(manufactureId));
			}

			mqtt.Publish(sensor.ToFieldReading(manufacture, manufactureId));
		}

		/// <summary>
		/// Publishes the sensor reading asynchronous.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="macAddress">The mac address.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// </exception>
		public static Task PublishSensorReadingAsync(this IMqttClientPublishService mqtt, ISensor sensor, long macAddress)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			return mqtt.PublishAsync(sensor.ToFieldReading(macAddress));
		}

		/// <summary>
		/// Publishes the sensor reading asynchronous.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="uuid">The UUID.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// </exception>
		public static Task PublishSensorReadingAsync(this IMqttClientPublishService mqtt, ISensor sensor, Guid uuid)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			return mqtt.PublishAsync(sensor.ToFieldReading(uuid));
		}

		/// <summary>
		/// Publishes the sensor reading asynchronous.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="manufacture">The manufacture.</param>
		/// <param name="manufactureId">The manufacture identifier.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// or
		/// manufacture
		/// or
		/// manufactureId
		/// </exception>
		public static Task PublishSensorReadingAsync(this IMqttClientPublishService mqtt, ISensor sensor, string manufacture, string manufactureId)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			if (string.IsNullOrWhiteSpace(manufacture))
			{
				throw new ArgumentNullException(nameof(manufacture));
			}

			if (string.IsNullOrWhiteSpace(manufactureId))
			{
				throw new ArgumentNullException(nameof(manufactureId));
			}

			return mqtt.PublishAsync(sensor.ToFieldReading(manufacture, manufactureId));
		}

		/// <summary>
		/// Publishes the sensor reading to the default topic
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="topic">The topic.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="macAddress">The mac address.</param>
		/// <exception cref="System.ArgumentNullException">mqtt
		/// or
		/// sensor</exception>
		public static void PublishSensorReading(this IMqttClientPublishService mqtt, string topic, ISensor sensor, long macAddress)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if (string.IsNullOrWhiteSpace(topic))
			{
				throw new ArgumentNullException(nameof(topic));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			mqtt.Publish(topic, sensor.ToFieldReading(macAddress));
		}

		/// <summary>
		/// Publishes the sensor reading to the default topic
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="topic">The topic.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="uuid">The UUID.</param>
		/// <exception cref="System.ArgumentNullException">mqtt
		/// or
		/// sensor</exception>
		public static void PublishSensorReading(this IMqttClientPublishService mqtt, string topic, ISensor sensor, Guid uuid)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if (string.IsNullOrWhiteSpace(topic))
			{
				throw new ArgumentNullException(nameof(topic));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			mqtt.Publish(topic, sensor.ToFieldReading(uuid));
		}

		/// <summary>
		/// Publishes the sensor reading.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="manufacture">The manufacture.</param>
		/// <param name="manufactureId">The manufacture identifier.</param>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// </exception>
		public static void PublishSensorReading(this IMqttClientPublishService mqtt, string topic, ISensor sensor, string manufacture, string manufactureId)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if (string.IsNullOrWhiteSpace(topic))
			{
				throw new ArgumentNullException(nameof(topic));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			if (string.IsNullOrWhiteSpace(manufacture))
			{
				throw new ArgumentNullException(nameof(manufacture));
			}

			if (string.IsNullOrWhiteSpace(manufactureId))
			{
				throw new ArgumentNullException(nameof(manufactureId));
			}

			mqtt.Publish(topic, sensor.ToFieldReading(manufacture, manufactureId));
		}

		/// <summary>
		/// Publishes the sensor reading asynchronous.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="macAddress">The mac address.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">
		/// mqtt
		/// or
		/// sensor
		/// </exception>
		public static Task PublishSensorReadingAsync(this IMqttClientPublishService mqtt, string topic, ISensor sensor, long macAddress)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if (string.IsNullOrWhiteSpace(topic))
			{
				throw new ArgumentNullException(nameof(topic));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif


			return mqtt.PublishAsync(topic, sensor.ToFieldReading(macAddress));
		}

		/// <summary>
		/// Publishes the sensor reading asynchronous.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="topic">The topic.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="uuid">The UUID.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">mqtt
		/// or
		/// sensor</exception>
		public static Task PublishSensorReadingAsync(this IMqttClientPublishService mqtt, string topic, ISensor sensor, Guid uuid)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if (string.IsNullOrWhiteSpace(topic))
			{
				throw new ArgumentNullException(nameof(topic));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			return mqtt.PublishAsync(topic, sensor.ToFieldReading(uuid));
		}

		/// <summary>
		/// Publishes the sensor reading asynchronous.
		/// </summary>
		/// <param name="mqtt">The MQTT.</param>
		/// <param name="topic">The topic.</param>
		/// <param name="sensor">The sensor.</param>
		/// <param name="manufacture">The manufacture.</param>
		/// <param name="manufactureId">The manufacture identifier.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentNullException">mqtt
		/// or
		/// sensor
		/// or
		/// manufacture
		/// or
		/// manufactureId</exception>
		public static Task PublishSensorReadingAsync(this IMqttClientPublishService mqtt, string topic, ISensor sensor, string manufacture, string manufactureId)
		{
#if NETSTANDARD2_0 || NETCOREAPP2_1
			if(mqtt is null)
			{
				throw new ArgumentNullException(nameof(mqtt));
			}

			if (string.IsNullOrWhiteSpace(topic))
			{
				throw new ArgumentNullException(nameof(topic));
			}

			if(sensor is null)
			{
				throw new ArgumentNullException(nameof(sensor));
			}
#endif

			if (string.IsNullOrWhiteSpace(manufacture))
			{
				throw new ArgumentNullException(nameof(manufacture));
			}

			if (string.IsNullOrWhiteSpace(manufactureId))
			{
				throw new ArgumentNullException(nameof(manufactureId));
			}

			return mqtt.PublishAsync(topic, sensor.ToFieldReading(manufacture, manufactureId));
		}
	}
}
