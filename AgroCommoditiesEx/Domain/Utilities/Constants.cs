using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Utilities
{
    public static class Constants
    {
        public static string ADMIN_ROLE = "Administrators";
        public static string ADMIN_USERNAME = "AdminUser";
        public static string ADMIN_EMAIL = "adminuser@agroex.ng";

        public const string USER_TYPE = "User:Types";

        public const string CYBERPAY_BANKS_URL = "CyberPayBanksRequest:banks";


        public const string CYBERPAY_INTEGRATION_KEY = "CyberPay:IntegrationKey";

        public const string CYBERPAY_REQUEST_URL = "CyberPayRequestUrl:demorequest";
        public const string CYBERPAY_RESPONSE_URL = "CyberPayResponseUrl:demoresponse";

        public const string AGROEX_URL = "AgroEXHostUrl:DemoUrl";

        public const string AGROEX_STORE_COST = "AgroEXDefaultStorePrice:Price";

        public static class AuthScheme
        {
            public const string Cookie = "cookie";
            public const string OIDC = "oidc";
        }


        public static class Cors
        {
            public const string EnableAll = "EnableAll";
        }
        public static class Actors
        {
            public const string Billing = "BillingActor";
            public const string Notification = "NotificationActor";

        }
        public static class Token
        {
            public const string RefreshToken = "RefreshToken";
            public const string AccessToken = "AccessToken";
        }
    }

}
