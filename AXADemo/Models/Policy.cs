using Newtonsoft.Json;
using System;

namespace AXADemo.Models
{
    /// <summary>
    /// Policy Register
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Plicy Identificator
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Policy Amount Insured
        /// </summary>
        [JsonProperty(PropertyName = "amountInsured")]
        public double AmountInsured { get; set; }

        /// <summary>
        /// Policy Email
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string EMail { get; set; }

        /// <summary>
        /// Policy Inception Date
        /// </summary>
        [JsonProperty(PropertyName = "inceptionDate")]
        public DateTime InceptionDate { get; set; }

        /// <summary>
        /// Policy Installment Payment
        /// </summary>
        [JsonProperty(PropertyName = "installmentPayment")]
        public bool InstallmentPayment { get; set; }

        /// <summary>
        /// Policy Client Identificator
        /// </summary>
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId { get; set; }
    }
}