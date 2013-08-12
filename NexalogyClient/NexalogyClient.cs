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


            public FindResults ProjectFind(string name = "", string creator = "", string createdMin = "", string createdMax = "", string modifiedMin = "", string modifiedMax = "")
            {
                //This Json returns a key that's dynamic, not sure how to handle that yet. Hardcoded so that it works.
                var request = new RestRequest { Resource = "project/find" };

                if (name != string.Empty) request.AddParameter("name", name);
                if (creator != string.Empty) request.AddParameter("creator", creator);
                if (createdMin != string.Empty) request.AddParameter("createdMin", createdMin);
                if (createdMax != string.Empty) request.AddParameter("createdMax", createdMax);
                if (modifiedMin != string.Empty) request.AddParameter("modifiedMin", modifiedMin);
                if (modifiedMax != string.Empty) request.AddParameter("modifiedMax", modifiedMax);

                return ExecutePost<FindResults>(request);
            }


        #endregion

        #region Lexicon

            public LexiconResults LexiconGenerate(string projectId, bool autoLematized = true, bool globalUpdate = true)
            {
                Require.Argument("projectId", projectId);

                var request = new RestRequest { Resource = "lexicon/generate" };
                request.AddParameter("projectId", projectId);
                request.AddParameter("autoLematized", autoLematized);
                request.AddParameter("globalUpdate", globalUpdate);

                return ExecutePost<LexiconResults>(request);
            }

        #endregion

        #region Search
            //TODO: Test
            public SearchCreateResults SearchCreate(Search search)
            {
                Require.Argument("projectId", search.projectId);
                Require.Argument("name", search.name);
                Require.Argument("type", search.type);

                var request = new RestRequest { Resource = "search/create" };
                request.AddParameter("projectId", search.projectId);
                request.AddParameter("name", search.name);
                request.AddParameter("type", search.type);

                return ExecutePost<SearchCreateResults>(request);
            }
            //TODO: Test
            public SearchGetResults SearchGet(int searchId)
            {
                Require.Argument("searchId", searchId);

                var request = new RestRequest { Resource = "search/get" };
                request.AddParameter("searchId", searchId);
                return ExecutePost<SearchGetResults>(request);
            }
            //TODO: Test
            public SearchGetListResults SearchGetList(int projectId)
            {
                Require.Argument("projectId", projectId);

                var request = new RestRequest { Resource = "search/getlist" };
                request.AddParameter("projectId", projectId);
                return ExecutePost<SearchGetListResults>(request);
            }


        #endregion

        #region AutoCapture

        public AutoCaptureRunResults AutocaptureRun(string projectId)
        {
            Require.Argument("projectId", projectId);

            var request = new RestRequest { Resource = "autocapture/run" };
            request.AddParameter("projectId", projectId);
            return ExecutePost<AutoCaptureRunResults>(request);
        }
        
        //TODO: Test
        public AutoCaptureRunResults AutocaptureStart(string projectId, string interval)
        {
            //interval = "10mins | 15mins | 20mins | 30mins | hour | 2hours | 4hours | 6hours | 12hours | 24hours"
            Require.Argument("projectId", projectId);
            Require.Argument("interval", projectId);

            var request = new RestRequest { Resource = "autocapture/start" };
            request.AddParameter("projectId", projectId);
            request.AddParameter("interval", interval);
            return ExecutePost<AutoCaptureRunResults>(request);
        }
        //TODO: Test
        public AutoCaptureRunResults AutocaptureStop(string projectId)
        {
            Require.Argument("projectId", projectId);

            var request = new RestRequest { Resource = "autocapture/stop" };
            request.AddParameter("projectId", projectId);
            return ExecutePost<AutoCaptureRunResults>(request);
        }
        public AutoCaptureStatusResults AutocaptureStatus(string projectId)
        {
            Require.Argument("projectId", projectId);

            var request = new RestRequest { Resource = "autocapture/status" };
            request.AddParameter("projectId", projectId);
            return ExecutePost<AutoCaptureStatusResults>(request);
        }


        #endregion

        #region Import

        //TODO: Test
        /// <summary>
        /// Import data from searches designed in project
        /// if searches have not been captured they will be captured
        /// you can provide either a series of search ids or a projectId
        /// if you provide both, the projectId will be ignored
        /// if you provide mulitple searches, they will be imported into
        /// whichever project they belong to
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="searchIds"></param>
        /// <param name="reset"></param>
        /// <param name="regenerateLexicon"></param>
        public ImportSearchResults ImportSearch(int projectId, string searchIds, bool reset = false, bool regenerateLexicon = true)
        {
            Require.Argument("projectId", projectId);
            Require.Argument("searchIds", searchIds);

            var request = new RestRequest { Resource = "search/create" };
            request.AddParameter("projectId", projectId);
            request.AddParameter("searchIds", searchIds);

            return ExecutePost<ImportSearchResults>(request);
        }


        #endregion

        #region Jobs

        public JobStatusResults JobsStatus(int jobId)
        {
            Require.Argument("jobId", jobId);

            var request = new RestRequest { Resource = "jobs/status" };
            request.AddParameter("jobId", jobId);

            return ExecutePost<JobStatusResults>(request);
        }


        #endregion

        #region Reports

        public enum ReportType
        {
            aspect_timeline,
            aspect_treemap,
            lexical_map,
            timeline,
            top_hashtags,
            top_links,
            top_publishers,
            top_users,
            top_words,
            retweet_stats,
            top_interactions,
            interactions_map,
            publisher_map,
            duplicate_posts_vs_unique,
            results_by_search,
            publisher_distribution,
            publisher_distribution_alt,
            searches_overlaping,
            pareto_distribution,
            datatype_distribution,
            datasift_sentiment_distribution,
            datasift_entities,
            datasift_topics
        }
        public enum ReportFormat
        {
            json,
            widget
        }

        /// <summary>
        /// Use this method to generate a report of a specified type.
        /// Reports generation is an asynchronous method, as some of the analytics are time consuming
        /// Generated reports can be obtained by calling the "reports/get/" after one has called
        /// this method.
        /// to obtain a list of analytics that are available, use reports/getTypes
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="type">The type of analyctic to generate. Chose between :
        /// aspect_timeline
        /// aspect_treemap
        /// lexical_map
        /// timeline
        /// top_hashtags
        /// top_links
        /// top_publishers
        /// top_users
        /// top_words
        /// retweet_stats
        /// top_interactions
        /// interactions_map
        /// publisher_map
        /// duplicate_posts_vs_unique
        /// results_by_search
        /// publisher_distribution
        /// publisher_distribution_alt
        /// searches_overlaping
        /// pareto_distribution
        /// datatype_distribution
        /// datasift_sentiment_distribution(only datasift projects)
        /// datasift_entities(only datasift projects)
        /// datasift_topics(only datasift projects)</param>
        /// <param name="limit">The limit of posts to analyse. Putting 0 means to analyze all the data.</param>
        /// <param name="options">JSON containing extra options to configure the report generation (Not in documentation as to what should in the JSON file)</param>
        public ReportsGenerateResults ReportsGenerate(int projectId, ReportType type, int limit = 0, string options = "")
        {
            Require.Argument("projectId", projectId);
            Require.Argument("type", type);

            var request = new RestRequest { Resource = "reports/generate" };
            request.AddParameter("projectId", projectId);
            request.AddParameter("type", type);
            request.AddParameter("limit", limit);
            request.AddParameter("options", options);

            return ExecutePost<ReportsGenerateResults>(request);
        }

        /// <summary>
        /// This method will return a specific report based on the type requested.
        /// 
        /// After one has imported data into a project and subsequently called
        /// /reports/generate to create the reports, one can call this method to retrieve them.
        /// 
        /// Reports can be retrieved in 2 formats, either as 'json', which will return the data
        /// of the report, or as 'widget', which will return embeddable html.
        /// 
        /// in the case of the 'json' format, the data from the report will be placed in
        /// the 'data' property of the JSON response object
        /// 
        /// for widgets, the embeddable source html will be contained in a property
        /// called 'widget'
        /// 
        /// the options field permit to specify options for widgets only, that apply to the widget you're trying to get.
        /// Unknown options or invalid options will be ignored
        /// More documentation to follow
        /// </summary>
        /// <param name="projectId">the id of the project</param>
        /// <param name="type">the type of analytic to fetch. use /reports/getTypes to get a list of available reports</param>
        /// <param name="format">format in which to receive the report, Either 'json' or 'widget'</param>
        /// <param name="accessibility">could be public for public widget, or private for internal application usage</param>
        /// <param name="options">JSON containing extra options to configure widgets</param>
        public void ReportsGet(int projectId, ReportType type, ReportFormat format, string accessibility = "private", string options = null)
        {
            Require.Argument("projectId", projectId);
            Require.Argument("type", type);
            Require.Argument("format", format);

            var request = new RestRequest { Resource = "reports/get" };
            request.AddParameter("projectId", projectId);
            request.AddParameter("type", type);
            request.AddParameter("format", format);

            request.AddParameter("accessibility", accessibility);
            request.AddParameter("options", options);

           // return ExecutePost<ReportsGenerateResults>(request);

        }


        #endregion

    }
}

