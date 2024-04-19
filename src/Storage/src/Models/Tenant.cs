using System;
using System.Diagnostics;

namespace IdentityServer4.Models
{
    /// <summary>
    /// Models a Tenant 
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public class Tenant
    {
        private string DebuggerDisplay => TenantName ?? $"{{{typeof(Tenant)}}}";

        /// <summary>
        /// Unique Id of the Tenant
        /// </summary>
        public Guid TenantId { get; set; }
        
        /// <summary>
        /// Tenant Name - used for logging. 
        /// </summary>
        public string TenantName { get; set; }
        
        /// <summary>
        /// Specifies if tenant is enabled (defaults to <c>true</c>)
        /// </summary>
        public bool Enabled { get; set; }
   
    }
}