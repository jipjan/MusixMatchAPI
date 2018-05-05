using System;
using System.Collections.Generic;
using System.Net.Http;
using MusixMatch_API.APIMethods;
using MusixMatch_API.APIMethods.Album;
using MusixMatch_API.APIMethods.Artist;
using MusixMatch_API.APIMethods.Catalogue;
using MusixMatch_API.APIMethods.Chart;
using MusixMatch_API.APIMethods.Matcher;
using MusixMatch_API.APIMethods.Track;
using MusixMatch_API.APIMethods.Tracking;
using MusixMatch_API.ReturnTypes;
using Newtonsoft.Json;

namespace MusixMatch_API
{
    /// <summary>
    ///     This class handles all requests you can make to the MusixMatch API.
    /// </summary>
    public class MusixMatchApi : IDisposable
    {
        private const string RootUrl = @"http://api.musixmatch.com/ws/1.1/";
        private readonly string _apiKey;
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        ///     Initialize an API connector with your API key.
        /// </summary>
        /// <param name="apiKey">Your API Key.</param>
        public MusixMatchApi(string apiKey)
        {
            _apiKey = "&apikey=" + apiKey;
        }

        /// <summary>
        ///     Dispose Connector.
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }

        private async void RunApiCall<TOutput>(IQueryable item, Action<TOutput> succes, Action<string> fail)
        {
            try
            {
                var json = await _client.GetStringAsync(new Uri(RootUrl + item.ToUrlParams() + _apiKey));
                var status = GetStatus(json);
                if (status == 200)

                    succes(JsonConvert.DeserializeObject<TOutput>(json));
                else
                    fail(GetErrorWithStatus(status));
            }
            catch (Exception e)
            {
                fail(e.Message);
            }
        }

        private static int GetStatus(string json)
        {
            return JsonConvert.DeserializeObject<BaseJson.RootObject>(json).Message.Header.StatusCode;
        }

        private static string GetErrorWithStatus(int status)
        {
            switch (status)
            {
                case 200:
                    return "The request was successful.";
                case 400:
                    return "The request had bad syntax or was inherently impossible to be satisfied.";
                case 401:
                    return "Authentication failed, probably because of invalid/missing API key.";
                case 402:
                    return
                        "The usage limit has been reached, either you exceeded per day requests limits or your balance is insufficient.";
                case 403:
                    return
                        "You are not authorized to perform this operation.";
                case 404:
                    return
                        "The requested resource was not found.";
                case 405:
                    return "The requested method was not found.";
                case 500:
                    return "Oops. Something went wrong.";
                case 503:
                    return "Our system is a bit busy at the moment and your request can’t be satisfied.";
                default:
                    return "Unknown error occured.";
            }
        }

        #region Tracking

        /// <summary>
        ///     Get the base url for the tracking script
        ///     With this api you’ll be able to get the base url for the tracking script you need to insert in your page to
        ///     legalize your existent lyrics library.
        ///     Read more here: https://developer.musixmatch.com/documentation/rights-clearance-on-your-existing-catalog
        ///     In case you’re fetching the lyrics by the musiXmatch api called track.lyrics.get you don’t need to implement this
        ///     API call.
        /// </summary>
        /// <param name="get">The TrackingUrlGet object which contains the domain to return a tracking url for.</param>
        /// <param name="succes">When the call to the API succeeds, return a string with the tracking url.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void TrackingUrlGet(TrackingUrlGet get, Action<string> succes, Action<string> fail)
        {
            RunApiCall<ReturnedTrackingUrl.RootObject>(get, item => succes(item.Message.Body.Url), fail);
        }

        #endregion

        #region Catalogue

        /// <summary>
        ///     Get the list of our tracks with the lyrics last updated information.
        ///     Important: This method is only available for commercial plans.
        /// </summary>
        /// <param name="succes">When the call to the API succeeds, return the catalogues.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void CatalogueDumpGet(Action<ReturnedCatalogue.Catalogue> succes, Action<string> fail)
        {
            RunApiCall<ReturnedCatalogue.RootObject>(new CatalogueDumpGet(),
                item => succes(item.Message.Body.Catalogue), fail);
        }

