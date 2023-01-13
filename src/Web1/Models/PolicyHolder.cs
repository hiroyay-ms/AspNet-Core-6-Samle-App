using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web1.Models;

public class PolicyHolder
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("personId")]
    public int PersonId { get; set; }

    [JsonPropertyName("personName")]
    public string? PersonName { get; set; }

    [JsonPropertyName("active")]
    public bool Active { get; set; } = false;

    [JsonPropertyName("startDate")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("endDate")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("policyNumber")]
    public string? PolicyNumber { get; set; }

    [JsonPropertyName("policyId")]
    public int PolicyId { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }

    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }

    [JsonPropertyName("policyAmount")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal PolicyAmount { get; set; }

    [JsonPropertyName("deductible")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal Deductible { get; set; }

    [JsonPropertyName("outOfPocketMax")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal OutOfPocketMax { get; set; }

    [JsonPropertyName("effectiveDate")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime EffectiveDate { get; set; }

    [JsonPropertyName("expirationDate")]
    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
    public DateTime ExpirationDate { get; set; }
}
