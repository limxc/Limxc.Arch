using System;
using System.Linq;
using Limxc.Arch.Core.Archives;
using Limxc.Arch.Core.Shared.Domains;
using Limxc.Arch.Core.Shared.Types;
using Limxc.Tools.Extensions;

namespace Limxc.Arch.Core.Domains.Archives
{
    public class Archive : IEntity
    {
        public Archive(
            string cardId,
            string name,
            Gender gender,
            DateTime birthDate,
            IdCard idCard = null,
            string contact = null,
            string contactDetails = null,
            string address = null,
            VitalSigns basicArchive = null,
            PregnancyArchive pregnancyArchive = null
        )
        {
            CardId = cardId.Trim();
            Name = name;
            Gender = gender;
            IdCard = idCard ?? new IdCard();
            BirthDate = birthDate;
            Contact = contact;
            ContactDetails = contactDetails;
            Address = address;
            BasicArchive = basicArchive ?? new VitalSigns();
            PregnancyArchive = pregnancyArchive ?? new PregnancyArchive();
        }

        public Archive() { }

        public string CardId { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public IdCard IdCard { get; set; } = new IdCard();
        public string Contact { get; set; }
        public string ContactDetails { get; set; }
        public string Address { get; set; }

        /// <summary>
        ///     基本信息记录
        /// </summary>
        public VitalSigns BasicArchive { get; set; } = new VitalSigns();

        /// <summary>
        ///     孕期子档案
        /// </summary>
        public PregnancyArchive PregnancyArchive { get; set; } = new PregnancyArchive();

        public Guid Id { get; set; }

        #region Methods

        public DateTime GetAge()
        {
            var age = BirthDate.Age(DateTime.Now);
            return new DateTime(age.Year, age.Month, age.Day);
        }

        public string GetAgeStr()
        {
            var age = BirthDate.Age(DateTime.Now);
            return $"{age.Year}岁{age.Month}月{(age.Day > 0 ? $"{age.Day}天" : "")}";
        }
        #endregion
    }
}
