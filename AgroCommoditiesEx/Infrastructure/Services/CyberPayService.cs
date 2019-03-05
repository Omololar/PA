using Domain.Interface.Services;
using Domain.Models;
using Domain.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
//using System.Xml.Linq;

namespace Infrastructure.Services
{
    public class CyberPayService : IPaymentService
    {
        private readonly IConfiguration _config;
        public CyberPayService(IConfiguration config)
        {

            _config = config;

        }
        public async Task<List<BankDetailsModel>> GetBanks()
        {
            WebClient client = new WebClient();
            JObject response = null;
            var TransactionUrl = _config.GetSection(Constants.CYBERPAY_BANKS_URL).Value;
            try
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                string _response = await client.DownloadStringTaskAsync(new Uri(TransactionUrl));
                response = JObject.Parse(_response);

            }
            catch (Exception)
            {
                response = null;

            }

            if (response != null && response.GetValue("succeeded").Value<bool>())
            {
                JArray data = response.GetValue("data").Value<JArray>();

                List<BankDetailsModel> x = data.ToObject<List<BankDetailsModel>>();

                return x;
            }
            throw new Exception("CyberPay Client currently not avaliable");

        }

    }

}
