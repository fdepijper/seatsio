namespace pinevents.SeatsIo.Service
{
    using Newtonsoft.Json.Linq;
    using PinEvents.SeatsIo.Data;
    using System.Web.Script.Serialization;

    public class UserService
    {
        private string endPoint;
        private Connect.Methods Method;

        /// <summary>
        /// POST https://app.seats.io/api/createUser
        /// </summary>
        public UserData CreateUser(string secretKey)
        {
            Connect connect = new Connect();
            Method = Connect.Methods.POST;
            endPoint = "api/createUser";
            var data = new { secretKey = "9d994af1-89ba-4b62-9997-e989cb9049c9" };
            var jdata = JObject.FromObject(data);
            connect.Request(Method, endPoint, jdata);

            var json = connect.Data;
            var userData = new JavaScriptSerializer().Deserialize<UserData>(json);
            return userData;
        }

    }
}
