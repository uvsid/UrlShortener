namespace UrlShortner.Service.Database
{
    public interface IContextTest
    {
        /// <summary>
        /// Inserts an Item into DB
        /// </summary>
        /// <param name="uriModel"></param>
        /// <returns></returns>
        public Task InsertAsync(Models.ShortenedUrl uriModel);
        /// <summary>
        /// Retrieves an Item from DB
        /// </summary>
        /// <param name="uriModel"></param>
        /// <returns></returns>
        public Task<Models.ShortenedUrl> GetAsync(string token);


    }
}
