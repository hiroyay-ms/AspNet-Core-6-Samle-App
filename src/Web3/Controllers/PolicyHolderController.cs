using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Dapr.AspNetCore;

using Web3.Models;

namespace  Web3.Controllers;

public class PolicyHolderController : Controller
{
    private readonly ILogger<PolicyHolderController> _logger;
    private readonly IConfiguration _configuration;
    private readonly DaprClient _daprClient;

    public PolicyHolderController(ILogger<PolicyHolderController> logger, IConfiguration configuration, DaprClient daprClient)
    {
        _logger = logger;
        _configuration = configuration;
        _daprClient = daprClient;
    }

    public async Task<IActionResult> Index()
    {
        var endpointUrl = string.Format("{0}/{1}", _configuration.GetValue<string>("Endpoint"), "PolicyHolder");

        HttpClient client = _daprClient.CreateInvokeHttpClient();

        List<PolicyHolder> policyHolders = null;

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await client.GetStringAsync(endpointUrl);

            policyHolders = JsonSerializer.Deserialize<List<PolicyHolder>>(jsonString);
        }

        return View(policyHolders);
    }

    [HttpGet]
    public async Task<IActionResult> GetDetails(int Id)
    {
        var endpointUrl = string.Format("{0}/{1}/{2}", _configuration.GetValue<string>("Endpoint"), "PolicyHolder", Id);

        HttpClient client = _daprClient.CreateInvokeHttpClient();

        PolicyHolder policyHolder = new PolicyHolder();

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await client.GetStringAsync(endpointUrl);

            policyHolder = JsonSerializer.Deserialize<PolicyHolder>(jsonString);
        }

        return View(policyHolder);
    }
}
