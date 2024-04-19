#pragma warning disable 1591
using System;
using System.Collections.Generic;

namespace IdentityServer4.EntityFramework.Entities;

    public class Tenant
    {
        public int Id { get; set; }
        public Guid TenantId { get; set; }
        public string TenantName { get; set; }
        public bool Enabled { get; set; }
        public List<Client> TenantClients { get; set; }
        public List<IdentityResource> TenantIdentityResources;
    }
