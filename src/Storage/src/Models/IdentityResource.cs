// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IdentityServer4.Models
{
    /// <summary>
    /// Models a user identity resource.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class IdentityResource : Resource
    {
        private string DebuggerDisplay => Name ?? $"{{{typeof(IdentityResource)}}}";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityResource"/> class.
        /// </summary>
        public IdentityResource()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityResource"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="userClaims">List of associated user claims that should be included when this resource is requested.</param>
        /// <param name="tenant">Tenant object representing tenant scope of the IdentityResource.</param>
        public IdentityResource(Tenant tenant, string name, IEnumerable<string> userClaims)
            : this(tenant, name, name, userClaims)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityResource"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="displayName">The display name.</param>
        /// <param name="userClaims">List of associated user claims that should be included when this resource is requested.</param>
        /// <param name="tenant">Tenant object representing tenant scope of the IdentityResource.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        /// <exception cref="System.ArgumentException">Must provide at least one claim type - claimTypes</exception>
        public IdentityResource(Tenant tenant, string name, string displayName, IEnumerable<string> userClaims)
        {
            if (tenant.IsMissing()) throw new ArgumentNullException(nameof(tenant));
            if (name.IsMissing()) throw new ArgumentNullException(nameof(name));
            if (userClaims.IsNullOrEmpty()) throw new ArgumentException("Must provide at least one claim type", nameof(userClaims));

            Tenant = tenant;
            Name = name;
            DisplayName = displayName;

            foreach(var type in userClaims)
            {
                UserClaims.Add(type);
            }
        }
        
        /// <summary>
        /// Tenant scope of the IdentityResource
        /// </summary>
        public Tenant Tenant { get; set; }

        /// <summary>
        /// Specifies whether the user can de-select the scope on the consent screen (if the consent screen wants to implement such a feature). Defaults to false.
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        /// Specifies whether the consent screen will emphasize this scope (if the consent screen wants to implement such a feature). 
        /// Use this setting for sensitive or important scopes. Defaults to false.
        /// </summary>
        public bool Emphasize { get; set; } = false;
    }
}
