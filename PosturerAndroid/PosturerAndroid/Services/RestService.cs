using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

using PosturerAndroid.Models;

namespace PosturerAndroid.Services
{
    public static class RestService
    {
        private static HttpClient client = new HttpClient
        {
            MaxResponseContentBufferSize = 256000
        };

        private static string apiUrl = "https://posturer.azurewebsites.net/api";

        public static List<Exercise> GetAllExercises()
        {
            return Get<List<Exercise>>(apiUrl + "/exercises");
        }

        public static Exercise GetExercise(int id)
        {
            return Get<Exercise>(apiUrl + "/exercises/" + id);
        }

        public static TrainingProgram GetTrainingProgram(string token)
        {
            return Get<TrainingProgram>(apiUrl + "/trainingprogram", token);
        }

        public static List<PostureLevel> GetPostureLevels(string token)
        {
            return Get<List<PostureLevel>>(apiUrl + "/posturelevel", token);
        }

        public static PostureLevel GetCurrentPostureLevel(string token)
        {
            return Get<PostureLevel>(apiUrl + "/posturelevel/current", token);
        }

        public static List<Chat> GetChats(string token)
        {
            return Get<List<Chat>>(apiUrl + "/chat/chats", token);
        }

        public static List<ChatMessage> GetMessages(int chatId, string token)
        {
            return Get<List<ChatMessage>>(apiUrl + "/chat/" + chatId, token);
        }

        public static User GetUserInfo(string token)
        {
            return Get<User>(apiUrl + "/account/userinfo", token);
        }

        public static string SignIn(string username, string password)
        {
            var request = (HttpWebRequest)WebRequest.Create(apiUrl + "/account/login");
            var postData = "userName=" + username;
            postData += "&password=" + password;
            postData += "&grant_type=password";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return (string)JObject.Parse(responseString)["access_token"];
            }
            else
            {
                throw new WebException("Incorrect user name or password");
            }
        }

        public static void SignUp(string email, string password)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl + "/account/register");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    EMail = email,
                    Password = password
                });

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        private static T Get<T>(string url, string token = "") where T : new()
        {
            T result = new T();

            var request = HttpWebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();

                    result = JsonConvert.DeserializeObject<T>(content);
                }
            }

            return result;
        }
    }
}