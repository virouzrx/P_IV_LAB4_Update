﻿using RestSharp;
using System.Threading.Tasks;

namespace P4_Lab4_update
{
    public class Website
    {
        public Website(string baseLink)
        {
            _client = new RestClient(baseLink);
        }

        public RestClient _client { get; private set; }

        public string Download(string path)
        {
            var request = new RestRequest(path, Method.GET);
            var response = _client.Execute(request);
            return response.Content;
        }

        public Task<IRestResponse> DownloadAsync(string path)
        {
            var request = new RestRequest(path, Method.GET);
            var response = _client.ExecuteAsync(request);
            return response;
        }
    }
}