using System;
using System.Collections.Generic;
using System.Text;

namespace Bll
{
    public class DistanceCardHelper
    {
        public static byte[] SetDistanceData(SingleCardDataParam param)
        {
            int functionbyte = 0;
            return SetDistanceData(param, ref functionbyte);
        }

        public static byte[] SetDistanceData(SingleCardDataParam param, ref int functionbyte)
        {
            int typebyte = SetCardTypeByte(param.CardTypeParam);
            functionbyte = SetCardFunctionByte(param.CardFunctioinParam);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:X2}", functionbyte);
            sb.AppendFormat("{0:X4}", param.Count);
            sb.AppendFormat("{0:yyMMdd}", param.NewTime);
            sb.AppendFormat("{0:X4}", param.Partition);
            return PortAgreement.GetDistanceContent(param.CardNumber, typebyte, 0, sb.ToString());
        }

        public static byte[] SetDistanceData(CombinationCardDataParam param)
        {
            int functionbyte = 0;
            return SetDistanceData(param, ref functionbyte);
        }

        public static byte[] SetDistanceData(CombinationCardDataParam param, ref int functionbyte)
        {
            int typebyte = SetCardTypeByte(param.CardTypeParam);
            functionbyte = SetCardFunctionByte(param.CardFunctioinParam);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:X2}", functionbyte);
            sb.AppendFormat("{0:X4}", param.Count);
            if (param.ViceCards != null && param.ViceCards.Count > 0)
            {
                foreach (CombinationCardViceCardDataParam item in param.ViceCards)
                {
                    sb.AppendFormat("{0:yyMMdd}", item.ViceCardTime);
                    sb.AppendFormat("{0:X4}", item.ViceCardPartition);
                    sb.AppendFormat("{0:X4}", item.ViceCardCount);
                    sb.Append(item.ViceCardNumber);
                }
            }
            else
            {
                sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFF");
            }
            return PortAgreement.GetDistanceContent(param.CardNumber, typebyte, 0, sb.ToString());
        }
        public static byte[] SetDistanceData(LprCardDataParam param)
        {
            int functionbyte = 0;
            return SetDistanceData(param, ref functionbyte);
        }

        public static byte[] SetDistanceData(LprCardDataParam param, ref int functionbyte)
        {
            int typebyte = SetCardTypeByte(param.CardTypeParam);
            functionbyte = SetCardFunctionByte(param.CardFunctioinParam);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:X2}", functionbyte);
            sb.AppendFormat("{0:X4}", param.Count);
            if (param.ViceCards != null && param.ViceCards.Count > 0)
            {
                foreach (LprCardViceCardParam item in param.ViceCards)
                {
                    sb.AppendFormat("{0:yyMMdd}", item.ViceCardTime);
                    sb.AppendFormat("{0:X4}", item.ViceCardPartition);
                    sb.Append(GetPlateNumber(item.PlateNumber));
                }
            }
            else
            {
                sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFF");
            }
            return PortAgreement.GetDistanceContent(param.CardNumber, typebyte, 0, sb.ToString());
        }

        public static byte[] SetDistanceData(string cardnumber, int count, DateTime time, int partition)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:X4}", count);
            sb.AppendFormat("{0:yyMMdd}", time);
            sb.AppendFormat("{0:X4}", partition);
            return PortAgreement.GetDistanceContent(cardnumber, 1, sb.ToString());
        }

        public static byte[] SetDistanceData(string cardnumber, int count, List<CombinationCardViceCardDataParam> param)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:X4}", count);
            if (param != null && param.Count > 0)
            {
                foreach (CombinationCardViceCardDataParam item in param)
                {
                    sb.AppendFormat("{0:yyMMdd}", item.ViceCardTime);
                    sb.AppendFormat("{0:X4}", item.ViceCardPartition);
                    sb.AppendFormat("{0:X4}", item.ViceCardCount);
                    sb.Append(item.ViceCardNumber);
                }
            }
            else
            {
                sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFF");
            }
            return PortAgreement.GetDistanceContent(cardnumber, 1, sb.ToString());

        }

        public static byte[] SetDistanceData(string cardnumber, int count, List<LprCardViceCardParam> param)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0:X4}", count);
            if (param != null && param.Count > 0)
            {
                foreach (LprCardViceCardParam item in param)
                {
                    sb.AppendFormat("{0:yyMMdd}", item.ViceCardTime);
                    sb.AppendFormat("{0:X4}", item.ViceCardPartition);
                    sb.Append(GetPlateNumber(item.PlateNumber));
                }
            }
            else
            {
                sb.Append("FFFFFFFFFFFFFFFFFFFFFFFFFF");
            }
            return PortAgreement.GetDistanceContent(cardnumber, 1, sb.ToString());
        }

        public static int LimitCount(int count)
        {
            count++;
            if (count > 65530 || count < 2)
            {
                count = 2;
            }
            return count;
        }

        private static string GetPlateNumber(string platenumber)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            platenumber = platenumber.PadRight(8, '~');
            if (platenumber[0] == 'W' && platenumber[1] == 'J')
            {
                if (platenumber.Length != 7)
                {
                    sb.AppendFormat("{0:X2}", 36);
                    index = 2;
                }
            }
            for (int a = index; a < platenumber.Length; a++)
            {
                string strchar = platenumber[a].ToString();
                if (CRegex.IsChinese(strchar))
                {
                    PlateProvinces.Provinces provincenumber = (PlateProvinces.Provinces)Enum.Parse(typeof(PlateProvinces.Provinces), strchar);
                    sb.AppendFormat("{0:X2}", (int)provincenumber);
                }
                else
                {
                    sb.AppendFormat("{0:X2}", Encoding.ASCII.GetBytes(strchar)[0]);
                }
            }
            return sb.ToString();
        }

        private static int SetCardFunctionByte(FunctionByteParameter param)
        {
            int functionbyte = BinaryHelper.SetIntegeSomeBit(0, 7, param.Loss == 1);
            functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 6, param.Synchronous == 1);
            switch (param.RegistrationType)
            {
                case CardTypes.SingleCard:
                    functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 5, true);
                    functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 1, false);
                    break;
                case CardTypes.CombinationCard:
                    functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 5, false);
                    functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 1, false);
                    break;
                default:
                    functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 5, false);
                    functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 1, true);
                    break;
            }
            functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 4, param.ParkingRestrictions != 0);
            for (int i = 0; i < 2; i++)
            {
                int vicebinary = BinaryHelper.GetIntegerSomeBit(param.ViceCardCount, i);
                functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 3 - i, vicebinary != 0);
            }
            functionbyte = BinaryHelper.SetIntegeSomeBit(functionbyte, 0, param.InOutState != 0);
            return functionbyte;
        }

        public static int SetCardTypeByte(DistanceTypeParameter param)
        {
            return SetCardTypeByte(param, 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="num">0 写入数据  1 写入类型 2 写入数据和类型</param>
        /// <returns></returns>
        public static int SetCardTypeByte(DistanceTypeParameter param, int num)
        {
            int typebyte = num;
            typebyte = BinaryHelper.SetIntegeSomeBit(typebyte, 7, param.Lock != 0);
            if (param.Distance < 4)
            {
                typebyte = BinaryHelper.SetIntegeSomeBit(typebyte, 6, true);
                for (int i = 0; i < 2; i++)
                {
                    int distance = BinaryHelper.GetIntegerSomeBit(param.Distance, i);
                    typebyte = BinaryHelper.SetIntegeSomeBit(typebyte, 4 + i, distance != 0);
                }
            }
            else
            {
                typebyte = BinaryHelper.SetIntegeSomeBit(typebyte, 6, false);
            }
            return typebyte;
        }

        public static byte[] SetLossCard(LossCardDataParam[] param)
        {
            StringBuilder sb = new StringBuilder();
            int datatype = 16777215;
            int cardtype = 1;
            int index = 23;
            foreach (LossCardDataParam item in param)
            {
                cardtype = item.CardType != CardTypes.ViceCard ? 2 : 1;
                for (int i = 0; i < 2; i++)
                {
                    int typebinary = BinaryHelper.GetIntegerSomeBit(cardtype, i);
                    datatype = BinaryHelper.SetIntegeSomeBit(datatype, index - i, typebinary != 0);
                }
                index -= 2;
                sb.Append(item.CardNumber);
                sb.AppendFormat("{0:X2}", BinaryHelper.SetIntegeSomeBit(item.Functionbyte, 7, true));
                sb.AppendFormat("{0:yyMM}", item.CardTime.AddMonths(1));
            }
            return PortAgreement.GetDistanceContent("797979", 0, string.Format("{0:X2}{1:X6}{2}", param.Length, datatype, sb.ToString()));
        }
    }

    public class LossCardDataParam
    {
        public string CardNumber { get; set; }

        public CardTypes CardType { get; set; }

        public int Functionbyte { get; set; }

        public DateTime CardTime { get; set; }
    }

    public class SingleCardDataParam : DistanceCardBaseParam
    {
        public DateTime NewTime { get; set; }

        public int Partition { get; set; }
    }

    public class CombinationCardDataParam : DistanceCardBaseParam
    {
        public CombinationCardDataParam()
        {
            ViceCards = new List<CombinationCardViceCardDataParam>();
        }

        public List<CombinationCardViceCardDataParam> ViceCards { get; set; }
    }

    public class LprCardDataParam : DistanceCardBaseParam
    {
        public LprCardDataParam()
        {
            ViceCards = new List<LprCardViceCardParam>();
        }

        public List<LprCardViceCardParam> ViceCards { get; set; }
    }

    public class LprCardViceCardParam
    {
        public DateTime ViceCardTime { get; set; }

        public int ViceCardPartition { get; set; }

        public string PlateNumber { get; set; }
    }

    public class CombinationCardViceCardDataParam
    {
        public DateTime ViceCardTime { get; set; }

        public int ViceCardPartition { get; set; }

        public int ViceCardCount { get; set; }

        public string ViceCardNumber { get; set; }
    }

    public class DistanceCardBaseParam
    {
        public string CardNumber { get; set; }

        public DistanceTypeParameter CardTypeParam { get; set; }

        public FunctionByteParameter CardFunctioinParam { get; set; }

        public int Count { get; set; }

    }
}
