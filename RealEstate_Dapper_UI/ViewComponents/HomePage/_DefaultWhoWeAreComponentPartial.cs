﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    
    public class _DefaultWhoWeAreComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var client2=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44330/api/WhoWeAreDetail");
            var responseMessage2 = await client.GetAsync("https://localhost:44330/api/Services");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonValue= await responseMessage.Content.ReadAsStringAsync();
                var jsonValue2 = await responseMessage2.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonValue);
                var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonValue2);
                ViewBag.title = value.Select(x=>x.Title).FirstOrDefault();
                ViewBag.subTitle = value.Select(x => x.SubTitle).FirstOrDefault();
                ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
                ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
                return View(value2);

            }
            return View();
        }
    }
}
