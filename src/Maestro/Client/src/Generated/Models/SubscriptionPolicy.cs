// <auto-generated>
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//
// </auto-generated>

namespace Microsoft.DotNet.Maestro.Client.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class SubscriptionPolicy
    {
        /// <summary>
        /// Initializes a new instance of the SubscriptionPolicy class.
        /// </summary>
        public SubscriptionPolicy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SubscriptionPolicy class.
        /// </summary>
        /// <param name="updateFrequency">Possible values include: 'none',
        /// 'everyDay', 'everyBuild'</param>
        public SubscriptionPolicy(string updateFrequency, IList<MergePolicy> mergePolicies)
        {
            UpdateFrequency = updateFrequency;
            MergePolicies = mergePolicies;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'none', 'everyDay',
        /// 'everyBuild'
        /// </summary>
        [JsonProperty(PropertyName = "updateFrequency")]
        public string UpdateFrequency { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "mergePolicies")]
        public IList<MergePolicy> MergePolicies { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (UpdateFrequency == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "UpdateFrequency");
            }
            if (MergePolicies == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "MergePolicies");
            }
        }
    }
}
