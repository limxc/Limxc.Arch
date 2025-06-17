using System;
using Limxc.Arch.Core.Shared.Domains;

namespace Limxc.Arch.Core.Domains.Users
{
    public class User : IEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        /// <summary>
        ///     Base64 Image
        /// </summary>
        public string Signature { get; set; }

        public UserRole UserRole { get; set; }
        public Guid Id { get; set; }
    }
}
