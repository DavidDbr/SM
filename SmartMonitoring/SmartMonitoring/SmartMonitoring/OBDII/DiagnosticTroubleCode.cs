using System;
using System.Linq;
using System.Text;

namespace SmartMonitoring.OBDII
{
    public class DiagnosticTroubleCode
    {

        private string troubleCode;

        public string TroubleCode { get => troubleCode; set => troubleCode = value; }

        public DiagnosticTroubleCode(string code)
        {
            TroubleCode = "";
            switch (code[0])
            {
                case '0':
                    TroubleCode = TroubleCode + "P0";
                    break;

                case '1':
                    TroubleCode = TroubleCode + "P1";
                    break;

                case '2':
                    TroubleCode = TroubleCode + "P2";
                    break;

                case '3':
                    TroubleCode = TroubleCode + "P3";
                    break;

                case '4':
                    TroubleCode = TroubleCode + "C0";
                    break;

                case '5':
                    TroubleCode = TroubleCode + "C1";
                    break;

                case '6':
                    TroubleCode = TroubleCode + "C2";
                    break;

                case '7':
                    TroubleCode = TroubleCode + "C3";
                    break;

                case '8':
                    TroubleCode = TroubleCode + "B0";
                    break;

                case '9':
                    TroubleCode = TroubleCode + "B1";
                    break;

                case 'A':
                    TroubleCode = TroubleCode + "B2";
                    break;


                case 'B':
                    TroubleCode = TroubleCode + "B3";
                    break;

                case 'C':
                    TroubleCode = TroubleCode + "U0";
                    break;

                case 'D':
                    TroubleCode = TroubleCode + "U1";
                    break;

                case 'E':
                    TroubleCode = TroubleCode + "U2";
                    break;

                case 'F':
                    TroubleCode = TroubleCode + "U3";
                    break;
            }

            TroubleCode = TroubleCode + code.Substring(1);
        }

       
        /* public enum Type
{
Powertrain = 0x00,
Chassis = 0x01,
Body = 0x02,
Network = 0x03
}

public Byte[] Code { get; set; }

public string TextRepresentation
{
get
{
string representation = "";
switch (ErrorType)
{
case Type.Powertrain: { representation = "P"; break; }
case Type.Chassis: { representation = "C"; break; }
case Type.Body: { representation = "B"; break; }
case Type.Network: { representation = "U"; break; }
}

Byte firstByte = Code.First();
representation += (firstByte >> 4) & 3;
representation += Convert.ToInt32(((firstByte >> 0) & 15).ToString(), 16);

Byte secondByte = Code.ElementAt(1);
representation += Convert.ToInt32(((secondByte >> 4) & 15).ToString(), 16);
representation += Convert.ToInt32(((secondByte >> 0) & 15).ToString(), 16);

return representation;
}
}

public Type ErrorType
{
get
{
Byte firstByte = Code.First();
return (Type)((firstByte >> 6) & 3);
}
}

public DiagnosticTroubleCode(string code)
{
Code = Encoding.Unicode.GetBytes(code);
}

public DiagnosticTroubleCode(Byte[] code)
{
Code = code;
}*/
    }

    



}