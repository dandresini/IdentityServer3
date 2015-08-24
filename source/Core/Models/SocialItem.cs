using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.Models
{
    public enum SocialProvider
    {
        Facebook,
        Google,
        Twitter
    }

    public class Providers
    {
        private Dictionary<string, string> url_provider_check = new Dictionary<string, string>(){
            {SocialProvider.Facebook.ToString(),@"https://graph.facebook.com/v2.2/debug_token?input_token={0}&access_token={1}"},
            {SocialProvider.Google.ToString(),@"https://www.googleapis.com/oauth2/v1/tokeninfo?access_token={0}"},
            {SocialProvider.Twitter.ToString(),@"https://api.twitter.com/1.1/account/verify_credentials.json"}
        };

        public Dictionary<string, string> items { get; set; }
        public SocialProvider socialprovider {get;set;}
        public string application_id { get; set; }

        public string Url_Token_Validate(string provider)
        {
            return url_provider_check[provider] ?? "";
        }

        public Providers(){
            items = new Dictionary<string, string>();
        }

        public Providers(SocialProvider socialprovider,string application_id):this ()
        {
            this.socialprovider = socialprovider;
            this.application_id = application_id;
        }

        public Providers(SocialProvider socialprovider, string application_id, Dictionary<string, string> items)
            : this(socialprovider, application_id)
        {
            this.items = items;
        }

    }

    
}
