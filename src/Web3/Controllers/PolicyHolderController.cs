using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

using Web3.Models;

namespace  Web3.Controllers;

public class PolicyHolderController : Controller
{
    private readonly ILogger<PolicyHolderController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _clientFactory;

    public PolicyHolderController(ILogger<PolicyHolderController> logger, IConfiguration configuration, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _configuration.GetValue<string>("Endpoint") + "/PolicyHolder");

        HttpClient client = _clientFactory.CreateClient();
        HttpResponseMessage response = await client.SendAsync(request);

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
        var endpointUrl = string.Format("{0}/{1}/{2}", _configuration.GetValue<string>("Endpoint"), "PolicyHolder", Id);
        var request = new HttpRequestMessage(HttpMethod.Get, endpointUrl);

        HttpClient client = _clientFactory.CreateClient();
        HttpResponseMessage response = await client.SendAsync(request);

        PolicyHolder policyHolder = new PolicyHolder();

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();

            policyHolder = JsonSerializer.Deserialize<PolicyHolder>(jsonString);
        }

        return View(policyHolder);
    }
}
