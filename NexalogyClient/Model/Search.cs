using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpNexalogy.Model
{
    public class Search
    {
      
        /// <summary>
        /// twitter | facebook | gbs | datasift | rss
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// The id of the project
        /// </summary>
        public string projectId { get; set; }

        /// <summary>
        /// The Search name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Exact phrase
        /// </summary>
        public string exactPhrase { get; set; }

        /// <summary>
        /// The search query CSDL. Only for Datasift
        /// </summary>
        public string query { get; set; }

        /// <summary>
        /// The post filter. Only for Datasift
        /// </summary>
        public string post_filter_csdl { get; set; }
        
        /// <summary>
        /// The And word list
        /// </summary>
        public string ands { get; set; }
        
        /// <summary>
        /// The Or Word list
        /// </summary>
        public string ors { get; set; }
        
        /// <summary>
        /// The Not word list
        /// </summary>
        public string nots { get; set; }
        
        /// <summary>
        /// Geo-location if applicable
        /// </summary>
        public string latitude { get; set; }
        /// <summary>
        /// Geo-location if applicable
        /// </summary>
        public string longitude { get; set; }
        
        /// <summary>
        /// Geo-location if applicable
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string radius { get; set; }
        /// <summary>
        ///  Use Km / miles
        /// </summary>
        public string metric { get; set; }
        
        /// <summary>
        /// Hashtag
        /// </summary>
        public string tag { get; set; }
        /// <summary>
        /// The slices in JSON format. Ex : [{"date_start":"2012-12-14","date_end":"2012-12-16","prefix":"2012"},{"date_start":"2013-01-14","date_end":"2012-01-16","prefix":"2013"}]
        /// </summary>
        public string slices { get; set; }


    }
}
