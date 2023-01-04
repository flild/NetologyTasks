using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

namespace Checkers
{
    public static class Extension
    {
        public static Coordinate ToCoordinate(this (int x, int y) value)
        {
            return new Coordinate(value.x, value.y);
        }
        public static string ToSerializable(this string value, ColorType side, RecordType recordType, string destination = "")
        {
            string playerSide = side == ColorType.Black ? "1" : "2";

            switch (recordType)
            {
                case RecordType.Click:
                    return $"Игрок {playerSide} кликнул на {value}";

                case RecordType.Move:
                    return $"Игрок {playerSide} передвинул с {value} на {destination}";

                case RecordType.Remove:
                    return $"Игрок {playerSide} съел фишку на {value}";

                default:
                    throw new InvalidEnumArgumentException($"Action {recordType} is not supported");
            }
        }
    }
}