        #endregion

        #region Charts

        /// <summary>
        ///     Get top artists of a given country.
        /// </summary>
        /// <param name="get">The ArtistsGet object which contains the filters to get the right artists.</param>
        /// <param name="succes">When the call to the API succeeds, return the list with artists.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void ChartArtistsGet(ArtistsGet get, Action<List<ReturnedArtists.ArtistList>> succes,
            Action<string> fail)
        {
            RunApiCall<ReturnedArtists.RootObject>(get, item => succes(item.Message.Body.ArtistList), fail);
        }

        /// <summary>
        ///     Get a song chart of the top in a country.
        /// </summary>
        /// <param name="get">The TracksGet object which contains the filters to get the right chart.</param>
        /// <param name="succes">When the call to the API succeeds, return the list with tracks.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void ChartTracksGet(TracksGet get, Action<List<TrackList>> succes, Action<string> fail)
        {
            RunApiCall<ReturnedTracks.RootObject>(get, item => succes(item.Message.Body.TrackList), fail);
        }

        #endregion

        #region Tracks

        /// <summary>
        ///     Search for a track in the database.
        /// </summary>
        /// <param name="get">The Search object with the filters to use for the request.</param>
        /// <param name="succes">Action to run when getting the track succeeds, returns a tracklist.</param>
        /// <param name="fail">Action to run when getting the tracklist failed, returns an error.</param>
        /// <returns>A list with all the tracks that are returned based on your filters.</returns>
        public void TrackSearch(TrackSearch get, Action<List<TrackList>> succes, Action<string> fail)
        {
            RunApiCall(get, (ReturnedTracks.RootObject item) => succes(item.Message.Body.TrackList), fail);
        }

        /// <summary>
        ///     Get a track info from our database: title, artist, instrumental flag and cover art.
        /// </summary>
        /// <param name="get">The Get object with the filters to use for the request.</param>
        /// <param name="succes">Action to run when getting the track succeeds, returns a track.</param>
        /// <param name="fail">Action to run when getting the track failed, returns an error.</param>
        public void TrackGet(TrackGet get, Action<Track> succes, Action<string> fail)
        {
            RunApiCall(get, (ReturnedTrack.RootObject item) => succes(item.Message.Body.Track), fail);
        }

        /// <summary>
        ///     Retreive the subtitle of a track. Needs Commercial Plan.
        /// </summary>
        /// <param name="get">The SubtitleGet object which contains the filters to get the right song subtitles.</param>
        /// <param name="succes">When the call to the API succeeds, return the subtitle object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void TrackSubtitleGet(TrackSubtitleGet get, Action<ReturnedSubtitle.Subtitle> succes,
            Action<string> fail)
        {
            RunApiCall(get, (ReturnedSubtitle.RootObject item) => succes(item.Message.Body.Subtitle), fail);
        }

        /// <summary>
        ///     Get lyrics with a track id.
        /// </summary>
        /// <param name="get">The LyricsGet object which contains the filters to get the right song lyrics.</param>
        /// <param name="succes">When the call to the API succeeds, return the Lyrics object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void TrackLyricsGet(TrackLyricsGet get, Action<ReturnedLyrics.Lyrics> succes, Action<string> fail)
        {
            RunApiCall(get, (ReturnedLyrics.RootObject item) => succes(item.Message.Body.Lyrics), fail);
        }


        /// <summary>
        ///     Get the snippet for a given track.
        ///     A lyrics snippet is a very short representation of a song lyrics.It’s usually twenty to a hundred characters long
        ///     and it’s calculated extracting a sequence of words from the lyrics.
        /// </summary>
        /// <param name="get">The SnippetGet object which contains the filters to get the right song snippet.</param>
        /// <param name="succes">When the call to the API succeeds, return the Snippet object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void TrackSnippetGet(TrackSnippetGet get, Action<ReturnedSnippet.Snippet> succes, Action<string> fail)
        {
            RunApiCall(get, (ReturnedSnippet.RootObject item) => succes(item.Message.Body.Snippet), fail);
        }

        /// <summary>
        ///     Submit a lyrics to our database.
        ///     It may happen we don’t have the lyrics for a song, you can ask your users to help us sending the missing
        ///     lyrics.We’ll validate every submission and in case, make it available through our api.
        ///     Please take all the necessary precautions to avoid users or automatic software to use your website/app to use this
        ///     commands, a captcha solution like http://www.google.com/recaptcha or an equivalent one has to be implemented in
        ///     every user interaction that ends in a POST operation on the musixmatch api.
        /// </summary>
        /// <param name="post">The LyricsPost object containing the song id and the lyrics you want to upload.</param>
        /// <param name="succes">
        ///     When the call to the API succeeds, returns the lyrics uploaded (or nothing, this is not shown on
        ///     the musixmatch doc page...)
        /// </param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void TrackLyricsPost(TrackLyricsPost post, Action<string> succes, Action<string> fail)
        {
            RunApiCall<Posted.RootObject>(post, item => succes(item.Message.Body), fail);
        }

        /// <summary>
        ///     This API method provides you the opportunity to help us improving our catalogue. We aim to provide you with the
        ///     best quality service imaginable, so we are especially interested in your detailed feedback to help us to
        ///     continually improve it.
        ///     Please take all the necessary precautions to avoid users or automatic software to use your website/app to use this
        ///     commands, a captcha solution like http://www.google.com/recaptcha or an equivalent one has to be implemented in
        ///     every user interaction that ends in a POST operation on the musixmatch api.
        /// </summary>
        /// <param name="get">
        ///     The LyricsFeedbackPost object which contains the filters to post the feedback for the correct lyrics
        ///     and song.
        /// </param>
        /// <param name="succes">
        ///     When the call to the API succeeds, returns the uploaded feedback (or nothing, this is not shown on
        ///     the musixmatch doc page...)
        /// </param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void TrackLyricsFeedbackPost(TrackLyricsFeedbackPost get, Action<string> succes, Action<string> fail)
        {
            RunApiCall<Posted.RootObject>(get, item => succes(item.Message.Body), fail);
        }

        #endregion

        #region Matchers

        /// <summary>
        ///     Get the lyrics for track based on title and artist
        /// </summary>
        /// <param name="get">The MatcherLyricsGet object which contains the filters to get the right song lyrics.</param>
        /// <param name="succes">When the call to the API succeeds, return the Lyrics object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void MatcherLyricsGet(MatcherLyricsGet get, Action<ReturnedLyrics.Lyrics> succes, Action<string> fail)
        {
            RunApiCall<ReturnedLyrics.RootObject>(get, item => succes(item.Message.Body.Lyrics), fail);
        }

        /// <summary>
        ///     Match your song against our database.
        ///     In some cases you already have some informations about the track title, artist name, album etc.
        ///     A possible strategy to get the corresponding lyrics could be:
        ///     - search our catalogue with a perfect match,
        ///     - maybe try using the fuzzy search,
        ///     - maybe try again using artist aliases, and so on.
        ///     The matcher.track.get method does all the job for you in a single call. This way you dont’t need to worry about the
        ///     details, and you’ll get instant benefits for your application without changing a row in your code, while we take
        ///     care of improving the implementation behind. Cool, uh?
        /// </summary>
        /// <param name="get">The MatcherTrackGet object which contains the filters to get the right track.</param>
        /// <param name="succes">When the call to the API succeeds, return the Track object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void MatcherTrackGet(MatcherTrackGet get, Action<Track> succes, Action<string> fail)
        {
            RunApiCall<ReturnedTrack.RootObject>(get, item => succes(item.Message.Body.Track), fail);
        }


        /// <summary>
        ///     Get the subtitles for a song given his title, artist and duration. Needs Commercial Plan.
        /// </summary>
        /// <param name="get">The MatcherSubtitleGet object which contains the filters to get the right subtitle.</param>
        /// <param name="succes">When the call to the API succeeds, return the Subtitle object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void MatcherSubtitleGet(MatcherSubtitleGet get, Action<ReturnedSubtitle.Subtitle> succes,
            Action<string> fail)
        {
            RunApiCall<ReturnedSubtitle.RootObject>(get, item => succes(item.Message.Body.Subtitle), fail);
        }


        /// <summary>
        ///     Get the artist data from our database.
        /// </summary>
        /// <param name="get">The ArtistGet object which contains the filters to get the right Artist.</param>
        /// <param name="succes">When the call to the API succeeds, return the Artist object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void ArtistGet(ArtistGet get, Action<ReturnedArtist.Artist> succes, Action<string> fail)
        {
            RunApiCall<ReturnedArtist.RootObject>(get, item => succes(item.Message.Body.Artist), fail);
        }


        /// <summary>
        ///     Search for artists in our database.
        /// </summary>
        /// <param name="get">The ArtistSearch object which contains the filters to get the right Artists.</param>
        /// <param name="succes">When the call to the API succeeds, return the ArtistList object with artists.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void ArtistSearch(ArtistSearch get, Action<List<ReturnedArtists.ArtistList>> succes, Action<string> fail)
        {
            RunApiCall<ReturnedArtists.RootObject>(get, item => succes(item.Message.Body.ArtistList), fail);
        }

        /// <summary>
        ///     Get the album discography of an artist.
        /// </summary>
        /// <param name="get">The ArtistAlbumsGet object which contains the filters to get the right Albums.</param>
        /// <param name="succes">When the call to the API succeeds, return the AlbumList object with albums.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void ArtistAlbumsGet(ArtistAlbumsGet get, Action<List<ReturnedAlbums.AlbumList>> succes,
            Action<string> fail)
        {
            RunApiCall<ReturnedAlbums.RootObject>(get, item => succes(item.Message.Body.AlbumList), fail);
        }

        /// <summary>
        ///     Get a list of artists somehow related to a given one.
        /// </summary>
        /// <param name="get">The ArtistRelatedGet object which contains the filters to get the related artists.</param>
        /// <param name="succes">When the call to the API succeeds, return the AlbumList object with albums.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void ArtistRelatedGet(ArtistRelatedGet get, Action<List<ReturnedArtists.ArtistList>> succes,
            Action<string> fail)
        {
            RunApiCall<ReturnedArtists.RootObject>(get, item => succes(item.Message.Body.ArtistList), fail);
        }

        #endregion

        #region Albums

        /// <summary>
        ///     Get an album from our database: name, release_date, release_type, cover art.
        /// </summary>
        /// <param name="get">The AlbumGet object which contains the filters to get the album.</param>
        /// <param name="succes">When the call to the API succeeds, return the Album object.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void AlbumGet(AlbumGet get, Action<Album> succes, Action<string> fail)
        {
            RunApiCall<ReturnedAlbum.RootObject>(get, item => succes(item.Message.Body.Album), fail);
        }

        /// <summary>
        ///     This api provides you the list of the songs of an album.
        /// </summary>
        /// <param name="get">The AlbumTracksGet object which contains the filters to get the tracks.</param>
        /// <param name="succes">When the call to the API succeeds, return the List with tracks.</param>
        /// <param name="fail">Action to run when the call failed, returns an error.</param>
        public void AlbumTracksGet(AlbumTracksGet get, Action<List<TrackList>> succes, Action<string> fail)
        {
            RunApiCall<ReturnedTracks.RootObject>(get, item => succes(item.Message.Body.TrackList), fail);
        }

        #endregion
    }
}