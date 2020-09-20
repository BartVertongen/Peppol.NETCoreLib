
using System;
using System.Net.Http;
using VertSoft.Peppol.Lookup.Api;



//Mode looklike a system to keep configurations for differerent Modes like TEST,DEVELOP,PROD
//using Mode = no.difi.vefa.peppol.mode.Mode;


namespace VertSoft.Peppol.Lookup.Fetcher
{
	public class ApacheFetcherTest
	{
        //private MetadataFetcher fetcher = new ApacheFetcher(Mode.of("TEST"));

        /// <summary>
        /// Does a request with a nonexisting uri and will result in a timeout.
        /// </summary>
        /// <remarks>It does not give a timeout but says it can not find the url (dns-error)</remarks>
        public void simpleTimeoutAsync()
		{
            try
            {
                HttpResponseMessage response = ApacheFetcher.Fetch(new Uri("http://invalid.example.com/")).Result;
            }
            catch (Exception /*ex*/)
            {
                //throw new LookupException(ex.InnerException.Message, ex);
            }
        }


        //public void simple404() throws no.difi.vefa.peppol.lookup.api.LookupException, java.io.FileNotFoundException
		public void simple404()
		{
            try
            {
                HttpResponseMessage response = ApacheFetcher.Fetch(new Uri("http://httpstat.us/404")).Result;
            }
            catch (Exception ex)
            {
                throw new LookupException(ex.Message, ex);
            }
        }


        //throws no.difi.vefa.peppol.lookup.api.LookupException, java.io.FileNotFoundException
		public virtual void simple500()
		{
            try
            {
                HttpResponseMessage response = ApacheFetcher.Fetch(new Uri("http://httpstat.us/500")).Result;
            }
            catch (Exception ex)
            {
                throw new LookupException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Does a request with an empty uri.
        /// </summary>
        /// <exception cref="LookupException"/>
        public virtual void simpleNullPointer()
		{
            try
            {
                HttpResponseMessage response = ApacheFetcher.Fetch(null).Result;
            }
            catch (Exception /*ex*/)
            {
                //throw new LookupException(ex.InnerException.Message, ex);
            }
		}
	}
}