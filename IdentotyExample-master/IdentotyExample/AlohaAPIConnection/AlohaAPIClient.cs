using IdentotyExample.Models.ModelMenu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static IdentotyExample.Enums.Enums;

public class AlohaAPIClient
{
    // private readonly HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    public AlohaAPIClient(IHttpClientFactory client)
    {
        _httpClientFactory = client;
    }

    private HttpClient HttpClient { get => _httpClientFactory.CreateClient("AlohaAPIClient"); }

    public async Task<Root> GetNearbySitesBySearchTerm(string searchTerm, bool? getNearbySitesForFirstGeocodeResult = true, bool? includeAllSites = false, int? offset = 0, int? limit = 5)
    {

        StringBuilder sb = new StringBuilder($"v1/NearbySites/{searchTerm}?getNearbySitesForFirstGeocodeResult={getNearbySitesForFirstGeocodeResult}&includeAllSites={includeAllSites}&offset={offset}&limit={limit}");
        string url = sb.ToString();
        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();

        Root root = JsonSerializer.Deserialize<Root>(serializedJson);
        return   root;
    }




    public async Task<List<NearbySite>> GetNearbySitesByLatitudeAndLongitude(double latitude, double longitude, string orderMode = "Pickup", int offset = 0, int limit = 5, bool includeAllSites = false, string companyCode = "DLEC001")
    {
        //  StringBuilder sb = new StringBuilder($"v1/NearbySites/{latitude}/{longitude}?orderMode={orderMode}&offset={offset}&limit={limit}&includeAllSites={includeAllSites}&companyCode={companyCode}");
           
        var urlBuilder = new StringBuilder($"v1/NearbySites/{latitude}/{longitude}?&offset={offset}&limit={limit}&includeAllSites={includeAllSites}");
        if (orderMode != null)
            urlBuilder.Append($"&orderMode={orderMode}");
        if (companyCode != null)
            urlBuilder.Append($"&companyCode={companyCode}");
        string url = urlBuilder.ToString();
        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();

        List<NearbySite> root = JsonSerializer.Deserialize<List<NearbySite>>(serializedJson);
        return root;
    }


    public async Task<RootMenus> GetMenu(int siteId, DateTime promiseTime = new DateTime(), bool includeInvisible = false, string orderMode = "Delivery")
    {
        StringBuilder sb = new StringBuilder($"v1/Menus/{siteId}?promiseTime={promiseTime}&includeInvisible={includeInvisible}&orderMode={orderMode}");
        string url = sb.ToString();
        using HttpResponseMessage request = await HttpClient.GetAsync(url);
        string json = await request.Content.ReadAsStringAsync();

        RootMenus root2 = JsonSerializer.Deserialize<RootMenus>(json);
        return root2;
    }


    public async Task<string> GetTimes(int siteId, bool noCache = false, string orderMode = "Delivery")
    {
        StringBuilder sb = new StringBuilder($"v1/Times/{siteId}/{orderMode}?noCache={noCache}");
        string url = sb.ToString();
        using HttpResponseMessage response = await HttpClient.GetAsync(url);
        string serializedJson = await response.Content.ReadAsStringAsync();
        return serializedJson;
    }


    public async Task<RootOrder> PutOrder(Order order,int siteId, bool verbose = false)
    {
        string url = ($"v1/Orders/{siteId}?verbose={verbose}");
        
        var json = JsonSerializer.Serialize(order);
        HttpContent httpContent= new StringContent(json,Encoding.UTF8,"application/json");

        var response = await HttpClient.PutAsync(url, httpContent);
        string serializedJson = await response.Content.ReadAsStringAsync();

        RootOrder rootOrder = JsonSerializer.Deserialize<RootOrder>(serializedJson);
        return rootOrder;


    }





}

