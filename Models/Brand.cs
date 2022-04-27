using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClothingSize.Models
{
  public class Brand
  {
    public int BrandId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }

    public static List<Brand> GetBrands()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Brand> brandList = JsonConvert.DeserializeObject<List<Brand>>(jsonResponse.ToString());

      return brandList;
    }

    public static Brand GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Brand brand = JsonConvert.DeserializeObject<Brand>(jsonResponse.ToString());

      return brand;
    }

    public static void Post(Brand brand)
    {
      string jsonBrand = JsonConvert.SerializeObject(brand);
      var apiCallTask = ApiHelper.Post(jsonBrand);
    }

    public static void Put(Brand brand)
    {
      string jsonBrand = JsonConvert.SerializeObject(brand);
      var apiCallTask = ApiHelper.Put(brand.BrandId, jsonBrand);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}