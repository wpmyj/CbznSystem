using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using Model;

namespace Bll
{
    /// <summary>
    /// 临时卡收费计算金额
    /// </summary>
    public class ChargeCalculate
    {
        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static double CalculateMoney(TimeSpan ts)
        {
            double money = 0;
            switch (Dal_ChargeParameter.ChargeParam.ChargeMode)
            {
                case 1://按时收费
                    money = CalculateHours(ts);
                    break;
                case 2://按停车时段收费
                    money = CalculateParkingTime(ts);
                    break;
                case 3://按时间段收费
                    money = CalculateTimeSlot(ts);
                    break;
            }
            return money;
        }

        /// <summary>
        /// 按时间段收费
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        private static double CalculateTimeSlot(TimeSpan ts)
        {
            double money = 0;
            double daymoney = 0;
            int seconds = ((ts.Hours * 60) + ts.Minutes) * 60 + ts.Seconds;
            DateTime start = DateTime.Now.AddSeconds(-seconds);
            DateTime stop = DateTime.Now;
            if (ts.Days > 0)
            {
                daymoney += Dal_ChargeParameter.ChargeParam.DailyLimit;
            }
            else
            {
                start = start.AddSeconds(Dal_ChargeParameter.ChargeParam.FreeMinutes * 60);
                if (start >= stop) return money;
                //计算首段收费
                if (seconds > Dal_ChargeParameter.ChargeParam.FirstCharge * 60 && seconds <= Dal_ChargeParameter.ChargeParam.FirstMoney * 60)
                {
                    if (Dal_ChargeParameter.ChargeParam.TwoCharge > 0)
                    {
                        start = start.AddSeconds(Dal_ChargeParameter.ChargeParam.TwoCharge * 60);
                        money = Dal_ChargeParameter.ChargeParam.TwoMoney;
                    }
                }
                else
                {
                    if (Dal_ChargeParameter.ChargeParam.FiveCharge > 0)
                    {
                        start = start.AddSeconds(Dal_ChargeParameter.ChargeParam.FiveCharge * 60);
                        money = Dal_ChargeParameter.ChargeParam.FiveMoney;
                    }
                }
            }
            if (start >= stop) return money;
            do
            {
                DateTime firststart = start.Date.AddMinutes(Dal_ChargeParameter.ChargeParam.FirstCharge);
                DateTime firststop = start.Date.AddMinutes(Dal_ChargeParameter.ChargeParam.FirstMoney);
                if (firststart > firststop)
                    firststop = firststop.AddDays(1);
                DateTime twostart = start.Date.AddMinutes(Dal_ChargeParameter.ChargeParam.FourCharge);
                DateTime twostop = start.Date.AddMinutes(Dal_ChargeParameter.ChargeParam.FourMoney);
                if (twostart > twostop)
                    twostop = twostop.AddDays(1);
                if (start >= firststart && start < firststop)
                {
                    if (stop <= firststop)
                    {
                        money += CalculatedMoney(ref start, stop, Dal_ChargeParameter.ChargeParam.ThreeCharge, Dal_ChargeParameter.ChargeParam.ThreeMoney);
                    }
                    else
                    {
                        money += CalculatedMoney(ref start, firststop, Dal_ChargeParameter.ChargeParam.ThreeCharge, Dal_ChargeParameter.ChargeParam.ThreeMoney);
                    }
                }
                else
                {
                    if (stop >= twostart && stop < twostop)
                    {
                        money += CalculatedMoney(ref start, stop, Dal_ChargeParameter.ChargeParam.SixCharge, Dal_ChargeParameter.ChargeParam.SixMoney);
                    }
                    else
                    {
                        money += CalculatedMoney(ref start, stop, Dal_ChargeParameter.ChargeParam.SixCharge, Dal_ChargeParameter.ChargeParam.SixMoney);
                    }
                }
            } while (start < stop);
            return money;
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <param name="minute"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        private static double CalculatedMoney(ref DateTime start, DateTime stop, double minute, double money)
        {
            TimeSpan ts = stop - start;
            minute = minute * 60;
            int count = (int)(ts.TotalSeconds / minute);
            if (ts.TotalSeconds % minute > 0) count++;
            start = stop;
            return count * money;
        }

        /// <summary>
        /// 计算停车时段
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        private static double CalculateParkingTime(TimeSpan ts)
        {
            double daymoney = 0;
            double money = 0;
            int seconds = ((ts.Hours * 60) + ts.Minutes) * 60 + ts.Seconds;
            if (ts.Days > 0)
            {
                daymoney += ts.Days * Dal_ChargeParameter.ChargeParam.DailyLimit;
            }
            else
            {
                seconds -= Dal_ChargeParameter.ChargeParam.FreeMinutes * 60;
            }
            if (seconds > 0)
            {
                if (seconds <= Dal_ChargeParameter.ChargeParam.FirstCharge * 60)
                {
                    money += Dal_ChargeParameter.ChargeParam.FirstMoney;
                }
                else if (seconds <= Dal_ChargeParameter.ChargeParam.TwoCharge * 60)
                {
                    money += Dal_ChargeParameter.ChargeParam.TwoMoney;
                }
                else if (seconds <= Dal_ChargeParameter.ChargeParam.ThreeCharge * 60)
                {
                    money += Dal_ChargeParameter.ChargeParam.ThreeMoney;
                }
                else if (seconds <= Dal_ChargeParameter.ChargeParam.FourCharge * 60)
                {
                    money += Dal_ChargeParameter.ChargeParam.FourMoney;
                }
                else if (seconds <= Dal_ChargeParameter.ChargeParam.FiveCharge * 60)
                {
                    money += Dal_ChargeParameter.ChargeParam.FiveMoney;
                }
                else if (seconds <= Dal_ChargeParameter.ChargeParam.SixCharge * 60)
                {
                    money += Dal_ChargeParameter.ChargeParam.SixMoney;
                }
                if (money > Dal_ChargeParameter.ChargeParam.DailyLimit)
                    money = Dal_ChargeParameter.ChargeParam.DailyLimit;
            }
            return daymoney + money;
        }

        private static double CalculateHours(TimeSpan ts)
        {
            double daymoney = 0;
            double money = 0;
            int seconds = ((ts.Hours * 60) + ts.Minutes) * 60 + ts.Seconds;
            if (ts.Days > 0)
            {
                daymoney += ts.Days * Dal_ChargeParameter.ChargeParam.DailyLimit;//限额
            }
            else
            {
                //计算免费分钟数
                seconds -= Dal_ChargeParameter.ChargeParam.FreeMinutes * 60;
                if (seconds > 0)
                {
                    //计算首段收费金额
                    seconds -= Dal_ChargeParameter.ChargeParam.FirstCharge * 60;//首段时间
                    money += Dal_ChargeParameter.ChargeParam.FirstMoney;//首段金额
                }
            }
            if (seconds > 0)
            {
                int calculationtime = Dal_ChargeParameter.ChargeParam.TwoCharge * 60;//间隔时间
                int count = seconds / calculationtime;
                if (seconds % calculationtime > 0) count++;
                money += count * Dal_ChargeParameter.ChargeParam.TwoMoney;//间隔金额
                if (money > Dal_ChargeParameter.ChargeParam.DailyLimit)
                    money = Dal_ChargeParameter.ChargeParam.DailyLimit;
            }
            return money + daymoney;
        }
    }
}