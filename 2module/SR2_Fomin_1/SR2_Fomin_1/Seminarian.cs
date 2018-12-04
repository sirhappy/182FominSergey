/** БПИ 182-2 
 * Фомин Сергей
 * Вариант 1
 * **/

using System;

namespace SR2_Fomin_1
{
    /// <summary>
    ///     Класс семинаристов
    /// </summary>
    class Seminarian
    {
        public Seminarian(int pointsToTen, int hatefullTestNum)
        {
            PointsToTen = pointsToTen;
            HatefullTestNum = hatefullTestNum;
        }

        public int PointsToTen { get; protected set; }

        public int HatefullTestNum { get; protected set; }

        public int CheckWork(string work)
        {
            int mark = (int)Math.Round((double)work.Length / PointsToTen * 10);
            if (mark < 0) mark = 0;
            if (mark > 10) mark = 10;
            if (work.Length == HatefullTestNum) mark = 1;
            return mark;
        }

        public override string ToString()
        {
            return $"PointsToTen: {PointsToTen}, HatefullTestNum: {HatefullTestNum}";
        }
    }
}
