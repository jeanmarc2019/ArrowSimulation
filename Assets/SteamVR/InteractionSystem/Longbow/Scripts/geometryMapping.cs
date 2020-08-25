using System.Collections.Generic;
using System;
using UnityEngine;

namespace GeometryMapper
{
    class PhysicsHelper
    {
        public static string currentGeometry = "Nil"; // default is Nil geometry

        public static void changeGeometry(String geometry)
        {
            currentGeometry = geometry;
        }

        private static Vector3 NilMultiply(Vector3 left, Vector3 right)
        {
            Vector3 normalSum = new Vector3(
                left.x + right.x,
                left.y + right.y + (left.x*right.z - right.x*left.z),
                left.z + right.z
            );
            return normalSum;
        }
        private static Vector3 RussianArrowFromOrigin(float r, float varphi, float gamma, float t)
        {
            float x = (r/(2*gamma))*(Mathf.Sin(2*gamma*t + varphi) - Mathf.Sin(varphi));
            float y = ((1+Mathf.Pow(gamma, 2f))/(2*gamma))*t - ((1 - Mathf.Pow(gamma, 2f))/(4*Mathf.Pow(gamma, 2f)))*Mathf.Sin(2*gamma*t);
            float z = (r/(2*gamma))*(Mathf.Cos(varphi) - Mathf.Cos(2*gamma*t + varphi));
            Vector3 output = new Vector3(x,y,z);
            return output;
        }
        public static float aFromDirection(Vector3 direction)
        {
            return (float)Math.Pow(Mathf.Pow(direction.x, 2f) + Mathf.Pow(direction.z, 2f), 0.5f);
        }
        public static float angleFromDirection(Vector3 direction)
        {
            return (float)Mathf.Atan2(direction.z, direction.x);
        }
        public static Vector3 ArrowFromOrigin(Vector3 input, float t)
        {
            return RussianArrowFromOrigin(aFromDirection(input), angleFromDirection(input), input.y, t);
        }
        private static Vector3 BringVelocityToOrigin(Vector3 velocity, Vector3 oldLocation)
        {
            return NilMultiply(-1*oldLocation, oldLocation + velocity);
        }
        private static Vector3 BeingVelocityToLocation(Vector3 velocity, Vector3 newLocation)
        {
            return -1*newLocation + NilMultiply(newLocation, velocity);
        }
        public static Vector3 ArrowFromElsewhere(Vector3 whereImShootingFrom, Vector3 whatDirectionImShooting, float t)
        {
            return NilMultiply(
                whereImShootingFrom,
                ArrowFromOrigin(
                    BringVelocityToOrigin(whatDirectionImShooting, whereImShootingFrom),
                    t
                )
            );
        }
        public static Vector3 derivateApprox(Vector3 position, Vector3 direction, float t)
        {
            Vector3 f_of_x_plus_h = ArrowFromElsewhere(position, direction, t + Time.deltaTime);
            Vector3 f_of_x = ArrowFromElsewhere(position, direction, t);
            float h = Time.deltaTime;
            return (f_of_x_plus_h - f_of_x)/h;
        }
    }
}