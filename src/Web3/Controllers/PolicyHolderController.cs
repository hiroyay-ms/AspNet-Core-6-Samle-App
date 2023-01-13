using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Dapr.Client;

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
        var application_id = _configuration.GetValue<string>("DaprId");

        var result = _daprClient.CreateInvokeMethodRequest(HttpMethod.Get, application_id, "PolicyHolder");
        HttpResponseMessage response = await _daprClient.InvokeMethodWithResponseAsync(result);

        List<PolicyHolder> policyHolders = null;

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            policyHolders = JsonSerializer.Deserialize<List<PolicyHolder>>(jsonString);
        }

        return View(policyHolders);
    }

    [HttpGet]
    public async Task<IActionResult> GetDetails(int Id)
    {
        var application_id = _configuration.GetValue<string>("DaprId");

        var result = _daprClient.CreateInvokeMethodRequest(HttpMethod.Get, application_id, $"PolicyHolder/{Id}");
        HttpResponseMessage response = await _daprClient.InvokeMethodWithResponseAsync(result);

        PolicyHolder policyHolder = new PolicyHolder();

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            policyHolder = JsonSerializer.Deserialize<PolicyHolder>(jsonString);
        }

        return View(policyHolder);
    }
}
