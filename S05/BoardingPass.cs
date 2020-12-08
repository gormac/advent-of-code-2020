using System;

namespace S05
{
    internal class BoardingPass
    {
        public BoardingPass(string seatCode)
        {
            string convertedCode = seatCode.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');
            SeatId = Convert.ToInt32(convertedCode, 2);
        }

        internal int SeatId { get; }
    }
}