using HTTP.Common;
using HTTP.Cookies;
using HTTP.Cookies.Contracts;
using HTTP.Enums;
using HTTP.Exceptions;
using HTTP.Headers;
using HTTP.Headers.Contracts;
using HTTP.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeadersCollection();
            this.Cookies = new HttpCookiesCollection();

            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                    .Split(Environment.NewLine);

            string[] requestLine = splitRequestContent[0]
                .Trim().
                Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
                throw new BadRequestException();

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());

            this.ParseCookies();
            bool requestHasBody = splitRequestContent.Length > 1;
            bool requestHasQueryParameters = this.Url.Contains('?');
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody, requestHasQueryParameters);
        }

        private void ParseCookies()
        {
            if (!this.Headers.ContainsHeader("Cookie"))
                return;

            var flatCookiesCollection = this.Headers.GetHeader("Cookie").Value;
            var splitCookie = flatCookiesCollection
                .Split("; ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var cookie in splitCookie)
            {
                var cookieKeyValuePair = cookie.Split("=", 2);
                if (cookieKeyValuePair.Length != 2)
                    throw new BadRequestException();
                var cookieName = cookieKeyValuePair[0];
                var cookieValue = cookieKeyValuePair[1];
                this.Cookies.Add(new HttpCookie(cookieName, cookieValue));
            }
        }

        private void ParseRequestParameters(
            string bodyParameters, 
            bool requestHasBody,
            bool requestHasQueryParameters)
        {
            if (requestHasQueryParameters)
                this.ParseQueryParameters(this.Url);
            if (requestHasBody)
                this.ParseFormDataParameters(bodyParameters);
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            var formDataKeyValuePairs = bodyParameters
                .Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(formDataKeyValuePairs, this.FormData);
        }

        private void ExtractRequestParameters(
            string[] parameterKeyValuePairs,
            Dictionary<string, object> parametersCollection)
        {
            foreach (var parameterKeyValuePair in parameterKeyValuePairs)
            {
                var keyValuePair = parameterKeyValuePair.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }
                var parameterKey = keyValuePair[0];
                var parameterValue = keyValuePair[1];

                parametersCollection[parameterKey] = parameterValue;
            }
        }

        private void ParseQueryParameters(string url)
        {
            var queryParameters = url
                .Split(new[] { '?', '#' })
                .Skip(1)
                .ToArray()
                .FirstOrDefault();

            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters
                .ToString()
                .Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractRequestParameters(queryKeyValuePairs, this.QueryData);
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestPath()
        {
            var path = this.Url?.Split('?').FirstOrDefault();
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var parseSuccess = System.Enum.TryParse<HttpRequestMethod>(requestLine[0], out var parsedMethod);
            if (!parseSuccess)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedMethod;
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            if (requestLine.Length == 3 && 
                requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }
            return false;
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }
        public IHttpCookiesCollection Cookies { get; }

        public HttpRequestMethod RequestMethod { get; private set; }
    }
}
