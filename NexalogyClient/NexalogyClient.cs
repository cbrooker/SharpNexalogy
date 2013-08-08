using System;
using RestSharp;
using RestSharp.Validation;
using SharpNexalogy.Model;


namespace SharpNexalogy
{
    public class NexalogyClient
    {
        private const String BaseUrl = "https://api.nexalogy.com";
        private readonly string _apiKey;

        public NexalogyClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        private T Execute<T>(IRestRequest request) where T : new()
        {
            if (request == null) throw new ArgumentNullException("request");
            var client = new RestClient
                    {
                        BaseUrl = BaseUrl
                    };
            request.AddParameter("api_key", _apiKey, ParameterType.UrlSegment);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var nexalogyException = new ApplicationException(message, response.ErrorException);
                throw nexalogyException;
            }
            return response.Data;
        }
        private T ExecutePost<T>(IRestRequest request) where T : new()
        {
            var client = new RestClient { BaseUrl = BaseUrl };
            request.Method = Method.POST;
            request.AddParameter("api_key", _apiKey);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var nexalogyException = new ApplicationException(message, response.ErrorException);
                throw nexalogyException;
            }
            return response.Data;
        }
        
        #region Project

            public ProjectsResponse ProjectGetList(int status = 1) {
                var request = new RestRequest { Resource = "project/getList" };
                request.AddParameter("status", status);
                return ExecutePost<ProjectsResponse>(request);
            }

            public Project ProjectGet(string projectId)
            {
                Require.Argument("projectId", projectId);

                var request = new RestRequest {Resource = "project/get", RootElement = "project"};
                request.AddParameter("projectId", projectId);
                return ExecutePost<Project>(request);
            }


            public Project ProjectCreate(Project project)
            {
                Require.Argument("name", project.name);
                Require.Argument("lang", project.language);
                
                var request = new RestRequest { Resource = "project/create", RootElement = "project" };
                request.AddParameter("name", project.name);
                request.AddParameter("lang", project.language);
                request.AddParameter("type", project.type);
                request.AddParameter("projectLeader", project.projectLeader);
                request.AddParameter("projectManager", project.projectManager);
                request.AddParameter("client", project.client);
                request.AddParameter("maxTopWords", project.maxTopWords);
                request.AddParameter("maxTopCoWords", project.maxTopCoWords);
                request.AddParameter("maxTopPublishers", project.maxTopPublishers);
                request.AddParameter("isPublic", project.isPublic);
                request.AddParameter("userDefinedId", project.userDefinedId);
                request.AddParameter("userDefinedStatusId", project.userDefinedStatusId);
                request.AddParameter("userDefinedFolderId", project.userDefinedFolderId);
                
                return ExecutePost<Project>(request);

            }



        #endregion

    }
}
