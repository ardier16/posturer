using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PosturerAndroid.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace PosturerAndroid.Services
{
    public class RestService
    {
        HttpClient client;
        const string ApiUrl = "https://posturer.azurewebsites.net/api/";

        public RestService()
        {
            client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public List<Exercise> GetAllExercises()
        {
            List<Exercise> exercises = new List<Exercise>();

            var uri = new Uri(ApiUrl + "exercises");


            var request = HttpWebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        exercises = JsonConvert.DeserializeObject<List<Exercise>>(content);
                    }
                }
            }

            return exercises;
        }

        public Exercise GetExercise(int id)
        {
            Exercise exercise = new Exercise();

            var uri = new Uri(ApiUrl + "exercises/" + id);


            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        exercise = JsonConvert.DeserializeObject<Exercise>(content);
                    }
                }
            }

            return exercise;
        }

        public string SignIn(string username, string password)
        {
            var uri = new Uri(ApiUrl + "account/login");

            var request = (HttpWebRequest)WebRequest.Create(uri);
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

        public void SignUp(string email, string password)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiUrl + "account/register");
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

        public TrainingProgram GetTrainingProgram(string token)
        {
            TrainingProgram program = new TrainingProgram();

            var uri = new Uri(ApiUrl + "trainingprogram/");


            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        program = JsonConvert.DeserializeObject<TrainingProgram>(content);
                    }
                }
            }

            return program;
        }

        public List<PostureLevel> GetPostureLevels(string token)
        {
            List<PostureLevel> levels = new List<PostureLevel>();

            var uri = new Uri(ApiUrl + "posturelevel/");


            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        levels = JsonConvert.DeserializeObject<List<PostureLevel>>(content);
                    }
                }
            }

            return levels;
        }

        public List<Chat> GetChats(string token)
        {
            List<Chat> chats = new List<Chat>();

            var uri = new Uri(ApiUrl + "chat/chats/");


            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        chats = JsonConvert.DeserializeObject<List<Chat>>(content);
                    }
                }
            }

            return chats;
        }

        public List<Message> GetMessages(int chatId, string token)
        {
            List<Message> messages = new List<Message>();

            var uri = new Uri(ApiUrl + "chat/" + chatId);


            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        messages = JsonConvert.DeserializeObject<List<Message>>(content);
                    }
                }
            }

            return messages;
        }

        public User GetUserInfo(string token)
        {
            User user = new User();

            var uri = new Uri(ApiUrl + "account/userinfo");


            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var content = reader.ReadToEnd();
                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        user = JsonConvert.DeserializeObject<User>(content);
                    }
                }
            }

            return user;
        }
    }
}