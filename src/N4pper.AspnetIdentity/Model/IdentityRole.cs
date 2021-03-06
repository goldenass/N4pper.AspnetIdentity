﻿using System;
using System.Collections.Generic;
using System.Text;

namespace N4pper.AspnetIdentity.Model
{
    /// <summary>
    /// The default implementation of <see cref="IdentityRole{TKey}"/> which uses a string as the primary key.
    /// </summary>
    public class IdentityRole : IdentityRole<string>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to form a new GUID string value.
        /// </remarks>
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

    /// <summary>
    /// Represents a role in the identity system
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the role.</typeparam>
    public class IdentityRole<TKey> : IGraphEntity where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole{TKey}"/>.
        /// </summary>
        public IdentityRole() { }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole{TKey}"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }

        /// <summary>
        /// Gets or sets the primary key for this role.
        /// </summary>
        public virtual TKey Id { get; set; }

        public virtual long? EntityId { get; set; }
        /// <summary>
        /// Gets or sets the name for this role.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the normalized name for this role.
        /// </summary>
        public virtual string NormalizedName { get; set; }

        /// <summary>
        /// A random value that should change whenever a role is persisted to the store
        /// </summary>
        public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Returns the name of the role.
        /// </summary>
        /// <returns>The name of the role.</returns>
        public override string ToString()
        {
            return Name;
        }
        public bool Equals(TKey obj)
        {
            return Id.Equals(obj);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (obj is IdentityRole)
            {
                IdentityRole other = obj as IdentityRole;
                return other.Id.Equals(Id);
            }
            else if (obj is TKey)
            {
                return Equals((TKey)obj);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
