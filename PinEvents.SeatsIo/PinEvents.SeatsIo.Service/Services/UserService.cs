namespace PinEvents.SeatsIo.Service
{
    using Newtonsoft.Json.Linq;
    using PinEvents.SeatsIo;
    using PinEvents.SeatsIo.Data;
    using System.Web.Script.Serialization;

    public class UserService
    {
        private string endPoint;
        private Connect.Methods Method;

        /// <summary>
        /// POST https://app.seats.io/api/createUser
        /// </summary>
        /// <see cref="http://www.seats.io/docs/api#api-reference-users-creating-users"/>
        public UserData CreateUser(string secretKey)
        {
            Connect connect = new Connect();
            Method = Connect.Methods.POST;
            endPoint = "api/createUser";
            var data = new { secretKey = secretKey };
            var jdata = JObject.FromObject(data);
            connect.Request(Method, endPoint, jdata);

            var json = connect.Data;
            var userData = new JavaScriptSerializer().Deserialize<UserData>(json);
            return userData;
        }

    }
}
