using System;
using Limxc.Tools.Extensions;

namespace Limxc.Arch.Core.Archives
{
    /// <summary>
    ///     孕期子档案
    /// </summary>
    public class PregnancyArchive
    {
        public PregnancyArchive() { }

        public PregnancyArchive(int gestationWeek, int gestationWeekDays)
        {
            GestationWeek = gestationWeek;
            GestationWeekDays = gestationWeekDays;
        }

        public PregnancyArchive(DateTime lastPeriod)
        {
            LastPeriod = lastPeriod;
        }

        /// <summary>
        ///     孕周
        /// </summary>
        public int GestationWeek { get; set; }

        /// <summary>
        ///     孕周天
        /// </summary>
        public int GestationWeekDays { get; set; }

        /// <summary>
        ///     末次月经时间
        /// </summary>
        public DateTime? LastPeriod { get; private set; }

        /// <summary>
        ///     孕前体重
        /// </summary>
        public double PgWeight { get; set; }

        /// <summary>
        ///     胎数
        /// </summary>
        public int FetusNumber { get; set; }

        public void SetLastPeriod(int gestationWeek, int gestationWeekDays)
        {
            LastPeriod = DateTime.Now.AddDays(-(gestationWeek * 7 + gestationWeekDays));
            CalcGestation();
        }

        public void CalcGestation()
        {
            var days = (int)((DateTime.Now - LastPeriod)?.TotalDays ?? 0).Limit(0, 7 * 40);
            GestationWeek = (days / 7).Limit(0, 40);
            GestationWeekDays = days % 7.Limit(0, 6);
        }
    }
}
