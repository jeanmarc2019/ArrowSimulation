//Helper mapper for use across entire application
using UnityEngine;
using System;
using System.Collections;
namespace Valve.VR.InteractionSystem
{
    public static class GeometryHelper
    {
		public static String mode = "";

		public static Vector3 velocityMapper(Vector3 velocity, Vector3 position, float timeReleased)
		{
			switch (mode)
			{
				case "FakeEuclidean": //f(x,y,z) -> (x, y, e^z)
					Debug.Log("modifier: " + Mathf.Exp(position.z).ToString());
					velocity = new Vector3(
						velocity.x,
						velocity.y,
						velocity.z * Mathf.Exp(position.z)
						);
					break;
				case "Float":
					velocity = new Vector3(0, 0, 0);
					break;
				case "Circle":
					break;
				default:
					break;
			}
			return velocity;
		}
		public static Vector3 positionMapper(Vector3 velocity, Vector3 position, float timeReleased)
        {
			switch (mode)
			{
				case "Float":
					float relativeTime = Time.timeSinceLevelLoad - timeReleased;
					//Vector3 relativePosition = new Vector3(0, 0, 0);
					Vector3 relativePosition = new Vector3(0.01f * Mathf.Sin(relativeTime), 0, 0.01f * Mathf.Cos(relativeTime));
					position = position + relativePosition;
					break;
				default:
					break;
			}
			return position;
		}
		public static float settingsMapper(float setting)
        {
			switch (mode)
			{
				default:
					break;
			}
			return setting;
		}

	}
}