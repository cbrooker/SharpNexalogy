using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{
  
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string originalName { get; set; }
        public string dataFileVersion { get; set; }
        public string lexiconFileVersion { get; set; }
        public string maxTopWords { get; set; }
        public string maxTopCoWords { get; set; }
        public string maxTopPublishers { get; set; }
        public string uneditedLexiconFileName { get; set; }
        public string statusCode { get; set; }
        public string language { get; set; }
        public string dataCaptureLocked { get; set; }
        public string filterKeywords { get; set; }
        public string type { get; set; }
        public string userDefinedStatusId { get; set; }
        public string userDefinedId { get; set; }
        public string projectLeader { get; set; }
        public string projectManager { get; set; }
        public string creationDate { get; set; }
        public string modificationDate { get; set; }
        public string creator { get; set; }
        public string lastUpdatedBy { get; set; }
        public string client { get; set; }
        public string defaultGeneralFilterId { get; set; }
        public object userDefinedFolderId { get; set; }
        public string status { get; set; }
        public string kijThreshold { get; set; }
        public string dataCount { get; set; }
        public string importedSearchCount { get; set; }
        public string isPublic { get; set; }
        public object searchCount { get; set; }
        public string sdi { get; set; }
        public int isAutocaptured { get; set; }
    }

    public class ProjectsResponse
    {
        public List<Project> projects { get; set; }
        public bool sortDescending { get; set; }
        public string sort { get; set; }
        public bool success { get; set; }
    }
}
