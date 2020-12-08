using System;

namespace S05
{
    internal class BoardingPass
    {
        internal string SeatCode { get; }

        internal int SeatId { get; }

        internal BoardingPass(string seatCode)
        {
            SeatCode = seatCode;
            // Conversion to binary to int
            string convertedCode = seatCode.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1');
            SeatId = Convert.ToInt32(convertedCode, 2);
        }
    }
}